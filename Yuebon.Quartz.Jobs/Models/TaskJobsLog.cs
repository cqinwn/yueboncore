using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

using Yuebon.Commons.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Yuebon.Quartz.Models
{
    /// <summary>
    /// 定时任务执行日志，数据实体对象
    /// </summary>
    [Table("Sys_TaskJobsLog")]
    [Comment("定时任务执行日志")]
    [Serializable]
    public class TaskJobsLog:BaseEntity
    {
        /// <summary>
        /// 设置或获取任务Id
        /// </summary>
        [MaxLength(50)]
        [Comment("任务Id")]
        public string TaskId { get; set; }

        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        [MaxLength(50)]
        [Comment("任务名称")]
        public string TaskName { get; set; }

        /// <summary>
        /// 设置或获取执行动作
        /// </summary>
        [MaxLength(50)]
        [Comment("执行动作")]
        public string JobAction { get; set; }

        /// <summary>
        /// 设置或获取执行状态 正常、异常
        /// </summary>
        [Comment("执行状态 正常、异常")]
        public bool Status { get; set; }

        /// <summary>
        /// 设置或获取结果描述
        /// </summary>
        [Comment("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        [Comment("创建时间")]
        public DateTime CreatorTime { get; set; }


    }
}
