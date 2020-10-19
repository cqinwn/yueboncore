using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class ArticleCommentsGoodRepository : BaseRepository<ArticleCommentsGood, string>, IArticleCommentsGoodRepository
    {
		public ArticleCommentsGoodRepository()
        {
            this.tableName = "CMS_ArticleCommentsGood";
            this.primaryKey = "Id";
        }
        public ArticleCommentsGoodRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_ArticleCommentsGood";
            this.primaryKey = "Id";
        }
    }
}