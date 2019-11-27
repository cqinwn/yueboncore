using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
            this.Id= System.Guid.NewGuid().ToString();
 		}

        #region Property Members

        /// <summary>
        /// 角色ID
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
        public virtual string BelongCompanys { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public virtual string BelongDepts { get; set; }

        /// <summary>
        /// 排除部门
        /// </summary>
        public virtual string ExcludeDepts { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }


        #endregion

    }
}