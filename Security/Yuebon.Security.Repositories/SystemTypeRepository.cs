namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 系统类型，也是子系统
    /// </summary>
    public class SystemTypeRepository : BaseRepository<SystemType>, ISystemTypeRepository
    {
        public SystemTypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 根据系统编码查询系统对象
        /// </summary>
        /// <param name="appkey">系统编码</param>
        /// <returns></returns>
        public SystemType GetByCode(string appkey)
        {
            return Db.Queryable<SystemType>().First(t=>t.EnCode==appkey);
        }

        /// <summary>
        /// 根据系统编码查询系统对象
        /// </summary>
        /// <param name="appkey">系统编码</param>
        /// <param name="tenantId">租户id</param>
        /// <returns></returns>
        public SystemType GetByCode(string appkey,long tenantId)
        {
            return Db.Queryable<SystemType>().First(t => t.EnCode == appkey && t.TenantId==tenantId);
        }
    }
}
