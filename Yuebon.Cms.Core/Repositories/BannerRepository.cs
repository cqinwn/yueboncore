using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using System.Collections.Generic;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class BannerRepository : BaseRepository<Banner, string>, IBannerRepository
    {
		public BannerRepository()
        {
            this.tableName = "CMS_Banner";
            this.primaryKey = "Id";
        }

        public BannerRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_Banner";
            this.primaryKey = "Id";
        }
    }
}