namespace Yuebon.Security.IServices;

public interface IRoleDataService:IService<RoleData, RoleDataOutputDto>
{

    /// <summary>
    /// ���ݽ�ɫ������Ȩ���ʲ�������
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<long>> GetListDeptByRole(List<long> roleIds);
}
