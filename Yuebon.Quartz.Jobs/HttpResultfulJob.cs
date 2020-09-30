using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Options;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 处理远程接口url的定时任务
    /// </summary>
    public class HttpResultfulJob : IJob
    {
        ITaskManagerService iService = IoCContainer.Resolve<ITaskManagerService>();

        /// <summary>
        /// 执行远程接口url的定时任务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
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
            string msg = $"开始时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
            //记录任务执行记录
            iService.RecordRun(taskManager.Id, JobAction.开始, true, msg);
            if (string.IsNullOrEmpty(taskManager.JobCallAddress) || taskManager.JobCallAddress == "/")
            {
                FileQuartz.WriteErrorLog($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")}未配置任务地址,");
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
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒,消息:{httpMessage??"OK"}\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束,true, content);
            }
            catch (Exception ex)
            {
                httpMessage = ex.Message;
                iService.RecordRun(taskManager.Id, JobAction.结束, false,ex.Message);
                FileQuartz.WriteErrorLog(ex.Message);
            }

            return Task.Delay(1);
        }
    }
}
