using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Quartz.Dtos
{

    /// <summary>
    /// 定时任务执行日志输出对象模型
    /// </summary>
    [Serializable]
    public class TaskJobsLogVueTimelineOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

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
        /// 设置或获取颜色
        /// </summary>
        public string Color { get; set; }


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
