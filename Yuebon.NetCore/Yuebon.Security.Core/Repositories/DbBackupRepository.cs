using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class DbBackupRepository : BaseRepository<DbBackup>, IDbBackupRepository
    {
        public DbBackupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}