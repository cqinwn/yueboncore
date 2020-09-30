using System;

using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 定时任务仓储接口的实现
    /// </summary>
    public class TaskManagerRepository : BaseRepository<TaskManager, string>, ITaskManagerRepository
    {
		public TaskManagerRepository()
        {
            this.tableName = "Sys_TaskManager";
            this.primaryKey = "Id";
        }
    }
}