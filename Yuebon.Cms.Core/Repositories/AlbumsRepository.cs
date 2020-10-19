using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class AlbumsRepository : BaseRepository<Albums, string>, IAlbumsRepository
    {
		public AlbumsRepository()
        {
            this.tableName = "CMS_Albums";
            this.primaryKey = "Id";
        }

        public AlbumsRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_Albums";
            this.primaryKey = "Id";
        }
    }
}