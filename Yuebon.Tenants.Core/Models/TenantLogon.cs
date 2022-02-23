using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Yuebon.Tenants.Models
{
    /// <summary>
    /// 租户用户登录信息，数据实体对象
    /// </summary>
    [Table("Sys_TenantLogon")]
    [Comment("租户信息表")]
    [Serializable]
    public class TenantLogon:BaseEntity
    {
        /// <summary>
        /// 设置或获取租户ID
        /// </summary>
        [MaxLength(50)]
        [Comment("租户ID")]
        public string TenantId { get; set; }

        /// <summary>
        /// 设置或获取密码
        /// </summary>
        [MaxLength(50)]
        [Comment("租户ID")]
        public string TenantPassword { get; set; }

        /// <summary>
        /// 设置或获取加密密钥
        /// </summary>
        [MaxLength(50)]
        [Comment("租户ID")]
        public string TenantSecretkey { get; set; }

        /// <summary>
        /// 设置或获取允许登录时间开始
        /// </summary>
        [Comment("允许登录时间开始")]
        public virtual DateTime? AllowStartTime { get; set; }

        /// <summary>
        /// 设置或获取允许登录时间结束
        /// </summary>
        [Comment("允许登录时间结束")]
        public virtual DateTime? AllowEndTime { get; set; }

        /// <summary>
        /// 设置或获取暂停用户开始日期
        /// </summary>
        [Comment("暂停用户开始日期")]
        public virtual DateTime? LockStartDate { get; set; }

        /// <summary>
        /// 设置或获取暂停用户结束日期
        /// </summary>
        [Comment("暂停用户结束日期")]
        public virtual DateTime? LockEndDate { get; set; }

        /// <summary>
        /// 设置或获取第一次访问时间
        /// </summary>
        [Comment("第一次访问时间")]
        public virtual DateTime? FirstVisitTime { get; set; }

        /// <summary>
        /// 设置或获取上一次访问时间
        /// </summary>
        [Comment("上一次访问时间")]
        public virtual DateTime? PreviousVisitTime { get; set; }

        /// <summary>
        /// 设置或获取最后访问时间
        /// </summary>
        [Comment("最后访问时间")]
        public virtual DateTime? LastVisitTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改密码日期
        /// </summary>
        [Comment("最后修改密码日期")]
        public virtual DateTime? ChangePasswordDate { get; set; }

        /// <summary>
        /// 设置或获取允许同时有多用户登录
        /// </summary>
        [Comment("允许同时有多用户登录")]
        public virtual bool? MultiUserLogin { get; set; }

        /// <summary>
        /// 设置或获取登录次数
        /// </summary>
        [Comment("登录次数")]
        public virtual int? LogOnCount { get; set; }

        /// <summary>
        /// 设置或获取在线状态
        /// </summary>
        [Comment("在线状态")]
        public virtual bool? TenantOnLine { get; set; }


        /// <summary>
        /// 设置或获取密码提示问题
        /// </summary>
        [MaxLength(200)]
        [Comment("密码提示问题")]
        public virtual string Question { get; set; }

        /// <summary>
        /// 设置或获取密码提示答案
        /// </summary>
        [MaxLength(200)]
        [Comment("密码提示答案")]
        public virtual string AnswerQuestion { get; set; }

        /// <summary>
        /// 设置或获取是否访问限制
        /// </summary>
        [Comment("是否访问限制")]
        public virtual bool? CheckIPAddress { get; set; }

        /// <summary>
        /// 设置或获取软件系统语言
        /// </summary>
        [MaxLength(50)]
        [Comment("软件系统语言")]
        public virtual string Language { get; set; }

        /// <summary>
        /// 设置或获取软件系统样式
        /// </summary>
        [MaxLength(50)]
        [Comment("软件系统样式")]
        public virtual string Theme { get; set; }


    }
}
