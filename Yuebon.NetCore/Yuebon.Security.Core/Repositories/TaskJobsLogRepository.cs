using System;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 定时任务执行日志仓储接口的实现
    /// </summary>
    public class TaskJobsLogRepository : BaseRepository<TaskJobsLog, string>, ITaskJobsLogRepository
    {
		public TaskJobsLogRepository()
        {
        }

        public TaskJobsLogRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}