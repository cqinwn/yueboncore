using System;

using Yuebon.Commons.Repositories;
using Yuebon.Authorizer.IRepositories;
using Yuebon.Authorizer.Models;

namespace Yuebon.Authorizer.Repositories
{
    /// <summary>
    /// 仓储接口的实现
    /// </summary>
    public class RegistryCodeRepository : BaseRepository<RegistryCode, string>, IRegistryCodeRepository
    {
		public RegistryCodeRepository()
        {
            this.tableName = "Yue_RegistryCode";
            this.primaryKey = "Id";
        }
    }
}