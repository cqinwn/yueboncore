using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 定义定时任务仓储接口
    /// </summary>
    public interface ITaskManagerRepository:IRepository<TaskManager>
    {
    }
}