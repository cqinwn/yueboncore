namespace Yuebon.Security.IRepositories;

public interface IAreaRepository:IRepository<Area>
{
    /// <summary>
    /// ���Ͳ�ѯ�ݹ��ѯ,��ȡ��������������Vue �����б�
    /// </summary>
    /// <returns></returns>
    Task<List<Area>> GetAllAreaTreeTable();
}