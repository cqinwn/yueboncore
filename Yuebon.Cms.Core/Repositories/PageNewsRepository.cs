using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class PageNewsRepository : BaseRepository<PageNews, string>, IPageNewsRepository
    {
		public PageNewsRepository()
        {
            this.tableName = "CMS_PageNews";
            this.primaryKey = "Id";
        }
    }
}