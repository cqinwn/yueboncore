using System;
using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleAuthorizeService: BaseService<RoleAuthorize, string>, IRoleAuthorizeService
    {
        private readonly IRoleAuthorizeRepository _repository;
        private readonly ILogService _logService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public RoleAuthorizeService(IRoleAuthorizeRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }


        /// <summary>
        /// 根据角色和项目类型查询权限
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public IEnumerable<RoleAuthorize> GetListRoleAuthorizeByRoleId(string roleIds, int itemType)
        {
            IEnumerable<RoleAuthorize> list = _repository.GetListWhere(string.Format("ItemType={0} and ObjectId in ({1}) and ObjectType=1", itemType, roleIds));
            return list;
        }
    }
}