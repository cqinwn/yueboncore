
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 角色权限表，数据实体对象
    /// </summary>
    [SugarTable("Sys_RoleAuthorize")]
    [Serializable]
    [Comment("角色权限表")]
    public class RoleAuthorize: BaseEntity, ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public RoleAuthorize()
		{
            this.Id = GuidUtils.CreateNo();

 		}

        #region Property Members


        /// <summary>
        /// 项目类型功能标识 0-子系统 1-标识菜单/模块，2标识按钮功能
        /// </summary>
        [Comment("项目类型功能标识 0-子系统 1-标识菜单/模块，2标识按钮功能")]
        [Required]
        public virtual int? ItemType { get; set; }

        /// <summary>
        /// 项目主键
        /// </summary>
        [MaxLength(50)]
        [Comment("项目主键")]
        [Required]
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 对象分类/类型1-角色，2-部门，3-用户
        /// </summary>
        [Comment("对象分类/类型1-角色，2-部门，3-用户")]
        public virtual int? ObjectType { get; set; }

        /// <summary>
        /// 对象主键，对象分类/类型为角色时就是角色ID，部门就是部门ID，用户就是用户ID
        /// </summary>
        [MaxLength(50)]
        [Comment("对象主键，对象分类/类型为角色时就是角色ID，部门就是部门ID，用户就是用户ID")]
        [Required]
        public virtual string ObjectId { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Comment("排序码")]
        public virtual int? SortCode { get; set; }

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

        #endregion

    }
}