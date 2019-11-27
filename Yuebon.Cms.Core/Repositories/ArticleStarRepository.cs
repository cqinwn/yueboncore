using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class ArticleStarRepository : BaseRepository<ArticleStar, string>, IArticleStarRepository
    {
		public ArticleStarRepository()
        {
            this.tableName = "CMS_ArticleStar";
            this.primaryKey = "Id";
        }
    }
}