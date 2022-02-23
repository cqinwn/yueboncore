using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

using Yuebon.Commons.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 单据编码，数据实体对象
    /// </summary>
    [Table("Sys_Sequence")]
    [Serializable]
    [Comment("单据编码")]
    public class Sequence:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取名称
        /// </summary>
        [MaxLength(50)]
        [Comment("名称")]
        [Required]
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取分隔符
        /// </summary>
        [MaxLength(50)]
        [Comment("分隔符")]
        public string SequenceDelimiter { get; set; }

        /// <summary>
        /// 设置或获取序号重置规则
        /// </summary>
        [MaxLength(50)]
        [Comment("序号重置规则")]
        public string SequenceReset { get; set; }

        /// <summary>
        /// 设置或获取步长
        /// </summary>
        [Comment("步长")]
        public int Step { get; set; }

        /// <summary>
        /// 设置或获取当前值
        /// </summary>
        [Comment("当前值")]
        public int CurrentNo { get; set; }

        /// <summary>
        /// 设置或获取当前编码
        /// </summary>
        [MaxLength(50)]
        [Comment("当前编码")]
        public string CurrentCode { get; set; }

        /// <summary>
        /// 设置或获取当前重置依赖，即最后一次获取编码的日期
        /// </summary>
        [MaxLength(50)]
        [Comment("当前重置依赖，即最后一次获取编码的日期")]
        public string CurrentReset { get; set; }

        /// <summary>
        /// 描述
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
        /// 删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Comment("创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Comment("最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        [Comment("最后修改用户")]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Comment("删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        [Comment("删除用户")]
        public virtual string DeleteUserId { get; set; }


    }
}
