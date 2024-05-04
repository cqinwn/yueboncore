namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IRoleService:IService<Role, RoleOutputDto>
{
    /// <summary>
    /// 根据角色编码获取角色
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
    Role GetRole(string enCode);

    /// <summary>
    /// 根据用户ID获取角色编码
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns></returns>
    Task<List<long>> GetRoleIdsByUserId(long userId);

    /// <summary>
    /// 根据用户角色ID获取角色编码
    /// </summary>
    /// <param name="ids">角色ID字符串，用“,”分格</param>
    /// <returns></returns>
    string GetRoleEnCode(string ids);


    /// <summary>
    /// 根据用户角色ID获取角色编码
    /// </summary>
    /// <param name="ids">角色ID字符串，用“,”分格</param>
    /// <returns></returns>
   string GetRoleNameStr(string ids);
}
