using System;

using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class ItemsRepository : BaseRepository<Items, string>, IItemsRepository
    {
        public ItemsRepository()
        {
            this.tableName = "Sys_Items";
            this.primaryKey = "Id";
        }
    }
}