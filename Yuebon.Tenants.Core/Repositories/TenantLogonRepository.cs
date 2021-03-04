using Dapper;
using System;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Tenants.IRepositories;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Repositories
{
    /// <summary>
    /// 用户登录信息仓储接口的实现
    /// </summary>
    public class TenantLogonRepository : BaseRepository<TenantLogon, string>, ITenantLogonRepository
    {
		public TenantLogonRepository()
        {
        }

        public TenantLogonRepository(IDbContextCore context) : base(context)
        {

        }

        #region Dapper 操作

        //DapperConn 用于读写操作
        //DapperConnRead 用于只读操作

        /// <summary>
        /// 根据租户ID获取租户登录信息实体
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public TenantLogon GetByTenantId(string tenantId)
        {
            string sql = $"SELECT * FROM {this.tableName} t WHERE t.TenantId = @TenantId";
            return DapperConn.QueryFirst<TenantLogon>(sql, new { @TenantId = tenantId });
        }
        #endregion


        #region EF 操作

        //DbContext 用于读写操作
        //DbContextRead 用于只读操作

        #endregion
    }
}