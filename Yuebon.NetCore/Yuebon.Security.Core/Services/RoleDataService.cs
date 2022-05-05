using System;
using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class RoleDataService: BaseService<RoleData, RoleDataOutputDto>, IRoleDataService
    {
		private readonly IRoleDataRepository _repository;
        private readonly ILogService _logService;
        public RoleDataService(IRoleDataRepository roleDataRepository,ILogService logService)
        {
            repository=roleDataRepository;
            _repository = roleDataRepository;
			_logService=logService;
        }
        /// <summary>
        /// 根据角色返回授权访问部门数据
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<string> GetListDeptByRole(string roleIds)
        {
            return _repository.GetListDeptByRole(roleIds);
        }
    }
}