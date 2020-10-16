using System;

using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 租户仓储接口的实现
    /// </summary>
    public class TentantRepository : BaseRepository<Tentant, string>, ITentantRepository
    {
		public TentantRepository()
        {
            this.tableName = "Sys_Tentant";
            this.primaryKey = "Id";
        }
    }
}