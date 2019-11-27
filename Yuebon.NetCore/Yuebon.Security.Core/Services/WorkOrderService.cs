using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class WorkOrderService: BaseService<WorkOrder, string>, IWorkOrderService
    {
		private readonly IWorkOrderRepository _repository;
        private readonly ILogService logService;
        public WorkOrderService(IWorkOrderRepository repository, ILogService _logService) : base(repository)
        {
            _repository = repository;
			logService=_logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}