using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 过滤IP，数据实体对象
    /// </summary>

    [SugarTable("Sys_FilterIP","可访问系统IP地址黑白名单")]
    [Serializable]
    public class FilterIP : BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>

        public FilterIP()
		{

 		}

        #region Property Members


        /// <summary>
        /// 类型
        /// </summary>
        [SugarColumn(ColumnDescription= "类型，0黑名单，1白名单")]
        public virtual bool? FilterType { get; set; }

        /// <summary>
        /// 开始IP
        /// </summary>
        [MaxLength(40)]
        [SugarColumn(ColumnDescription= "开始IP")]
        [Required]
        public virtual string StartIP { get; set; }

        /// <summary>
        /// 结束IP
        /// </summary>
        [MaxLength(40)]
        [SugarColumn(ColumnDescription= "结束IP")]
        [Required]
        public virtual string EndIP { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [SugarColumn(ColumnDescription= "排序码")]
        public virtual int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [SugarColumn(ColumnDescription= "描述")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnDescription= "删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [SugarColumn(ColumnDescription= "有效标志")]
        public virtual bool EnabledMark { get; set; }

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

        #endregion

    }
}