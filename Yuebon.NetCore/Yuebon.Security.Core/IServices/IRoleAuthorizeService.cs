using System;
using System.Collections.Generic;
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
    }
}
