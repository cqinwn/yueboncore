using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Log;
using Yuebon.Commons.Options;
using Yuebon.Messages.Mail;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 定时删除操作日志和任务日志
    /// 
    /// </summary>
    public class SysLogJob : IJob
    {
        ITaskManagerService iService = IoCContainer.Resolve<ITaskManagerService>();

        ITaskJobsLogService iJobLogService = IoCContainer.Resolve<ITaskJobsLogService>();
        ILogService iLogService = IoCContainer.Resolve<ILogService>();

        public Task Execute(IJobExecutionContext context)
        {
            DateTime dateTime = DateTime.Now;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;
            string sqlWhere = string.Format("Id='{0}' and GroupName='{1}'", trigger.Name, trigger.Group);
            TaskManager taskManager = iService.GetWhere(sqlWhere);
            if (taskManager == null)
            {
                FileQuartz.WriteErrorLog($"任务不存在");
                return Task.Delay(1);
            }
            try
            {
                string msg = $"开始时间:{dateTime.ToString("yyyy-MM-dd HH:mm:ss")}";
                //记录任务执行记录
                iService.RecordRun(taskManager.Id, JobAction.开始, true, msg);
                //初始化任务日志
                FileQuartz.InitTaskJobLogPath(taskManager.Id);
                ////任务错误日志
                //FileQuartz.WriteErrorLog($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")}未配置url,");

                var jobId = context.MergedJobDataMap.GetString("OpenJob");
                iJobLogService.DeleteBatchWhereAsync("");
                iLogService.DeleteBatchWhereAsync("");

                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束, true, content);
                if (taskManager.IsSendMail)
                {
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {
                        
                        List<string> recipients = new List<string>();
                        recipients = taskManager.EmailAddress.Split(",").ToList();
                        //recipients.Add(taskManager.EmailAddress);
                        var mailBodyEntity = new MailBodyEntity()
                        {
                            Body = content + ",请勿回复本邮件",
                            Recipients = recipients,
                            Subject = "定时删除日志",
                        };
                        SendMailHelper.SendMail(mailBodyEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                iService.RecordRun(taskManager.Id, JobAction.结束, false, ex.Message);
                FileQuartz.WriteErrorLog(ex.Message);
                if (taskManager.IsSendMail)
                {
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {

                        List<string> recipients = new List<string>();
                        recipients = taskManager.EmailAddress.Split(",").ToList();
                        //recipients.Add(taskManager.EmailAddress);
                        var mailBodyEntity = new MailBodyEntity()
                        {
                            Body = "处理失败," + ex.Message + ",请勿回复本邮件",
                            Recipients = recipients,
                            Subject = "定时删除日志",
                        };
                        SendMailHelper.SendMail(mailBodyEntity);
                    }
                }
            }

            return Task.Delay(1);
        }
    }
}
