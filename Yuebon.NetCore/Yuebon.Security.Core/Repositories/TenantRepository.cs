using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 租户仓储接口的实现
    /// </summary>
    public class TenantRepository : BaseRepository<Tenant, string>, ITenantRepository
    {
		public TenantRepository()
        {
        }

        public TenantRepository(IDbContextCore context) : base(context)
        {
        }
    }
}