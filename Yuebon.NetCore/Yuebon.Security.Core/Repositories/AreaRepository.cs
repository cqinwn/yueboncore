using System;

using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class AreaRepository : BaseRepository<Area, string>, IAreaRepository
    {
        public AreaRepository()
        {
            this.tableName = "Sys_Area";
            this.primaryKey = "Id";
        }
    }
}