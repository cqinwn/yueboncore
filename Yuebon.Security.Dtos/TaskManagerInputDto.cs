namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 定时任务输入对象模型
    /// </summary>
    [AutoMap(typeof(TaskManager))]
    [Serializable]
    public class TaskManagerInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取任务编号
        /// </summary>
        public string? TaskCode { get; set; }

        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        public string? TaskName { get; set; }

        /// <summary>
        /// 设置或获取任务分组
        /// </summary>
        public string? GroupName { get; set; }

        /// <summary>
        /// 设置或获取结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 设置或获取开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 设置或获取CRON表达式
        /// </summary>
        public string? Cron { get; set; }

        /// <summary>
        /// 设置或获取是否是本地任务1：本地任务；0：外部接口任务
        /// </summary>
        public bool IsLocal { get; set; }

        /// <summary>
        /// 设置或获取远程调用接口url
        /// </summary>
        public string? JobCallAddress { get; set; }

        /// <summary>
        /// 设置或获取任务参数，JSON格式
        /// </summary>
        public string? JobCallParams { get; set; }

        /// <summary>
        /// 设置或获取描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 设置或获取是否邮件通知
        /// </summary>
        public int SendMail { get; set; }
        /// <summary>
        /// 设置或获取接受邮件地址
        /// </summary>
        public string? EmailAddress { get; set; }


    }
}
