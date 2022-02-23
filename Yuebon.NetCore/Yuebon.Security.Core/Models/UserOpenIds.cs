
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 第三方登录与用户绑定表，数据实体对象
    /// </summary>
    [Table("Sys_UserOpenIds")]
    [Comment("第三方登录与用户绑定表")]
    public class UserOpenIds:BaseEntity
    {
        #region Property Members
        /// <summary>
        /// 用户编号
        /// </summary>
        [MaxLength(50)]
        [Comment("用户编号")]
        [Required]
        public virtual string UserId { get; set; }

        /// <summary>
        /// 第三方类型
        /// </summary>
        [MaxLength(200)]
        [Comment("第三方类型")]
        [Required]
        public virtual string OpenIdType { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        [MaxLength(100)]
        [Comment("OpenId")]
        [Required]
        public virtual string OpenId { get; set; }

        #endregion

    }
}