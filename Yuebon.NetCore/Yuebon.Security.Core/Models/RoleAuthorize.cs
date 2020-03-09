using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 角色授权表，数据实体对象
    /// </summary>
    [Table("Sys_RoleAuthorize")]
    [Serializable]
    public class RoleAuthorize: BaseEntity<string>, ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public RoleAuthorize()
		{
            this.Id = GuidUtils.NewGuidFormatN();

 		}

        #region Property Members


        /// <summary>
        /// 项目类型0-子系统，1-模块，2-列表/菜单，3-按钮
        /// </summary>
        public virtual int? ItemType { get; set; }

        /// <summary>
        /// 项目主键
        /// </summary>
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 对象分类/类型1-角色，2-部门，3-用户
        /// </summary>
        public virtual int? ObjectType { get; set; }

        /// <summary>
        /// 对象主键，对象分类/类型为角色时就是角色ID，部门就是部门ID，用户就是用户ID
        /// </summary>
        public virtual string ObjectId { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        #endregion

    }
}