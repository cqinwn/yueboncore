using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 定时任务执行日志服务接口实现
    /// </summary>
    public class TaskJobsLogService: BaseService<TaskJobsLog,TaskJobsLogOutputDto, string>, ITaskJobsLogService
    {
		private readonly ITaskJobsLogRepository _repository;
        private readonly ILogService _logService;
        public TaskJobsLogService(ITaskJobsLogRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}