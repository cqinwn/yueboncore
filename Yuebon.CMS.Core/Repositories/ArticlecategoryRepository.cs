using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.IDbContext;

namespace Yuebon.CMS.Repositories
{
    /// <summary>
    /// 文章分类仓储接口的实现
    /// </summary>
    public class ArticlecategoryRepository : BaseRepository<Articlecategory>, IArticlecategoryRepository
    {
		public ArticlecategoryRepository()
        {
        }

        public ArticlecategoryRepository(IDbContextCore context) : base(context)
        {
        }
    }
}