using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class ArticleGoodRepository : BaseRepository<ArticleGood, string>, IArticleGoodRepository
    {
		public ArticleGoodRepository()
        {
            this.tableName = "CMS_ArticleGood";
            this.primaryKey = "Id";
        }
        public ArticleGoodRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_ArticleGood";
            this.primaryKey = "Id";
        }
    }
}