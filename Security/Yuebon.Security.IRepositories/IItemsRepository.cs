namespace Yuebon.Security.IRepositories;

public interface IItemsRepository:IRepository<Items>
{
    /// <summary>
    /// 根据编码查询字典分类
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
   Task<Items> GetByEnCodAsynce(string enCode);
    /// <summary>
    /// 更新时判断分类编码是否存在（排除自己）
    /// </summary>
    /// <param name="enCode">分类编码</param
    /// <param name="id">主键Id</param>
    /// <returns></returns>
    Task<Items> GetByEnCodAsynce(string enCode, long id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<Items>> GetAllItemsTreeTable();
}