using System;

using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class OrganizeRepository : BaseRepository<Organize, string>, IOrganizeRepository
    {
        public OrganizeRepository()
        {
            this.tableName = "Sys_Organize";
            this.primaryKey = "Id";
        }
    }
}