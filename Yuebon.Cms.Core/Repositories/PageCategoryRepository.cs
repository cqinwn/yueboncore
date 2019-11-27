using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class PageCategoryRepository : BaseRepository<PageCategory, string>, IPageCategoryRepository
    {
		public PageCategoryRepository()
        {
            this.tableName = "CMS_PageCategory";
            this.primaryKey = "Id";
        }
    }
}