namespace Yuebon.Security.IServices;

public interface IRoleDataService:IService<RoleData, RoleDataOutputDto>
{

    /// <summary>
    /// 根据角色返回授权访问部门数据
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<long>> GetListDeptByRole(List<long> roleIds);
}
