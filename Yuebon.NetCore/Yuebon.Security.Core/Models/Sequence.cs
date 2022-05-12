using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 单据编码，数据实体对象
    /// </summary>
    [SugarTable("Sys_Sequence", "单据编码")]
    [Serializable]
    public class Sequence:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取名称
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "名称")]
        [Required]
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取分隔符
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "分隔符")]
        public string SequenceDelimiter { get; set; }

        /// <summary>
        /// 设置或获取序号重置规则
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "序号重置规则")]
        public string SequenceReset { get; set; }

        /// <summary>
        /// 设置或获取步长
        /// </summary>
        [SugarColumn(ColumnDescription= "步长")]
        public int Step { get; set; }

        /// <summary>
        /// 设置或获取当前值
        /// </summary>
        [SugarColumn(ColumnDescription= "当前值")]
        public int CurrentNo { get; set; }

        /// <summary>
        /// 设置或获取当前编码
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "当前编码")]
        public string CurrentCode { get; set; }

        /// <summary>
        /// 设置或获取当前重置依赖，即最后一次获取编码的日期
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "当前重置依赖，即最后一次获取编码的日期")]
        public string CurrentReset { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [SugarColumn(ColumnDescription= "描述")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建人公司ID")]
        public long? CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建人部门ID")]
        public long? DeptId { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnDescription= "删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [SugarColumn(ColumnDescription= "有效标志")]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [SugarColumn(ColumnDescription= "创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建用户主键")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [SugarColumn(ColumnDescription= "最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "最后修改用户")]
        public virtual long? LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [SugarColumn(ColumnDescription= "删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "删除用户")]
        public virtual long? DeleteUserId { get; set; }


    }
}
