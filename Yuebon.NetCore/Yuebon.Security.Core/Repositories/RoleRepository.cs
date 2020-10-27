using System;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleRepository : BaseRepository<Role, string>, IRoleRepository
    {
        public RoleRepository()
        {
        }

        public RoleRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}