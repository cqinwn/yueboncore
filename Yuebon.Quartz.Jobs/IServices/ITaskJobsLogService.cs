using System;
using Yuebon.Commons.IServices;
using Yuebon.Quartz.Dtos;
using Yuebon.Quartz.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.IServices
{
    /// <summary>
    /// 定义定时任务执行日志服务接口
    /// </summary>
    public interface ITaskJobsLogService:IService<TaskJobsLog,TaskJobsLogOutputDto, string>
    {
    }
}
