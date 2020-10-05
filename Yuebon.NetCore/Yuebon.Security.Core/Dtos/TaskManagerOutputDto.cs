using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 定时任务输出对象模型
    /// </summary>
    [Serializable]
    public class TaskManagerOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        [MaxLength(300)]
        public string TaskName { get; set; }

        /// <summary>
        /// 设置或获取任务分组
        /// </summary>
        [MaxLength(300)]
        public string GroupName { get; set; }

        /// <summary>
        /// 设置或获取CRON表达式
        /// </summary>
        [MaxLength(300)]
        public string Cron { get; set; }

        /// <summary>
        /// 设置或获取是否是本地任务1：本地任务；0：外部接口任务
        /// </summary>
        public bool IsLocal { get; set; }

        /// <summary>
        /// 设置或获取远程调用接口url
        /// </summary>
        [MaxLength(300)]
        public string JobCallAddress { get; set; }

        /// <summary>
        /// 设置或获取任务参数，JSON格式
        /// </summary>
        [MaxLength(300)]
        public string JobCallParams { get; set; }

        /// <summary>
        /// 设置或获取最后一次执行时间
        /// </summary>
        public DateTime? LastRunTime { get; set; }

        /// <summary>
        /// 设置或获取最后一次失败时间
        /// </summary>
        public DateTime? LastErrorTime { get; set; }

        /// <summary>
        /// 设置或获取下次执行时间
        /// </summary>
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// 设置或获取执行次数
        /// </summary>
        public int RunCount { get; set; }

        /// <summary>
        /// 设置或获取异常次数
        /// </summary>
        public int ErrorCount { get; set; }

        /// <summary>
        /// 设置或获取描述
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }


        /// <summary>
        /// 设置或获取是否邮件通知
        /// </summary>
        public bool IsSendMail { get; set; }
        /// <summary>
        /// 设置或获取接受邮件地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 设置或获取删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        [MaxLength(50)]
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取修改人
        /// </summary>
        [MaxLength(50)]
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        [MaxLength(50)]
        public string DeleteUserId { get; set; }


    }
}
