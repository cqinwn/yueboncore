using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 序号编码规则表，数据实体对象
    /// </summary>
    [SugarTable("Sys_SequenceRule")]
    [Comment("序号编码规则表")]
    [Serializable]
    public class SequenceRule:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取编码规则名称
        /// </summary>
        [MaxLength(50)]
        [Comment("编码规则名称")]
        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取规则排序
        /// </summary>
        [Comment("规则排序")]
        public int RuleOrder { get; set; }

        /// <summary>
        /// 设置或获取规则类别，timestamp、const、bumber
        /// </summary>
        [MaxLength(50)]
        [Comment("取规则类别，timestamp、const、bumber")]
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string RuleType { get; set; }

        /// <summary>
        /// 设置或获取规则参数，如YYMMDD
        /// </summary>
        [MaxLength(50)]
        [Comment("规则参数，如YYMMDD")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string RuleValue { get; set; }

        /// <summary>
        /// 设置或获取补齐方向，left或right
        /// </summary>
        [MaxLength(50)]
        [Comment("补齐方向，left或right")]
        [Required]
        public string PaddingSide { get; set; }

        /// <summary>
        /// 设置或获取补齐宽度
        /// </summary>
        [Comment("补齐宽度")]
        [Required]
        public int PaddingWidth { get; set; }

        /// <summary>
        /// 设置或获取填充字符
        /// </summary>
        [MaxLength(50)]
        [Comment("填充字符")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string PaddingChar { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [Comment("描述")]
        [Column(TypeName = "NVARCHAR(500)")]
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
        public virtual bool EnabledMark { get; set; }

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
