using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class ArticleFavoriteRepository : BaseRepository<ArticleFavorite, string>, IArticleFavoriteRepository
    {
		public ArticleFavoriteRepository()
        {
            this.tableName = "CMS_ArticleFavorite";
            this.primaryKey = "Id";
        }
        public ArticleFavoriteRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_ArticleFavorite";
            this.primaryKey = "Id";
        }
    }
}