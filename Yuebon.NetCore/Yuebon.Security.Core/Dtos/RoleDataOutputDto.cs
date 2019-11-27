using AutoMapper;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 角色的数据权限，DTO对象
    /// </summary>
    [DataContract]
    [AutoMap(typeof(RoleData))]
    public class RoleDataOutputDto : IOutputDto
    { 
        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
		[DataMember]
        public virtual int RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
		[DataMember]
        public virtual int RoleName { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>
		[DataMember]
        public virtual string BelongCompanys { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
		[DataMember]
        public virtual string BelongDepts { get; set; }

        /// <summary>
        /// 排除部门
        /// </summary>
		[DataMember]
        public virtual string ExcludeDepts { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
		[DataMember]
        public virtual string Note { get; set; }


        #endregion
    }
}