namespace Yuebon.Security.Services
{
    public class DbBackupService: BaseService<DbBackup, DbBackupOutputDto>, IDbBackupService
    {
        private readonly IRepository<DbBackup> _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbBackupRepository"></param>
        public DbBackupService(IRepository<DbBackup> dbBackupRepository)
        {
            repository=dbBackupRepository;
            _repository = dbBackupRepository;
        }
    }
}