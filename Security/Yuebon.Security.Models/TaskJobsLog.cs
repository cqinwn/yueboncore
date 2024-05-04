namespace Yuebon.Security.Models
{
    /// <summary>
    /// 定时任务执行日志，数据实体对象
    /// </summary>
    [SugarTable("Sys_Task_Jobs_Log", "定时任务执行日志")]
    [Serializable]
    public class TaskJobsLog:BaseEntity
    {
        public TaskJobsLog()
        {
        }

        /// <summary>
        /// 设置或获取任务Id
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="任务Id")]
        public long TaskId { get; set; }

        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="任务名称")]
        public string TaskName { get; set; }

        /// <summary>
        /// 设置或获取执行动作
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="执行动作")]
        public string JobAction { get; set; }

        /// <summary>
        /// 设置或获取执行状态 正常、异常
        /// </summary>
        [SugarColumn(ColumnDescription="执行状态 正常、异常")]
        public bool Status { get; set; }

        /// <summary>
        /// 设置或获取结果描述
        /// </summary>
        [SugarColumn(ColumnDescription = "简述", Length = 500)]
        public string Resume { get; set; }

        /// <summary>
        /// 设置或获取结果描述
        /// </summary>
        [SugarColumn(ColumnDescription = "描述", ColumnDataType = "varchar(max)")]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        [SugarColumn(ColumnDescription="创建时间")]
        public DateTime CreatorTime { get; set; }


    }
}
