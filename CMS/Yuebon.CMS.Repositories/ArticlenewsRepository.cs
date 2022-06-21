namespace Yuebon.CMS.Repositories;

/// <summary>
/// 文章仓储接口的实现
/// </summary>
public class ArticlenewsRepository : BaseRepository<Articlenews>, IArticlenewsRepository
{

    public ArticlenewsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}