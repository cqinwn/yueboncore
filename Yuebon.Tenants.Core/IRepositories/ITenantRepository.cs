using Yuebon.Commons.IRepositories;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.IRepositories
{
    /// <summary>
    /// 定义租户仓储接口
    /// </summary>
    public interface ITenantRepository:IRepository<Tenant, string>
    {
    }
}