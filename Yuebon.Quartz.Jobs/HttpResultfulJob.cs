using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Email;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 处理远程接口url的定时任务
    /// </summary>
    public class HttpResultfulJob : IJob
    {
        ITaskManagerService iService = App.GetService<ITaskManagerService>();

        /// <summary>
        /// 执行远程接口url的定时任务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            SysSetting sysSetting = yuebonCacheHelper.Get("SysSetting").ToJson().ToObject<SysSetting>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;
            string sqlWhere = string.Format("Id='{0}' and GroupName='{1}'", trigger.Name, trigger.Group);
            TaskManager taskManager = iService.GetWhere(sqlWhere);
            string httpMessage = "";
            if (taskManager == null)
            {
                FileQuartz.WriteErrorLog($"任务不存在");
                return Task.Delay(1);
            }
            FileQuartz.InitTaskJobLogPath(taskManager.Id);
            string msg = $"开始时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")}";
            //记录任务执行记录
            iService.RecordRun(taskManager.Id, JobAction.开始, true, msg);
            if (string.IsNullOrEmpty(taskManager.JobCallAddress) || taskManager.JobCallAddress == "/")
            {
                FileQuartz.WriteErrorLog($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")}未配置任务地址,");
                iService.RecordRun(taskManager.Id, JobAction.结束, false, "未配置任务地址");
                return Task.Delay(1);
            }
            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                //if (!string.IsNullOrEmpty(taskOptions.AuthKey)
                //    && !string.IsNullOrEmpty(taskOptions.AuthValue))
                //{
                //    header.Add(taskOptions.AuthKey.Trim(), taskOptions.AuthValue.Trim());
                //}
                if (!string.IsNullOrEmpty(taskManager.JobCallParams))
                {
                    httpMessage = HttpRequestHelper.HttpPost(taskManager.JobCallAddress, taskManager.JobCallParams, null, header);
                }
                else
                {
                    httpMessage = HttpRequestHelper.HttpGet(taskManager.JobCallAddress);
                }
                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒,消息:{httpMessage??"OK"}\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束,true, content);
                if ((MsgType)taskManager.SendMail == MsgType.All)
                {
                    string emailAddress = sysSetting.Email;
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {
                        emailAddress = taskManager.EmailAddress;
                    }

                    List<string> recipients = new List<string>();
                    recipients = taskManager.EmailAddress.Split(",").ToList();
                    //recipients.Add(taskManager.EmailAddress);
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = content + "\n\r请勿直接回复本邮件！",
                        Recipients = recipients,
                        Subject = taskManager.TaskName,
                    };
                    SendMailHelper.SendMail(mailBodyEntity);
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束, false, content+ex.Message);
                FileQuartz.WriteErrorLog(ex.Message); 
                if ((MsgType)taskManager.SendMail== MsgType.Error|| (MsgType)taskManager.SendMail == MsgType.All)
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
                        Body = ex.Message + "\n\r请勿直接回复本邮件!",
                        Recipients = recipients,
                        Subject = taskManager.TaskName,
                    };
                    SendMailHelper.SendMail(mailBodyEntity);
                }
            }

            return Task.Delay(1);
        }
    }
}
