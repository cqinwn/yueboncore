using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class ItemsDetailRepository : BaseRepository<ItemsDetail>, IItemsDetailRepository
    {
        public ItemsDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}