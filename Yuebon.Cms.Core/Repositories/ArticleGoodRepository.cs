using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class ArticleGoodRepository : BaseRepository<ArticleGood, string>, IArticleGoodRepository
    {
		public ArticleGoodRepository()
        {
            this.tableName = "CMS_ArticleGood";
            this.primaryKey = "Id";
        }
    }
}