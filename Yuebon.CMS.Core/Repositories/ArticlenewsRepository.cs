
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;

namespace Yuebon.CMS.Repositories
{
    /// <summary>
    /// 文章仓储接口的实现
    /// </summary>
    public class ArticlenewsRepository : BaseRepository<Articlenews>, IArticlenewsRepository
    {

        public ArticlenewsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}