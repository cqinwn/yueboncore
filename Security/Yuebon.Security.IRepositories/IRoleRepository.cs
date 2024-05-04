namespace Yuebon.Security.IRepositories;

public interface  IRoleRepository:IRepository<Role>
{
    /// <summary>
    /// 根据用户ID获取角色编码
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns></returns>
   Task<List<long>> GetRoleIdsByUserId(long userId);
}
