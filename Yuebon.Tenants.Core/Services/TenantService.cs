using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using System.Data;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 租户服务接口实现
    /// </summary>
    public class TenantService: BaseService<Tenant,TenantOutputDto, string>, ITenantService
    {
		private readonly ITenantRepository _repository;
        private readonly ILogService _logService;
        public TenantService(ITenantRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}