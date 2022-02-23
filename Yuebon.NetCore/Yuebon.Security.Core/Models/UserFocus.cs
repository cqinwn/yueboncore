
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
    /// 用户关注表，数据实体对象
    /// </summary>
    [Table("Sys_UserFocus")]
    [Serializable]
    public class UserFocus : BaseEntity,ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public UserFocus()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        #region Property Members

        /// <summary>
        /// 关注的用户ID
        /// </summary>
        public virtual string FocusUserId { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 关注时间
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }
        #endregion

    }
}