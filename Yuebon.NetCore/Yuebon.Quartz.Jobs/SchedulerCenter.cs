﻿using Quartz.Spi;
using System.Collections.Specialized;
using System.Reflection;
using Yuebon.Security.Dtos;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 任务调度管理中心
    /// </summary>
    public class SchedulerCenter : ISchedulerCenter
    {
        /// <summary>
        /// 调度器
        /// </summary>
        private Task<IScheduler> _scheduler;
        private readonly IJobFactory _iocjobFactory;
        public SchedulerCenter(IJobFactory jobFactory)
        {
            _iocjobFactory = jobFactory;
            _scheduler = GetSchedulerAsync();
        }
        private Task<IScheduler> GetSchedulerAsync()
        {
            if (_scheduler != null)
                return this._scheduler;
            else
            {
                // 从Factory中获取Scheduler实例
                NameValueCollection collection = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" },
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(collection);
                return _scheduler = factory.GetScheduler();
            }
        }

        /// <summary>
        /// 开启任务调度
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResult> StartScheduleAsync()
        {
            var result = new CommonResult();
            try
            {
                this._scheduler.Result.JobFactory = this._iocjobFactory;
                if (!this._scheduler.Result.IsStarted)
                {
                    //等待任务运行完成
                    await this._scheduler.Result.Start();
                    await Console.Out.WriteLineAsync("任务调度开启！");
                    result.Success = true;
                    result.ErrMsg = $"任务调度开启成功";
                    return result;
                }
                else
                {
                    result.Success = false;
                    result.ErrMsg = $"任务调度已经开启";
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 停止任务调度
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResult> StopScheduleAsync()
        {
            var result = new CommonResult();
            try
            {
                if (!this._scheduler.Result.IsShutdown)
                {
                    //等待任务运行完成
                    await this._scheduler.Result.Shutdown();
                    await Console.Out.WriteLineAsync("任务调度停止！");
                    result.Success = true;
                    result.ErrMsg = $"任务调度停止成功";
                    return result;
                }
                else
                {
                    result.Success = false;
                    result.ErrMsg = $"任务调度已经停止";
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加一个计划任务（映射程序集指定IJob实现类）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="taskManager"></param>
        /// <returns></returns>
        public async Task<CommonResult> AddScheduleJobAsync(TaskManager taskManager)
        {
            var result = new CommonResult();

            if (taskManager != null)
            {
                try
                {
                    JobKey jobKey = new JobKey(taskManager.Id.ToString(), taskManager.GroupName);
                    if (await _scheduler.Result.CheckExists(jobKey))
                    {
                        result.Success = false;
                        result.ErrMsg = $"该任务计划已经在执行:【{taskManager.TaskName}】,请勿重复启动！";
                        return result;
                    }
                    #region 设置开始时间和结束时间

                    if (taskManager.StartTime == null)
                    {
                        taskManager.StartTime = DateTime.Now;
                    }
                    DateTimeOffset starRunTime = DateBuilder.NextGivenSecondDate(taskManager.StartTime, 1);//设置开始时间
                    if (taskManager.EndTime == null)
                    {
                        taskManager.EndTime = DateTime.MaxValue.AddDays(-1);
                    }
                    DateTimeOffset endRunTime = DateBuilder.NextGivenSecondDate(taskManager.EndTime, 1);//设置暂停时间

                    #endregion

                   

                    IJobDetail jobDetail;
                    if (taskManager.IsLocal)
                    {
                        Type jobType;
                        //#region 通过反射获取程序集类型和类   
                        if (!string.IsNullOrEmpty(taskManager.AssemblyName) && !string.IsNullOrEmpty(taskManager.ClassName))
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(taskManager.AssemblyName));
                            jobType = assembly.GetType(taskManager.AssemblyName + "." + taskManager.ClassName);
                        }
                        else
                        {
                            var implementationAssembly = Assembly.Load("Yuebon.Quartz.Jobs");
                            var implementationTypes = implementationAssembly.DefinedTypes.Where(t => t.GetInterfaces().Contains(typeof(IJob)));
                            jobType = implementationTypes.Where(x => x.FullName == taskManager.JobCallAddress).FirstOrDefault();
                            //jobDetail = JobBuilder.Create(tyeinfo).WithIdentity(job.Id.ToString(), job.GroupName).Build();
                        }

                        //#endregion
                        //传入反射出来的执行程序集
                        jobDetail = new JobDetailImpl(taskManager.Id.ToString(), taskManager.GroupName, jobType);
                        jobDetail.JobDataMap.Add("JobParam", taskManager.JobCallParams);
                    }
                    else
                    {
                        jobDetail = JobBuilder.Create<HttpResultfulJob>().WithIdentity(taskManager.Id.ToString(), taskManager.GroupName).Build();
                        jobDetail.JobDataMap.Add("JobParam", taskManager.JobCallParams);
                    }
                    //判断任务调度是否开启
                    if (!_scheduler.Result.IsStarted)
                    {
                        await StartScheduleAsync();
                    }

                    ITrigger trigger;

                    #region 泛型传递
                    //IJobDetail job = JobBuilder.Create<T>()
                    //    .WithIdentity(sysSchedule.TaskName, sysSchedule.JobGroup)
                    //    .Build();
                    #endregion

                    if (taskManager.Cron != null && CronExpression.IsValidExpression(taskManager.Cron) && taskManager.Status > 0)
                    {
                        trigger = CreateCronTrigger(taskManager);

                        ((CronTriggerImpl)trigger).MisfireInstruction = MisfireInstruction.CronTrigger.DoNothing;
                    }
                    else
                    {
                        trigger = CreateSimpleTrigger(taskManager);
                    }

                    // 告诉Quartz使用我们的触发器来安排作业
                    await _scheduler.Result.ScheduleJob(jobDetail, trigger);
                    //await Task.Delay(TimeSpan.FromSeconds(120));
                    //await Console.Out.WriteLineAsync("关闭了调度器！");
                    //await _scheduler.Result.Shutdown();
                    result.Success = true;
                    result.ErrMsg = $"【{taskManager.TaskName}】成功";
                    return result;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrMsg = $"任务计划异常:【{ex.Message}】";
                    return result;
                }
            }
            else
            {
                result.Success = false;
                result.ErrMsg = $"任务计划不存在:【{taskManager?.TaskName}】";
                return result;
            }
        }

        /// <summary>
        /// 任务是否存在?
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsExistScheduleJobAsync(TaskManager sysSchedule)
        { 
            JobKey jobKey = new JobKey(sysSchedule.Id.ToString(), sysSchedule.GroupName);
            if (await _scheduler.Result.CheckExists(jobKey))
            { 
                return true;
            }
            else
            { 
                return false;
            }
        }
        /// <summary>
        /// 暂停一个指定的计划任务
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResult> StopScheduleJobAsync(TaskManager sysSchedule)
        {
            var result = new CommonResult();
            try
            {
                JobKey jobKey = new JobKey(sysSchedule.Id.ToString(), sysSchedule.GroupName);
                if (!await _scheduler.Result.CheckExists(jobKey))
                {
                    result.Success = false;
                    result.ErrMsg = $"未找到要暂停的任务:【{sysSchedule.TaskName}】";
                    return result;
                }
                else
                {
                    await this._scheduler.Result.DeleteJob(jobKey);
                    result.Success = true;
                    result.ErrMsg = $"【{sysSchedule.TaskName}】成功";
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 恢复指定的计划任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        public async Task<CommonResult> ResumeJob(TaskManager sysSchedule)
        {
            var result = new CommonResult();
            try
            {
                JobKey jobKey = new JobKey(sysSchedule.Id.ToString(), sysSchedule.GroupName);
                if (!await _scheduler.Result.CheckExists(jobKey))
                {
                    result.Success = false;
                    result.ErrMsg = $"未找到要恢复的任务:【{sysSchedule.TaskName}】";
                    return result;
                }
                await this._scheduler.Result.ResumeJob(jobKey);
                result.Success = true;
                result.ErrMsg = $"【{sysSchedule.TaskName}】成功";
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 暂停指定的计划任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        public async Task<CommonResult> PauseJob(TaskManager sysSchedule)
        {
            var result = new CommonResult();
            try
            {
                JobKey jobKey = new JobKey(sysSchedule.Id.ToString(), sysSchedule.GroupName);
                if (!await _scheduler.Result.CheckExists(jobKey))
                {
                    result.Success = false;
                    result.ErrMsg = $"未找到要暂停的任务:【{sysSchedule.TaskName}】";
                    return result;
                }
                await this._scheduler.Result.PauseJob(jobKey);
                result.Success = true;
                result.ErrMsg = $"【{sysSchedule.TaskName}】成功";
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region 状态状态帮助方法
        public async Task<List<TaskInfoDto>> GetTaskStaus(TaskManager sysSchedule)
        {

            var ls = new List<TaskInfoDto>();
            var noTask = new List<TaskInfoDto>{ new TaskInfoDto {
                jobId = sysSchedule.Id.ObjToString(),
                jobGroup = sysSchedule.GroupName,
                triggerId = "",
                triggerGroup = "",
                triggerStatus = "不存在"
            } };
            JobKey jobKey = new JobKey(sysSchedule.Id.ToString(), sysSchedule.GroupName);
            IJobDetail job = await this._scheduler.Result.GetJobDetail(jobKey);
            if (job == null)
            {
                return noTask;
            }
            //info.Append(string.Format("任务ID:{0}\r\n任务名称:{1}\r\n", job.Key.TaskName, job.Description)); 
            var triggers = await this._scheduler.Result.GetTriggersOfJob(jobKey);
            if (triggers == null || triggers.Count == 0)
            {
                return noTask;
            }
            foreach (var trigger in triggers)
            {
                var triggerStaus = await this._scheduler.Result.GetTriggerState(trigger.Key);
                string state = GetTriggerState(triggerStaus.ObjToString());
                ls.Add(new TaskInfoDto
                {
                    jobId = job.Key.Name,
                    jobGroup = job.Key.Group,
                    triggerId = trigger.Key.Name,
                    triggerGroup = trigger.Key.Group,
                    triggerStatus = state
                });
                //info.Append(string.Format("触发器ID:{0}\r\n触发器名称:{1}\r\n状态:{2}\r\n", item.Key.TaskName, item.Description, state));

            }
            return ls;
        }
        public string GetTriggerState(string key)
        {
            string state = null;
            if (key != null)
                key = key.ToUpper();
            switch (key)
            {
                case "1":
                    state = "暂停";
                    break;
                case "2":
                    state = "完成";
                    break;
                case "3":
                    state = "出错";
                    break;
                case "4":
                    state = "阻塞";
                    break;
                case "0":
                    state = "正常";
                    break;
                case "-1":
                    state = "不存在";
                    break;
                case "BLOCKED":
                    state = "阻塞";
                    break;
                case "COMPLETE":
                    state = "完成";
                    break;
                case "ERROR":
                    state = "出错";
                    break;
                case "NONE":
                    state = "不存在";
                    break;
                case "NORMAL":
                    state = "正常";
                    break;
                case "PAUSED":
                    state = "暂停";
                    break;
            }
            return state;
        }
        #endregion

        #region 创建触发器帮助方法

        /// <summary>
        /// 创建SimpleTrigger触发器（简单触发器）
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <param name="starRunTime"></param>
        /// <param name="endRunTime"></param>
        /// <returns></returns>
        private ITrigger CreateSimpleTrigger(TaskManager sysSchedule)
        {
            if (sysSchedule.CycleRunTimes > 0)
            {
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(sysSchedule.Id.ToString(), sysSchedule.GroupName)
                    .WithCronSchedule(sysSchedule.Cron)
                .StartAt(sysSchedule.StartTime.Value)
                .WithSimpleSchedule(x => x
                    .WithRepeatCount(sysSchedule.CycleRunTimes - 1))
                .EndAt(sysSchedule.EndTime.Value) 
                .Build();
                return trigger;
            }
            else
            {
                ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(sysSchedule.Id.ToString(), sysSchedule.GroupName)
                .WithCronSchedule(sysSchedule.Cron)
                .StartAt(sysSchedule.StartTime.Value)
                .WithSimpleSchedule(x => x
                    .RepeatForever()
                )
                .EndAt(sysSchedule.EndTime.Value) 
                .Build();
                return trigger;
            }
            // 触发作业立即运行，然后每10秒重复一次，无限循环

        }
        /// <summary>
        /// 创建类型Cron的触发器
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private ITrigger CreateCronTrigger(TaskManager sysSchedule)
        {
            // 作业触发器
            return TriggerBuilder.Create()
                   .WithIdentity(sysSchedule.Id.ToString(), sysSchedule.GroupName)
                   .StartAt(sysSchedule.StartTime.Value)//开始时间
                   .EndAt(sysSchedule.EndTime.Value)//结束数据
                   .WithCronSchedule(sysSchedule.Cron)//指定cron表达式
                   .ForJob(sysSchedule.Id.ToString(), sysSchedule.GroupName)//作业名称
                   .Build();
        }
        #endregion


        /// <summary>
        /// 立即执行 一个任务
        /// </summary>
        /// <param name="taskManager"></param>
        /// <returns></returns>
        public async Task<CommonResult> ExecuteJobAsync(TaskManager taskManager)
        {
            var result = new CommonResult();
            try
            {
                JobKey jobKey = new JobKey(taskManager.Id.ToString(), taskManager.GroupName);
                
                //判断任务是否存在，存在则 触发一次，不存在则先添加一个任务，触发以后再 停止任务
                if (!await _scheduler.Result.CheckExists(jobKey))
                {
                    //不存在 则 添加一个计划任务
                    await AddScheduleJobAsync(taskManager);
                    
                    //触发执行一次
                    await _scheduler.Result.TriggerJob(jobKey);

                    //停止任务
                    await StopScheduleJobAsync(taskManager);

                    result.Success = true;
                    result.ErrMsg = $"立即执行计划任务:【{taskManager.TaskName}】成功";
                }
                else
                {
                    await _scheduler.Result.TriggerJob(jobKey);
                    result.Success = true;
                    result.ErrMsg = $"立即执行计划任务:【{taskManager.TaskName}】成功";
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = $"立即执行计划任务失败:【{ex.Message}】";
            }

            return result;
        }


    }
}
