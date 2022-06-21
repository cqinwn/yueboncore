namespace Yuebon.Security.IRepositories;

public interface IRoleAuthorizeRepository:IRepository<RoleAuthorize>
{
    /// <summary>
    /// �����ɫ��Ȩ
    /// </summary>
    /// <param name="roleId">��ɫId</param>
    /// <param name="roleAuthorizesList">��ɫ����ģ��</param>
    /// <param name="roleDataList">��ɫ�ɷ�������</param>
    /// <returns>ִ�гɹ�����<c>true</c>������Ϊ<c>false</c>��</returns>
    Task<bool> SaveRoleAuthorize(long roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList);
}