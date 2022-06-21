namespace Yuebon.Security.IRepositories;

public interface IMenuRepository:IRepository<Menu>
{

    /// <summary>
    /// ���ݽ�ɫID�ַ��������ŷֿ�)��ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
    /// </summary>
    /// <param name="roleIds">��ɫID</param>
    /// <param name="typeID">ϵͳ����ID</param>
    /// <param name="isMenu">�Ƿ��ǲ˵�</param>
    /// <returns></returns>
    IEnumerable<Menu> GetFunctions(string roleIds, long typeID, bool isMenu = false);

    /// <summary>
    /// ����ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
    /// </summary>
    /// <param name="typeID">ϵͳ����ID</param>
    /// <returns></returns>
    IEnumerable<Menu> GetFunctions(long typeID);
}