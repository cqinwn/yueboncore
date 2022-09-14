namespace Yuebon.Security.IServices;

/// <summary>
/// 定义定时任务执行日志服务接口
/// </summary>
public interface ITaskJobsLogService:IService<TaskJobsLog,TaskJobsLogOutputDto>
{
    /// <summary>
    /// 清空日志
    /// </summary>
    /// <returns></returns>
    bool ClearLog();
}
