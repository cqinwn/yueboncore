using Quartz;
using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义定时任务服务接口
    /// </summary>
    public interface ITaskManagerService:IService<TaskManager,TaskManagerOutputDto, string>
    {
        /// <summary>
        /// 记录任务运行结果
        /// </summary>
        /// <param name="jobId">任务Id</param>
        /// <param name="blresultTag">任务执行结果表示，true成功，false失败，初始执行为true</param>
        void RecordRun(string jobId, bool blresultTag = true);

    }
}
