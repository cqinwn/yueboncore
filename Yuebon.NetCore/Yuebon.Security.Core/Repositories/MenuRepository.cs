using System;
using System.Collections.Generic;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class MenuRepository : BaseRepository<Menu, string>, IMenuRepository
    {
        public MenuRepository()
        {
        }

        public MenuRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}