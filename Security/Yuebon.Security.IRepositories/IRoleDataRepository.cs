namespace Yuebon.Security.IRepositories;

public interface IRoleDataRepository:IRepository<RoleData>
{
    /// <summary>
    /// 根据角色返回授权访问部门数据
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<long>> GetListDeptByRole(List<long> roleIds);
}