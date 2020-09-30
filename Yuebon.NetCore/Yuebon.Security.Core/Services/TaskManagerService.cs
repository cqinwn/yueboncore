using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
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
        private readonly ITaskJobsLogService _taskJobsLogService;
        /// <summary>
        /// 
        /// </summary>
        private ISchedulerFactory schedulerFactory;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        /// <param name="taskJobsLogService"></param>
        public TaskManagerService(ITaskManagerRepository repository,ILogService logService, ITaskJobsLogService taskJobsLogService, ISchedulerFactory _schedulerFactory) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _taskJobsLogService = taskJobsLogService;
            schedulerFactory = _schedulerFactory;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 记录任务运行结果
        /// </summary>
        /// <param name="jobId">任务Id</param>
        /// <param name="jobAction">任务执行动作</param>
        /// <param name="blresultTag">任务执行结果表示，true成功，false失败，初始执行为true</param>
        /// <param name="msg">任务记录描述</param>
        public void RecordRun(string jobId,JobAction jobAction, bool blresultTag = true,string msg="")
        {
            var job = _repository.Get(jobId);
            if (job == null)
            {
                _taskJobsLogService.Insert(new TaskJobsLog
                {
                    Id = GuidUtils.CreateNo(),
                    CreatorTime = DateTime.Now,
                    TaskId = jobId,
                    TaskName = "",
                    JobAction = jobAction.ToString(),
                    Status = false,
                    Description = $"未能找到定时任务：{jobId}"
                }) ; 
                return;
            }
            string resultStr = string.Empty,strDesc=string.Empty;
            if (!blresultTag)
            {
                job.ErrorCount++;
                job.LastErrorTime= DateTime.Now;
                strDesc = $"异常，"+msg;
            }
            else
            {
                strDesc = $"正常" + msg;
            }
            if (jobAction == JobAction.开始)
            {
                job.RunCount++;
                job.LastRunTime = DateTime.Now;
            }
            _repository.Update(job,jobId);

            _taskJobsLogService.Insert(new TaskJobsLog
            {
                Id = GuidUtils.CreateNo(),
                CreatorTime = DateTime.Now,
                TaskId = job.Id,
                TaskName = job.TaskName,
                JobAction = jobAction.ToString(),
                Status = blresultTag,
                Description = strDesc
            }); ;
        }

    }
}