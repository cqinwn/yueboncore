namespace Yuebon.Security.IRepositories;

public interface IRoleDataRepository:IRepository<RoleData>
{
    /// <summary>
    /// ���ݽ�ɫ������Ȩ���ʲ�������
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<long>> GetListDeptByRole(List<long> roleIds);
}