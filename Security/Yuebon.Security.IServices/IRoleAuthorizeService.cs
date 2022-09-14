namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IRoleAuthorizeService:IService<RoleAuthorize, RoleAuthorizeOutputDto>
{
    /// <summary>
    /// 根据角色和项目类型查询权限
    /// </summary>
    /// <param name="roleIds"></param>
    /// <param name="itemType"></param>
    /// <returns></returns>
    IEnumerable<RoleAuthorize> GetListRoleAuthorizeByRoleId(string roleIds, string itemType);


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
    /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
    Task<bool> SaveRoleAuthorize(long roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList);
}
