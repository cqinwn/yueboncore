using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class ArticleCommentsGoodRepository : BaseRepository<ArticleCommentsGood, string>, IArticleCommentsGoodRepository
    {
		public ArticleCommentsGoodRepository()
        {
            this.tableName = "CMS_ArticleCommentsGood";
            this.primaryKey = "Id";
        }
    }
}