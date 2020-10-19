using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class PageNewsRepository : BaseRepository<PageNews, string>, IPageNewsRepository
    {
		public PageNewsRepository()
        {
            this.tableName = "CMS_PageNews";
            this.primaryKey = "Id";
        }
        public PageNewsRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_PageNews";
            this.primaryKey = "Id";
        }
    }
}