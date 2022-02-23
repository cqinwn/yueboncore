
using Microsoft.EntityFrameworkCore;
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
    /// 角色的数据权限，数据实体对象
    /// </summary>
    [Table("Sys_RoleData")]
    [Comment("角色的数据权限")]
    public class RoleData:BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public RoleData()
        {
            
        }

        #region Property Members

        /// <summary>
        /// 角色ID
        /// </summary>
        [MaxLength(50)]
        [Comment("角色ID")]
        [Required]
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 类型，company-公司，dept-部门，person-个人
        /// </summary>
        [MaxLength(50)]
        [Comment("类型，company-公司，dept-部门，person-个人")]
        [Required]
        public virtual string DType { get; set; }

        /// <summary>
        /// 数据数据，部门ID或个人ID
        /// </summary>
        [MaxLength(50)]
        [Comment("数据数据，部门ID或个人ID")]
        [Required]
        public virtual string AuthorizeData { get; set; }



        #endregion

    }
}