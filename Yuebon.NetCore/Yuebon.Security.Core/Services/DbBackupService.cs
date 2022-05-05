using System;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class DbBackupService: BaseService<DbBackup, DbBackupOutputDto>, IDbBackupService
    {
        private readonly IDbBackupRepository _repository;
        private readonly ILogService _logService;
        public DbBackupService(IDbBackupRepository dbBackupRepository, ILogService logService)
        {
            repository=dbBackupRepository;
            _repository = dbBackupRepository;
            _logService = logService;
        }
    }
}