using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Linq;
using Yuebon.Commons.Log;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 定时任务服务接口实现
    /// </summary>
    public class TaskManagerService: BaseService<TaskManager,TaskManagerOutputDto, string>, ITaskManagerService
    {
		private readonly ITaskManagerRepository _repository;
        private readonly ILogService _logService;

        private IScheduler _scheduler;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public TaskManagerService(ITaskManagerRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }


        /// <summary>
        /// 记录任务运行结果
        /// </summary>
        /// <param name="jobId">任务Id</param>
        /// <param name="blresultTag">任务执行结果表示，true成功，false失败，初始执行为true</param>
        public void RecordRun(string jobId,bool blresultTag=true)
        {
            var job = _repository.Get(jobId);
            if (job == null)
            {
                _logService.Insert(new Log
                {
                    Date=DateTime.Now,
                    Type = "定时任务",
                    ModuleName = "AUTOJOB",
                    Description = $"未能找到定时任务：{jobId}"
                });;
                return;
            }

            if (!blresultTag)
            {
                job.ErrorCount++;
                job.LastErrorTime= DateTime.Now;
            }
            else
            {
                job.RunCount++;
                job.LastRunTime = DateTime.Now;
            }
            _repository.Update(job,jobId);

            _logService.Insert(new Log
            {
                Date = DateTime.Now,
                Type = "定时任务",
                ModuleName = "AUTOJOB",
                Description = $"运行了自动任务：{job.TaskName}"
            });
            Log4NetHelper.Info($"运行了自动任务：{job.TaskName}");
        }

    }
}