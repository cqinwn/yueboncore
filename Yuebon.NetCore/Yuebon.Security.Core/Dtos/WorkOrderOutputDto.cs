using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// WorkOrderInfo，DTO对象
    /// </summary>
    [Serializable]
    public class WorkOrderOutputDto:IOutputDto
    { 
        #region Property Members
        
        /// <summary>
        /// 
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual string Category { get; set; }

        /// <summary>
        /// 机密信息
        /// </summary>
        public virtual string SecretContent { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public virtual string Mobile { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public virtual string Attachment { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
		[DataMember]
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string LastModifyUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string DeleteUserId { get; set; }


        #endregion

    }
}