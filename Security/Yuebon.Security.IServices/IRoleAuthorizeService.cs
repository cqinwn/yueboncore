namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IRoleAuthorizeService:IService<RoleAuthorize, RoleAuthorizeOutputDto>
{
    /// <summary>
    /// ���ݽ�ɫ����Ŀ���Ͳ�ѯȨ��
    /// </summary>
    /// <param name="roleIds"></param>
    /// <param name="itemType"></param>
    /// <returns></returns>
    IEnumerable<RoleAuthorize> GetListRoleAuthorizeByRoleId(string roleIds, string itemType);


    /// <summary>
    /// ��ȡ���ܲ˵�������Vue Tree����
    /// </summary>
    /// <returns></returns>
    Task<List<ModuleFunctionOutputDto>> GetAllFunctionTree();

    /// <summary>
    /// �����ɫ��Ȩ
    /// </summary>
    /// <param name="roleId">��ɫId</param>
    /// <param name="roleAuthorizesList">��ɫ����ģ��</param>
    /// <param name="roleDataList">��ɫ�ɷ�������</param>
    /// <returns>ִ�гɹ�����<c>true</c>������Ϊ<c>false</c>��</returns>
    Task<bool> SaveRoleAuthorize(long roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList);
}
