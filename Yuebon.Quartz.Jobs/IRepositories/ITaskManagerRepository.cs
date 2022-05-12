using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Quartz.Models;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.IRepositories
{
    /// <summary>
    /// 定义定时任务仓储接口
    /// </summary>
    public interface ITaskManagerRepository:IRepository<TaskManager>
    {
    }
}