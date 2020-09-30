using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Helpers;
using System.IO;
using Quartz.Spi;
using Microsoft.AspNetCore.Http;

namespace Yuebon.WebApi.Extensions
{
    public  class QuartzNETExtension
    {
        private static List<TaskManager> _taskList = new List<TaskManager>();
        private static ITaskManagerService iService = IoCContainer.Resolve<ITaskManagerService>();
        private static string _logPath="";

        private IScheduler _scheduler;
        /// <summary>
        /// 初始化作业
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseQuartz(this IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            IServiceProvider services = applicationBuilder.ApplicationServices;

            ISchedulerFactory _schedulerFactory = services.GetService<ISchedulerFactory>();
            _logPath = $"{Directory.GetParent(env.ContentRootPath).FullName}\\Logs\\Quartz\\"+DateTime.Now.ToString("yyyyMMdd");
            _taskList = iService.GetAll().ToList();
           
            if (_taskList.Count==0)
            {
                FileHelper.WriteFile(_logPath, "start.txt", $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},没有默认配置任务\r\n", true);
                return applicationBuilder;
            }

            int errorCount = 0;
            string errorMsg = "";
            TaskManager options = null;
            try
            {
                _taskList.ForEach(x =>
                {
                    options = x;
                    var result = x.AddJob(_schedulerFactory, true, jobFactory: services.GetService<IJobFactory>()).GetAwaiter().GetResult();
                });
            }
            catch (Exception ex)
            {
                errorCount = +1;
                errorMsg += $"作业:{options?.TaskName},异常：{ex.Message}";
            }
            string content = $"成功:{   _taskList.Count - errorCount}个,失败{errorCount}个,异常：{errorMsg}\r\n";
            content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + content;
            if (!content.EndsWith("\r\n"))
            {
                content += "\r\n";
            }
            FileHelper.WriteFile(_logPath, "start.txt", content, true);
            return applicationBuilder;
        }

        public void ChangeJobStatus(ChangeJobStatusReq req)
        {
            var job = Repository.FindSingle(u => u.Id == req.Id);
            if (job == null)
            {
                throw new Exception("任务不存在");
            }



            if (req.Status == 0) //停止
            {
                TriggerKey triggerKey = new TriggerKey(job.Id);
                // 停止触发器
                _scheduler.PauseTrigger(triggerKey);
                // 移除触发器
                _scheduler.UnscheduleJob(triggerKey);
                // 删除任务
                _scheduler.DeleteJob(new JobKey(job.Id));
            }
            else  //启动
            {
                var jobBuilderType = typeof(JobBuilder);
                var method = jobBuilderType.GetMethods().FirstOrDefault(
                        x => x.Name.Equals("Create", StringComparison.OrdinalIgnoreCase) &&
                             x.IsGenericMethod && x.GetParameters().Length == 0)
                    ?.MakeGenericMethod(Type.GetType(job.JobCall));

                var jobBuilder = (JobBuilder)method.Invoke(null, null);

                IJobDetail jobDetail = jobBuilder.WithIdentity(job.Id).Build();
                jobDetail.JobDataMap[Define.JOBMAPKEY] = job.Id;  //传递job信息
                ITrigger trigger = TriggerBuilder.Create()
                    .WithCronSchedule(job.Cron)
                    .WithIdentity(job.Id)
                    .StartNow()
                    .Build();
                _scheduler.ScheduleJob(jobDetail, trigger);
            }


            var user = _auth.GetCurrentUser().User;

            job.Status = req.Status;
            job.UpdateTime = DateTime.Now;
            job.UpdateUserId = user.Id;
            job.UpdateUserName = user.Name;
            Repository.Update(job);
        }


        /// <summary>
        /// 触发新增、删除、修改、暂停、启用、立即执行事件
        /// </summary>
        /// <param name="schedulerFactory"></param>
        /// <param name="taskName"></param>
        /// <param name="groupName"></param>
        /// <param name="action"></param>
        /// <param name="taskOptions"></param>
        /// <returns></returns>
        public static async Task<object> TriggerAction(this ISchedulerFactory schedulerFactory, string taskName, string groupName, JobAction action, TaskManager taskOptions = null)
        {
            string errorMsg = "";
            try
            {
                IScheduler scheduler = await schedulerFactory.GetScheduler();
                List<JobKey> jobKeys = scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(groupName)).Result.ToList();
                if (jobKeys == null || jobKeys.Count() == 0)
                {
                    errorMsg = $"未找到分组[{groupName}]";
                    return new { status = false, msg = errorMsg };
                }
                JobKey jobKey = jobKeys.Where(s => scheduler.GetTriggersOfJob(s).Result.Any(x => (x as CronTriggerImpl).Name == taskName)).FirstOrDefault();
                if (jobKey == null)
                {
                    errorMsg = $"未找到触发器[{taskName}]";
                    return new { status = false, msg = errorMsg };
                }
                var triggers = await scheduler.GetTriggersOfJob(jobKey);
                ITrigger trigger = triggers?.Where(x => (x as CronTriggerImpl).Name == taskName).FirstOrDefault();

                if (trigger == null)
                {
                    errorMsg = $"未找到触发器[{taskName}]";
                    return new { status = false, msg = errorMsg };
                }
                object result = null;
                switch (action)
                {
                    case JobAction.删除:
                    case JobAction.修改:
                        await scheduler.PauseTrigger(trigger.Key);
                        await scheduler.UnscheduleJob(trigger.Key);// 移除触发器
                        await scheduler.DeleteJob(trigger.JobKey);
                        result = taskOptions.ModifyTaskEntity(schedulerFactory, action);
                        break;
                    case JobAction.暂停:
                    case JobAction.停止:
                    case JobAction.开启:
                        result = taskOptions.ModifyTaskEntity(schedulerFactory, action);
                        if (action == JobAction.暂停)
                        {
                            await scheduler.PauseTrigger(trigger.Key);
                        }
                        else if (action == JobAction.开启)
                        {
                            await scheduler.ResumeTrigger(trigger.Key);
                            //   await scheduler.RescheduleJob(trigger.Key, trigger);
                        }
                        else
                        {
                            await scheduler.Shutdown();
                        }
                        break;
                    case JobAction.立即执行:
                        await scheduler.TriggerJob(jobKey);
                        break;
                }
                return result ?? new { status = true, msg = $"作业{action.ToString()}成功" };
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return new { status = false, msg = ex.Message };
            }
            finally
            {
                FileQuartz.WriteJobAction(action, taskName, groupName, errorMsg);
            }
        }

        /// <summary>
        /// 作业是否存在
        /// </summary>
        /// <param name="taskOptions"></param>
        /// <param name="init">初始化的不需要判断</param>
        /// <returns></returns>
        public static (bool, object) Exists(this TaskManager taskOptions, bool init)
        {
            if (!init && _taskList.Any(x => x.TaskName == taskOptions.TaskName && x.GroupName == taskOptions.GroupName))
            {
                return (false,
                    new
                    {
                        status = false,
                        msg = $"作业:{taskOptions.TaskName},分组：{taskOptions.GroupName}已经存在"
                    });
            }
            return (true, null);
        }

        /// <summary>
        /// 判断cron表达式是否正确
        /// </summary>
        /// <param name="cronExpression">Cron表达式</param>
        /// <returns></returns>
        public static (bool, string) IsValidExpression(this string cronExpression)
        {
            try
            {
                CronTriggerImpl trigger = new CronTriggerImpl();
                trigger.CronExpressionString = cronExpression;
                DateTimeOffset? date = trigger.ComputeFirstFireTimeUtc(null);
                return (date != null, date == null ? $"请确认表达式{cronExpression}是否正确!" : "");
            }
            catch (Exception e)
            {
                return (false, $"请确认表达式{cronExpression}是否正确!{e.Message}");
            }
        }
    }
}
