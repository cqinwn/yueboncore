namespace Yuebon.Security.IServices;

public interface IRoleDataService:IService<RoleData, RoleDataOutputDto>
{

    /// <summary>
    /// 根据角色返回授权访问部门数据
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    List<string> GetListDeptByRole(string roleIds);
}
