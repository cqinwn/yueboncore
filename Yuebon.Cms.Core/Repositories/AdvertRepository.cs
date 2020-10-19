using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class AdvertRepository : BaseRepository<Advert, string>, IAdvertRepository
    {
		public AdvertRepository()
        {
            this.tableName = "CMS_Advert";
            this.primaryKey = "Id";
        }
        public AdvertRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_Advert";
            this.primaryKey = "Id";
        }
    }
}