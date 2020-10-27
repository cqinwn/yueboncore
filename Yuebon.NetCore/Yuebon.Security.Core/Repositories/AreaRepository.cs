using System;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class AreaRepository : BaseRepository<Area, string>, IAreaRepository
    {
        public AreaRepository()
        {
        }

        public AreaRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}