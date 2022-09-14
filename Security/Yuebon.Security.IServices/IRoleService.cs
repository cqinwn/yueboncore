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
