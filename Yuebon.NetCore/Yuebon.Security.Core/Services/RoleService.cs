using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class RoleService: BaseService<Role, string>, IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly ILogService _logService;
        public RoleService(IRoleRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据角色编码获取角色
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public Role GetRole(string enCode)
        {
            string where = string.Format("EnCode='{0}'",enCode);
            return _repository.GetWhere(where);
        }
    }
}