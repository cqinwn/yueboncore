using System;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class DbBackupRepository : BaseRepository<DbBackup, string>, IDbBackupRepository
    {
        public DbBackupRepository()
        {
        }

        public DbBackupRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}