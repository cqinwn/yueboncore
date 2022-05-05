using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}