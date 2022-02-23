
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Quartz.Models
{
    /// <summary>
    /// 定时任务，数据实体对象
    /// </summary>
    [Table("Sys_TaskManager")]
    [Comment("定时任务")]
    [Serializable]
    public class TaskManager:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskManager()
        {
            this.RunCount = 0;
            this.ErrorCount = 0;
            this.NextRunTime = DateTime.Now;
            this.LastRunTime = DateTime.Now;
            this.JobCallParams = string.Empty;
            this.Cron = string.Empty;
            this.Status = 0;
            this.CompanyId = "";
            this.DeptId = "";
            this.DeleteUserId = "";
        }

        /// <summary>
        /// 设置或获取 主键Id
        /// </summary>
        [Key]
        [MaxLength(50)]
        [Comment("主键Id")]
        public override string Id { get; set; }
        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        [MaxLength(50)]
        [Comment("任务名称")]
        public string TaskName { get; set; }

        /// <summary>
        /// 设置或获取任务分组
        /// </summary>
        [MaxLength(50)]
        [Comment("任务分组")]
        public string GroupName { get; set; }

        /// <summary>
        /// 设置或获取结束时间
        /// </summary>
        [Comment("结束时间")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 设置或获取开始时间
        /// </summary>
        [Comment("开始时间")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 设置或获取CRON表达式
        /// </summary>
        [MaxLength(100)]
        [Comment("CRON表达式")]
        public string Cron { get; set; }

        /// <summary>
        /// 设置或获取是否是本地任务1：本地任务；0：外部接口任务
        /// </summary>
        [Comment("是否是本地任务1：本地任务；0：外部接口任务")]
        public bool IsLocal { get; set; }

        /// <summary>
        /// 设置或获取远程调用接口url
        /// </summary>
        [MaxLength(250)]
        [Comment("远程调用接口url")]
        public string JobCallAddress { get; set; }

        /// <summary>
        /// 设置或获取任务参数，JSON格式
        /// </summary>
        [MaxLength(2000)]
        [Comment("任务参数，JSON格式")]
        public string JobCallParams { get; set; }

        /// <summary>
        /// 设置或获取最后一次执行时间
        /// </summary>
        [Comment("最后一次执行时间")]
        public DateTime? LastRunTime { get; set; }

        /// <summary>
        /// 设置或获取最后一次失败时间
        /// </summary>
        [Comment("最后一次失败时间")]
        public DateTime? LastErrorTime { get; set; }

        /// <summary>
        /// 设置或获取下次执行时间
        /// </summary>
        [Comment("下次执行时间")]
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// 设置或获取执行次数
        /// </summary>
        [Comment("执行次数")]
        public int RunCount { get; set; }

        /// <summary>
        /// 设置或获取异常次数
        /// </summary>
        [Comment("异常次数")]
        public int ErrorCount { get; set; }


        /// <summary>
        /// 设置或获取状态，0-暂停，1-启用
        /// </summary>
        [Comment("状态，0-暂停，1-启用")]
        public int Status { get; set; }

        /// <summary>
        /// 设置或获取是否邮件通知
        /// </summary>
        [Comment("是否邮件通知")]
        public int SendMail { get; set; }
        /// <summary>
        /// 设置或获取接受邮件地址
        /// </summary>
        [MaxLength(200)]
        [Comment("接受邮件地址")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 设置或获取 描述
        /// </summary>
        [MaxLength(500)]
        [Comment("描述")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人公司ID")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人部门ID")]
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取创建日期
        /// </summary>
        [Comment("创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        [Comment("最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改用户
        /// </summary>
        [MaxLength(50)]
        [Comment("最后修改用户")]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        ///设置或获取 删除时间
        /// </summary>
        [Comment("删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除用户
        /// </summary>
        [MaxLength(50)]
        [Comment("删除用户")]
        public virtual string DeleteUserId { get; set; }


    }
}
