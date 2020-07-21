using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Authorizer.IRepositories;
using Yuebon.Authorizer.IServices;
using Yuebon.Authorizer.Dtos;
using Yuebon.Authorizer.Models;

namespace Yuebon.Authorizer.Services
{
    /// <summary>
    /// 服务接口实现
    /// </summary>
    public class RegistryCodeService: BaseService<RegistryCode,RegistryCodeOutputDto, string>, IRegistryCodeService
    {
		private readonly IRegistryCodeRepository _repository;
        private readonly ILogService _logService;
        public RegistryCodeService(IRegistryCodeRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}