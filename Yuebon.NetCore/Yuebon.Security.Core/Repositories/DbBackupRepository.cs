using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class DbBackupRepository : BaseRepository<DbBackup>, IDbBackupRepository
    {
        public DbBackupRepository()
        {
        }

        public DbBackupRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}