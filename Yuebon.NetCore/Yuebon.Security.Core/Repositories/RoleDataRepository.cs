using System;

using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleDataRepository : BaseRepository<RoleData, string>, IRoleDataRepository
    {
		public RoleDataRepository()
        {
            this.tableName = "Sys_RoleData";
            this.primaryKey = "Id";
        }
    }
}