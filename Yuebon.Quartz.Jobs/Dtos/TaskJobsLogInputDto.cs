using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;
using Yuebon.Quartz.Models;
using Yuebon.Security.Models;

namespace Yuebon.Quartz.Dtos
{
    /// <summary>
    /// 定时任务执行日志输入对象模型
    /// </summary>
    [AutoMap(typeof(TaskJobsLog))]
    [Serializable]
    public class TaskJobsLogInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取任务Id
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 设置或获取任务执行动作开始、暂停、结束
        /// </summary>
        public string JobAction { get; set; }
        /// <summary>
        /// 设置或获取执行状态 成功、是啊比阿
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 设置或获取结果描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime CreatorTime { get; set; }


    }
}
