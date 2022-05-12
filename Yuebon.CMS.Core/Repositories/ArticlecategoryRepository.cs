using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;

namespace Yuebon.CMS.Repositories
{
    /// <summary>
    /// 文章分类仓储接口的实现
    /// </summary>
    public class ArticlecategoryRepository : BaseRepository<Articlecategory>, IArticlecategoryRepository
    {

        public ArticlecategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}