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
    public async Task<List<long>> GetListDeptByRole(List<long> roleIds)
    {
        return await _repository.GetListDeptByRole(roleIds);
    }
}