using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class ItemsDetailRepository : BaseRepository<ItemsDetail>, IItemsDetailRepository
    {
        public ItemsDetailRepository()
        {
        }

        public ItemsDetailRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

    }
}