namespace Yuebon.CMS.Repositories;

/// <summary>
/// 文章分类仓储接口的实现
/// </summary>
public class ArticlecategoryRepository : BaseRepository<Articlecategory>, IArticlecategoryRepository
{

    public ArticlecategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}