using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

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
            string sql = @"SELECT * FROM " + this.tableName + " t WHERE t.EnCode = @EnCode";
            return Db.Ado.SqlQuerySingle<SystemType>(sql, new { EnCode = appkey });
        }
    }
}
