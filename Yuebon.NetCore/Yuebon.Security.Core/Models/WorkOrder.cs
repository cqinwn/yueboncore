using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// WorkOrder，数据实体对象
    /// </summary>
    [Table("Sys_WorkOrder")]
    public class WorkOrder: BaseEntity<string>
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public WorkOrder()
		{
            this.Id= System.Guid.NewGuid().ToString();

 		}

        #region Property Members

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
        /// 客户名称
        /// </summary>
        public virtual string Customer { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        public virtual DateTime? CreatorTime { get; set; }

        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        public virtual string DeptId { get; set; }
        public virtual DateTime? LastModifyTime { get; set; }

        public virtual string LastModifyUserId { get; set; }

        public virtual DateTime? DeleteTime { get; set; }

        public virtual string DeleteUserId { get; set; }


        #endregion

    }
}