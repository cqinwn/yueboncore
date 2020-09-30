using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义定时任务执行日志服务接口
    /// </summary>
    public interface ITaskJobsLogService:IService<TaskJobsLog,TaskJobsLogOutputDto, string>
    {
    }
}
