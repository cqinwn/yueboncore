using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class RoleAuthorizeService: BaseService<RoleAuthorize, string>, IRoleAuthorizeService
    {
        private readonly IRoleAuthorizeRepository _repository;
        private readonly ILogService _logService;
        public RoleAuthorizeService(IRoleAuthorizeRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}