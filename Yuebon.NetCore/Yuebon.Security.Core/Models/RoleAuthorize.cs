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
        /// 项目类型1-模块2-按钮3-列表
        /// </summary>
        public virtual int? ItemType { get; set; }

        /// <summary>
        /// 项目主键
        /// </summary>
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 对象分类1-角色2-部门-3用户
        /// </summary>
        public virtual int? ObjectType { get; set; }

        /// <summary>
        /// 对象主键
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