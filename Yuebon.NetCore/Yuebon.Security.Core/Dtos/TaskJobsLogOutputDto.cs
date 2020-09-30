using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 定时任务执行日志输出对象模型
    /// </summary>
    [Serializable]
    public class TaskJobsLogOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取任务Id
        /// </summary>
        [MaxLength(50)]
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
        [MaxLength(2147483647)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime CreatorTime { get; set; }


    }
}
