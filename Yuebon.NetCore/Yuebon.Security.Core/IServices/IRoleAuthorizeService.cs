using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleAuthorizeService:IService<RoleAuthorize, RoleAuthorizeOutputDto, string>
    {
        /// <summary>
        /// 根据角色和项目类型查询权限
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        IEnumerable<RoleAuthorize> GetListRoleAuthorizeByRoleId(string roleIds, int itemType);


        /// <summary>
        /// 获取功能菜单适用于Vue Tree树形
        /// </summary>
        /// <returns></returns>
        Task<List<ModuleFunctionOutputDto>> GetAllFunctionTree();

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
