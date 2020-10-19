using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class ArticleStarRepository : BaseRepository<ArticleStar, string>, IArticleStarRepository
    {
		public ArticleStarRepository()
        {
            this.tableName = "CMS_ArticleStar";
            this.primaryKey = "Id";
        }
        public ArticleStarRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_ArticleStar";
            this.primaryKey = "Id";
        }
    }
}