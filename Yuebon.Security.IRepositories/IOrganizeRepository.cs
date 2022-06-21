namespace Yuebon.Security.IRepositories;

/// <summary>
/// ��֯�ִ��ӿ�
/// �����õ���Organizeҵ��������������
/// </summary>
public interface IOrganizeRepository:IRepository<Organize>
{
    /// <summary>
    /// ��ȡ���ڵ���֯
    /// </summary>
    /// <param name="id">��֯Id</param>
    /// <returns></returns>
    Organize GetRootOrganize(long? id);
    /// <summary>
    /// ���Ͳ�ѯ�ݹ��ѯ
    /// </summary>
    /// <returns></returns>
    Task<List<Organize>> GetAllOrganizeTreeTable();
}