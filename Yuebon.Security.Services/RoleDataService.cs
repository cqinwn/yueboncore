namespace Yuebon.Security.Services;

public class RoleDataService : BaseService<RoleData, RoleDataOutputDto>, IRoleDataService
{
    private readonly IRoleDataRepository _repository;
    public RoleDataService(IRoleDataRepository roleDataRepository)
    {
        repository = roleDataRepository;
        _repository = roleDataRepository;
    }
    /// <summary>
    /// 根据角色返回授权访问部门数据
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    public List<string> GetListDeptByRole(string roleIds)
    {
        return _repository.GetListDeptByRole(roleIds);
    }
}