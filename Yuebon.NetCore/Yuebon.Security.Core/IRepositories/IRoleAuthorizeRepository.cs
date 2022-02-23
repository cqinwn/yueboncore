using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface IRoleAuthorizeRepository:IRepository<RoleAuthorize>
    {
        /// <summary>
        /// 保存角色授权
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="roleAuthorizesList">角色功能模块</param>
        /// <param name="roleDataList">角色可访问数据</param>
        /// <param name="trans"></param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        Task<bool> SaveRoleAuthorize(string roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList,
           IDbTransaction trans = null);
    }
}