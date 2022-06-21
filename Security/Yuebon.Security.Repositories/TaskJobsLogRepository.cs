using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 定时任务执行日志仓储接口的实现
    /// </summary>
    public class TaskJobsLogRepository : BaseRepository<TaskJobsLog>, ITaskJobsLogRepository
    {
        public TaskJobsLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}