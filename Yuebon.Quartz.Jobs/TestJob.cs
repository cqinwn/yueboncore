﻿using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Log;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 测试demo
    /// 必须实现IJob接口中的Execute()方法
    /// </summary>
    public class TestJob : IJob
    {
        ITaskManagerService iService = IoCContainer.Resolve<ITaskManagerService>();

        public Task Execute(IJobExecutionContext context)
        { 
            DateTime dateTime = DateTime.Now;
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
                //记录任务执行记录
                iService.RecordRun(taskManager.Id);
                //初始化任务日志
                FileQuartz.InitTaskJobLogPath(taskManager.Id);
                //任务开始日志
                FileQuartz.WriteStartLog($"作业[{taskManager.TaskName}]开始:{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")}");

                ////任务错误日志
                //FileQuartz.WriteErrorLog($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")}未配置url,");

                var jobId = context.MergedJobDataMap.GetString("OpenJob");
                //todo:这里可以加入自己的自动任务逻辑
                Log4NetHelper.Info(DateTime.Now.ToString() + "执行任务");

                FileQuartz.WriteJobAction(JobAction.执行, trigger, taskManager.TaskName, taskManager.GroupName);
            }
            catch (Exception ex)
            {
                //记录任务错误记录
                iService.RecordRun(taskManager.Id, false);
                //任务错误日志
                FileQuartz.WriteErrorLog(ex.Message);
            }
            return Task.Delay(1);
        }
    }
}
