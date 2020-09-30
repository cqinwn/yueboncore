using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 定时任务执行日志，数据实体对象
    /// </summary>
    [Table("Sys_TaskJobsLog")]
    [Serializable]
    public class TaskJobsLog:BaseEntity<string>
    {
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
