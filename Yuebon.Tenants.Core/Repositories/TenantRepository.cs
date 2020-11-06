using Yuebon.Commons.Repositories;
using Yuebon.Tenants.IRepositories;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Repositories
{
    /// <summary>
    /// 租户仓储接口的实现
    /// </summary>
    public class TenantRepository : BaseRepository<Tenant, string>, ITenantRepository
    {
		public TenantRepository()
        {
        }
    }
}