using System;

using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class FilterIPRepository : BaseRepository<FilterIP, string>, IFilterIPRepository
    {
        public FilterIPRepository()
        {
            this.tableName = "Sys_FilterIP";
            this.primaryKey = "Id";
        }
    }
}