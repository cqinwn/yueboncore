
using System;
using System.Collections.Generic;
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
    public class RoleData:BaseEntity<string>
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public RoleData()
        {
            this.Id = GuidUtils.CreateNo();
        }

        #region Property Members

        /// <summary>
        /// 角色ID
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 类型，company-公司，dept-部门，person-个人
        /// </summary>
        public virtual string DType { get; set; }

        /// <summary>
        /// 数据数据，部门ID或个人ID
        /// </summary>
        public virtual string AuthorizeData { get; set; }



        #endregion

    }
}