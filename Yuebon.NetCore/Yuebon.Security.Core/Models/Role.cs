
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 角色表，数据实体对象
    /// </summary>
    [Table("Sys_Role")]
    [Comment("角色表")]
    public class Role: BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Role()
		{
            //this.Id= System.Guid.NewGuid().ToString();

 		}

        #region Property Members



        /// <summary>
        /// 组织主键
        /// </summary>
        [MaxLength(50)]
        [Comment("组织主键")]
        [Required]
        public virtual string OrganizeId { get; set; }
        /// <summary>
        /// 分类:1-角色2-岗位
        /// </summary>
        [Comment("分类:1-角色2-岗位")]
        [Required]
        public virtual int? Category { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        [MaxLength(50)]
        [Comment("角色编码")]
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
        /// 类型
        /// </summary>
        [MaxLength(50)]
        [Comment("类型")]
        public virtual string Type { get; set; }


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