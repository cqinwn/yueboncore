
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 组织表，数据实体对象
    /// </summary>
    [Table("Sys_Organize")]
    [Comment("组织机构表")]
    [Serializable]
    public class Organize: BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Organize()
		{
 		}

        #region Property Members


        /// <summary>
        /// 父级
        /// </summary>
        [MaxLength(50)]
        [Comment("父级")]
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [Comment("层次")]
        [Required]
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [MaxLength(50)]
        [Comment("编码")]
        [Required]
        public virtual string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        [Comment("名称")]
        [Required]
        public virtual string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [MaxLength(50)]
        [Comment("简称")]
        public virtual string ShortName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [MaxLength(50)]
        [Comment("分类")]
        public virtual string CategoryId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [MaxLength(50)]
        [Comment("负责人")]
        public virtual string ManagerId { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(100)]
        [Comment("电话")]
        public virtual string TelePhone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(100)]
        [Comment("手机")]
        public virtual string MobilePhone { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [MaxLength(100)]
        [Comment("微信")]
        public virtual string WeChat { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [MaxLength(100)]
        [Comment("传真")]
        public virtual string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        [Comment("邮箱")]
        public virtual string Email { get; set; }

        /// <summary>
        /// 归属区域
        /// </summary>
        [MaxLength(50)]
        [Comment("归属区域")]
        public virtual string AreaId { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        [MaxLength(500)]
        [Comment("联系地址")]
        public virtual string Address { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        [Comment("允许编辑")]
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        [Comment("允许删除")]
        public virtual bool? AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Comment("排序码")]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [Comment("描述")]
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