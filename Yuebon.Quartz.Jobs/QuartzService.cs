using Microsoft.Extensions.Hosting;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Yuebon.Commons.Log;
using Yuebon.Quartz.IServices;
using Yuebon.Quartz.Models;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 定时任务启动
    /// </summary>
    public class QuartzService : IHostedService, IDisposable
    {
        private ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler;
        private ITaskManagerService _iService;

        public QuartzService(ISchedulerFactory schedulerFactory, ITaskManagerService iService)
        {
            _schedulerFactory = schedulerFactory;
            _iService = iService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Log4NetHelper.Info("开始启动定时任务");
            try
            {
                IEnumerable<TaskManager> list = _iService.GetAllByIsNotDeleteAndEnabledMark();
                _scheduler =await _schedulerFactory.GetScheduler();
                foreach (TaskManager job in list)
                {
                    if (job.Status == 0) //停止
                    {
                        TriggerKey triggerKey = new TriggerKey(job.Id.ToString(), job.GroupName);
                        // 停止触发器
                        await _scheduler.PauseTrigger(triggerKey);
                        // 移除触发器
                        await _scheduler.UnscheduleJob(triggerKey);
                        // 删除任务
                        await _scheduler.DeleteJob(new JobKey(job.Id.ToString()));
                    }
                    else  //启动
                    {
                        Log4NetHelper.Info("启动定时任务" + job.TaskName);
                        IJobDetail jobDetail;
                        if (job.IsLocal)
                        {
                            var implementationAssembly = Assembly.Load("Yuebon.Quartz.Jobs");
                            var implementationTypes = implementationAssembly.DefinedTypes.Where(t => t.GetInterfaces().Contains(typeof(IJob)));
                            var tyeinfo = implementationTypes.Where(x => x.FullName == job.JobCallAddress).FirstOrDefault();
                            jobDetail = JobBuilder.Create(tyeinfo).WithIdentity(job.Id.ToString(), job.GroupName).Build();
                        }
                        else
                        {
                            jobDetail = JobBuilder.Create<HttpResultfulJob>().WithIdentity(job.Id.ToString(), job.GroupName).Build();
                        }
                        jobDetail.JobDataMap["OpenJob"] = job.Id;  //传递job信息
                        ITrigger trigger = TriggerBuilder.Create()
                            .WithCronSchedule(job.Cron)
                            .WithIdentity(job.Id.ToString(), job.GroupName)
                            .WithDescription(job.Description)
                            .ForJob(job.Id.ToString(), job.GroupName) //给任务指定一个分组
                            .StartNow()
                            .Build();
                        await _scheduler.ScheduleJob(jobDetail, trigger);
                    }
                }
                await _scheduler.Start();
            }catch(Exception ex)
            {
                Log4NetHelper.Info("启动定时任务异常" +ex.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler.Shutdown();
            Log4NetHelper.Info("关闭定时任务");
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
