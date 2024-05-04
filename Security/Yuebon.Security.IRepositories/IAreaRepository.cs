namespace Yuebon.Security.IRepositories;

public interface IAreaRepository:IRepository<Area>
{
    /// <summary>
    /// 树型查询递归查询,获取行政地区适用于Vue 树形列表
    /// </summary>
    /// <returns></returns>
    Task<List<Area>> GetAllAreaTreeTable();
}