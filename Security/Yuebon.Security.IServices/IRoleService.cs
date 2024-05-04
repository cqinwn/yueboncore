namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IRoleService:IService<Role, RoleOutputDto>
{
    /// <summary>
    /// ���ݽ�ɫ�����ȡ��ɫ
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
    Role GetRole(string enCode);

    /// <summary>
    /// �����û�ID��ȡ��ɫ����
    /// </summary>
    /// <param name="userId">�û�ID</param>
    /// <returns></returns>
    Task<List<long>> GetRoleIdsByUserId(long userId);

    /// <summary>
    /// �����û���ɫID��ȡ��ɫ����
    /// </summary>
    /// <param name="ids">��ɫID�ַ������á�,���ָ�</param>
    /// <returns></returns>
    string GetRoleEnCode(string ids);


    /// <summary>
    /// �����û���ɫID��ȡ��ɫ����
    /// </summary>
    /// <param name="ids">��ɫID�ַ������á�,���ָ�</param>
    /// <returns></returns>
   string GetRoleNameStr(string ids);
}
