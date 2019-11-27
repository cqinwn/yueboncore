using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// WorkOrderInfo，DTO对象
    /// </summary>
    [DataContract]
    public class WorkOrderOutputDto:IOutputDto
    { 
        #region Property Members
        
		[DataMember]
        public virtual string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
		[DataMember]
        public virtual string Title { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
		[DataMember]
        public virtual string Category { get; set; }

        /// <summary>
        /// 机密信息
        /// </summary>
		[DataMember]
        public virtual string SecretContent { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
		[DataMember]
        public virtual string Mobile { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
		[DataMember]
        public virtual string Attachment { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
		[DataMember]
        public virtual string Status { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
		[DataMember]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
		[DataMember]
        public virtual string Description { get; set; }

		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

		[DataMember]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
		[DataMember]
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
		[DataMember]
        public virtual string DeptId { get; set; }
        [DataMember]
        public virtual DateTime? LastModifyTime { get; set; }

		[DataMember]
        public virtual string LastModifyUserId { get; set; }

		[DataMember]
        public virtual DateTime? DeleteTime { get; set; }

		[DataMember]
        public virtual string DeleteUserId { get; set; }


        #endregion

    }
}