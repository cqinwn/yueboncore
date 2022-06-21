namespace Yuebon.Security.IRepositories;

public interface ISystemTypeRepository : IRepository<SystemType>
{
    /// <summary>
    /// 根据系统编码查询系统对象
    /// </summary>
    /// <param name="appkey">系统编码</param>
    /// <returns></returns>
    SystemType GetByCode(string appkey);
    /// <summary>
    /// 根据系统编码查询系统对象
    /// </summary>
    /// <param name="appkey">系统编码</param>
    /// <param name="tenantId">租户id</param>
    /// <returns></returns>
    SystemType GetByCode(string appkey, long tenantId);
}
