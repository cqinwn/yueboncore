using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;

namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    ///调度中心接口 [单例]
    /// </summary>
    public interface ISchedulerCenter
    {

        /// <summary>
        /// 开启任务调度
        /// </summary>
        /// <returns></returns>
        Task<CommonResult> StartScheduleAsync();
        /// <summary>
        /// 停止任务调度
        /// </summary>
        /// <returns></returns>
        Task<CommonResult> StopScheduleAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<CommonResult> AddScheduleJobAsync(TaskManager sysSchedule);
        /// <summary>
        /// 停止一个任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<CommonResult> StopScheduleJobAsync(TaskManager sysSchedule);
        /// <summary>
        /// 检测任务是否存在
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<bool> IsExistScheduleJobAsync(TaskManager sysSchedule);
        /// <summary>
        /// 暂停指定的计划任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<CommonResult> PauseJob(TaskManager sysSchedule);
        /// <summary>
        /// 恢复一个任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<CommonResult> ResumeJob(TaskManager sysSchedule);

        /// <summary>
        /// 获取任务触发器状态
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<List<TaskInfoDto>> GetTaskStaus(TaskManager sysSchedule);
        /// <summary>
        /// 获取触发器标识
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetTriggerState(string key);

        /// <summary>
        /// 立即执行 一个任务
        /// </summary>
        /// <param name="tasksQz"></param>
        /// <returns></returns>
        Task<CommonResult> ExecuteJobAsync(TaskManager tasksQz);

    }
}
