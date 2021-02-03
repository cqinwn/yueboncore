using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Email;
using Yuebon.Quartz.IServices;
using Yuebon.Quartz.Models;
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
        ITaskManagerService iService = App.GetService<ITaskManagerService>();

        ITaskJobsLogService iJobLogService = App.GetService<ITaskJobsLogService>();
        ILogService iLogService = App.GetService<ILogService>();

        public Task Execute(IJobExecutionContext context)
        {
            DateTime dateTime = DateTime.Now; 
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            SysSetting sysSetting = yuebonCacheHelper.Get("SysSetting").ToJson().ToObject<SysSetting>();
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
                string msg = $"开始时间:{dateTime.ToString("yyyy-MM-dd HH:mm:ss ffff")}";
                //记录任务执行记录
                iService.RecordRun(taskManager.Id, JobAction.开始, true, msg);
                //初始化任务日志
                FileQuartz.InitTaskJobLogPath(taskManager.Id);

                var jobId = context.MergedJobDataMap.GetString("OpenJob");
                iJobLogService.DeleteBatchWhereAsync("");
                string where = "Type not in('Login','Exception') and CreatorTime>'"+ DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                iLogService.DeleteBatchWhereAsync(where);

                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束, true, content);
                if ((MsgType)taskManager.SendMail == MsgType.All)
                {
                    string emailAddress = sysSetting.Email;
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {
                        emailAddress = taskManager.EmailAddress;
                    }

                    List<string> recipients = new List<string>();
                    recipients = emailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = content + ",请勿回复本邮件",
                        Recipients = recipients,
                        Subject = taskManager.TaskName
                    };
                    SendMailHelper.SendMail(mailBodyEntity);
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束, false, content+ ex.Message);
                FileQuartz.WriteErrorLog(ex.Message);
                if ((MsgType)taskManager.SendMail == MsgType.Error || (MsgType)taskManager.SendMail == MsgType.All)
                {

                    string emailAddress = sysSetting.Email;
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {
                        emailAddress = taskManager.EmailAddress;
                    }

                    List<string> recipients = new List<string>();
                    recipients = emailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = "处理失败," + ex.Message + ",请勿回复本邮件",
                        Recipients = recipients,
                        Subject = taskManager.TaskName
                    };
                    SendMailHelper.SendMail(mailBodyEntity);

                }
            }

            return Task.Delay(1);
        }
    }
}
