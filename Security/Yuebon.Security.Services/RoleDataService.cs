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
    /// ���ݽ�ɫ������Ȩ���ʲ�������
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    public List<string> GetListDeptByRole(string roleIds)
    {
        return _repository.GetListDeptByRole(roleIds);
    }
}