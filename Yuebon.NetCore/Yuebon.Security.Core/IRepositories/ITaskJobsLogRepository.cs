using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 定义定时任务执行日志仓储接口
    /// </summary>
    public interface ITaskJobsLogRepository:IRepository<TaskJobsLog, string>
    {
    }
}