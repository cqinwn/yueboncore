namespace Yuebon.Security.IRepositories;

public interface IItemsRepository:IRepository<Items>
{
    /// <summary>
    /// ���ݱ����ѯ�ֵ����
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
   Task<Items> GetByEnCodAsynce(string enCode);
    /// <summary>
    /// ����ʱ�жϷ�������Ƿ���ڣ��ų��Լ���
    /// </summary>
    /// <param name="enCode">�������</param
    /// <param name="id">����Id</param>
    /// <returns></returns>
    Task<Items> GetByEnCodAsynce(string enCode, long id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<Items>> GetAllItemsTreeTable();
}