using System;
using System.Linq;
using Yuebon.Commons.EfDbContext;
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
        }

        public ItemsDetailRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }

    }
}