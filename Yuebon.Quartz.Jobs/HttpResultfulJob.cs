using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
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
            DateTime dateTime = DateTime.Now;
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
            iService.RecordRun(taskManager.Id);
            FileQuartz.WriteStartLog($"作业[{taskManager.TaskName}]开始:{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")}");
            if (string.IsNullOrEmpty(taskManager.JobCallAddress) || taskManager.JobCallAddress == "/")
            {
                FileQuartz.WriteErrorLog($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")}未配置url,");
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
                FileQuartz.WriteJobAction(JobAction.执行, trigger, taskManager.TaskName, taskManager.GroupName);
            }
            catch (Exception ex)
            {
                httpMessage = ex.Message;
                iService.RecordRun(taskManager.Id,false);
                FileQuartz.WriteErrorLog(ex.Message);
            }

            return Task.Delay(1);
        }
    }
}
