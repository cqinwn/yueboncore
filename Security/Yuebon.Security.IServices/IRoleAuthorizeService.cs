using Yuebon.Commons.Enums;

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
    Task<List<RoleAuthorize>> GetListRoleAuthorizeByRoleId(List<long> roleIds, List<int> itemType);


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
    /// <param name="roleDataScope">��ɫ�ɷ������ݷ�Χ</param>
    /// <returns>ִ�гɹ�����<c>true</c>������Ϊ<c>false</c>��</returns>
    Task<bool> SaveRoleAuthorize(long roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList, int roleDataScope);
}
