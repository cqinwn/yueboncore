namespace Yuebon.Security.Repositories
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}