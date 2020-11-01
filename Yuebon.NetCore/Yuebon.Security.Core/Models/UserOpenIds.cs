
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 第三方登录与用户绑定表，数据实体对象
    /// </summary>
    [Table("Sys_UserOpenIds")]
    public class UserOpenIds
    {
        #region Property Members
        /// <summary>
        /// 用户编号
        /// </summary>
        public virtual string UserId { get; set; }

        /// <summary>
        /// 第三方类型
        /// </summary>
        public virtual string OpenIdType { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        public virtual string OpenId { get; set; }

        #endregion

    }
}