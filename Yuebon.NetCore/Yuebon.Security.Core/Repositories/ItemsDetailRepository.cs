using System;

using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class ItemsDetailRepository : BaseRepository<ItemsDetail, string>, IItemsDetailRepository
    {
        public ItemsDetailRepository()
        {
            this.tableName = "Sys_ItemsDetail";
            this.primaryKey = "Id";
        }
    }
}