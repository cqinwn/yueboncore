using Yuebon.Commons.IDbContext;
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
        /// <summary>
        /// 注入EF上下文
        /// </summary>
        /// <param name="context"></param>
        public TenantRepository(IDbContextCore context) : base(context)
        {
        }
    }
}