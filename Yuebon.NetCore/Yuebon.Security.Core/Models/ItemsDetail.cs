
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 数据字典选项明细表，数据实体对象
    /// </summary>
    [SugarTable("Sys_ItemsDetail")]
    [Serializable]
    [Comment("数据字典选项明细表")]
    public class ItemsDetail: BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public ItemsDetail()
		{
            //this.Id= System.Guid.NewGuid().ToString();

 		}

        #region Property Members


        /// <summary>
        /// 主表主键
        /// </summary>
        [MaxLength(50)]
        [Comment("主表主键")]
        [Required]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [MaxLength(50)]
        [Comment("父级")]
        [Required]
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [MaxLength(50)]
        [Comment("编码")]
        [Required]
        public virtual string ItemCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        [Comment("名称")]
        [Required]
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        [MaxLength(50)]
        [Comment("简拼")]
        public virtual string SimpleSpelling { get; set; }

        /// <summary>
        /// 默认
        /// </summary>
        [Comment("默认")]
        public virtual bool? IsDefault { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [Comment("层次")]
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Comment("排序码")]
        public virtual int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [Comment("主表主键")]
        public virtual string Description { get; set; }

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
        #endregion

    }
}