using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class AdvertRepository : BaseRepository<Advert, string>, IAdvertRepository
    {
		public AdvertRepository()
        {
            this.tableName = "CMS_Advert";
            this.primaryKey = "Id";
        }
    }
}