using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Tenants.Models
{
    /// <summary>
    /// 租户，数据实体对象
    /// </summary>
    [Table("Sys_Tenant")]
    [Comment("租户信息表")]
    [Serializable]
    public class Tenant:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {

        /// <summary>
        /// 设置或获取租户账号
        /// </summary>
        [MaxLength(50)]
        [Comment("租户账号")]
        public string TenantName { get; set; }

        /// <summary>
        /// 设置或获取公司名称
        /// </summary>
        [MaxLength(50)]
        [Comment("公司名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 设置或获取访问域名
        /// </summary>
        [MaxLength(50)]
        [Comment("访问域名")]
        public string HostDomain { get; set; }

        /// <summary>
        /// 设置或获取租户Email
        /// </summary>
        [MaxLength(50)]
        [Comment("租户Email")]
        public string Email { get; set; }

        /// <summary>
        /// 设置或获取联系人
        /// </summary>
        [MaxLength(50)]
        [Comment("联系人")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 设置或获取联系电话
        /// </summary>
        [MaxLength(50)]
        [Comment("联系电话")]
        public string Telphone { get; set; }

        /// <summary>
        /// 设置或获取数据源，分库使用
        /// </summary>
        [MaxLength(500)]
        [Comment("数据源，分库使用")]
        public string DataSource { get; set; }

        /// <summary>
        /// 设置或获取租户介绍
        /// </summary>
        [MaxLength(500)]
        [Comment("租户介绍")]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        [Comment("是否可用")]
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取逻辑删除标志
        /// </summary>
        [Comment("逻辑删除标志")]
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Comment("创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人公司ID")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人部门ID")]
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        [Comment("最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改用户
        /// </summary>
        [MaxLength(50)]
        [Comment("最后修改用户")]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        [Comment("删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除用户
        /// </summary>
        [MaxLength(50)]
        [Comment("删除用户")]
        public virtual string DeleteUserId { get; set; }


    }
}
