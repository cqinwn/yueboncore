using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Yuebon.Commons.EfDbContext;
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
            this.tableName = "Sys_Tenant";
            this.primaryKey = "Id";
        }

        public TenantRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "Sys_Tenant";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public override async Task<long> InsertAsync(Tenant entity, IDbTransaction trans = null)
        {
            return await InsertEFAsync(entity, trans);
        }

        /// <summary>
        /// 根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public override Tenant Get(string primaryKey, IDbTransaction trans = null)
        {
            return GetEF(primaryKey);
        }
        /// <summary>
        /// 异步根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public override async Task<Tenant> GetAsync(string primaryKey, IDbTransaction trans = null)
        {
            return await GetEFAsync(primaryKey);
        }
    }
}