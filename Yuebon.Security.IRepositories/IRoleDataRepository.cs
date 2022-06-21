namespace Yuebon.Security.IRepositories;

public interface IRoleDataRepository:IRepository<RoleData>
{
    /// <summary>
    /// ���ݽ�ɫ������Ȩ���ʲ�������
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
   List<string> GetListDeptByRole(string roleIds);
}