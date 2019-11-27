using System;

using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleAuthorizeRepository : BaseRepository<RoleAuthorize, string>, IRoleAuthorizeRepository
    {
        public RoleAuthorizeRepository()
        {
            this.tableName = "Sys_RoleAuthorize";
            this.primaryKey = "Id";
        }
    }
}