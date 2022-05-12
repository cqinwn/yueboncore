using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Tenants.Dtos
{
    /// <summary>
    /// 用户登录信息输出对象模型
    /// </summary>
    [Serializable]
    public class TenantLogonOutputDto
    {
        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(50)]
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(50)]
        public string TenantId { get; set; }

        /// <summary>
        /// 设置或获取密码
        /// </summary>
        [MaxLength(50)]
        public string TenantPassword { get; set; }

        /// <summary>
        /// 设置或获取加密密钥
        /// </summary>
        [MaxLength(50)]
        public string TenantSecretkey { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? AllowStartTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? AllowEndTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? LockStartDate { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? LockEndDate { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? FirstVisitTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? PreviousVisitTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? LastVisitTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? ChangePasswordDate { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? MultiUserLogin { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public int? LogOnCount { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? TenantOnLine { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(50)]
        public string Question { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(500)]
        public string AnswerQuestion { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? CheckIPAddress { get; set; }

        /// <summary>
        /// 设置或获取软件语言
        /// </summary>
        [MaxLength(50)]
        public string Language { get; set; }

        /// <summary>
        /// 设置或获取软件风格设置信息
        /// </summary>
        [MaxLength(16777215)]
        public string Theme { get; set; }


    }
}
