namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 用户登录信息仓储接口的实现
    /// </summary>
    public class TenantLogonRepository : BaseRepository<TenantLogon>, ITenantLogonRepository
    {

        public TenantLogonRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        /// <summary>
        /// 根据租户ID获取租户登录信息实体
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public TenantLogon GetByTenantId(long tenantId)
        {
            string sql = $"SELECT * FROM {this.tableName} t WHERE t.TenantId = @TenantId";
            return Db.Ado.SqlQuerySingle<TenantLogon>(sql, new { @TenantId = tenantId });
        }

    }
}