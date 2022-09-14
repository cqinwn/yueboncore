using Yuebon.Commons.Enums;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 租户，数据实体对象
    /// </summary>
    [SugarTable("Sys_Tenant", "租户信息表")]
    [Serializable]
    public class Tenant:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public Tenant()
        {
        }

        /// <summary>
        /// 设置或获取租户账号
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="租户账号")]
        public string TenantName { get; set; }

        /// <summary>
        /// 设置或获取公司名称
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="公司名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 租户类型
        /// </summary>
        [SugarColumn(ColumnDescription = "租户类型")]
        public virtual TenantTypeEnum TenantType { get; set; }
        /// <summary>
        /// 设置或获取访问域名
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="访问域名")]
        public string HostDomain { get; set; }

        /// <summary>
        /// 设置或获取租户Email
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="租户Email")]
        public string Email { get; set; }

        /// <summary>
        /// 设置或获取联系人
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="联系人")]
        public string LinkMan { get; set; }

        /// <summary>
        /// 设置或获取联系电话
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="联系电话")]
        public string Telphone { get; set; }

        /// <summary>
        /// 架构
        /// </summary>
        [SugarColumn(ColumnDescription = "架构")]
        public virtual TenantSchemaEnum Schema { get; set; }
        /// <summary>
        /// 设置或获取数据源，分库使用
        /// </summary>
        [MaxLength(2000)]
        [SugarColumn(ColumnDescription="数据源，分库使用",ColumnDataType = "VARCHAR(2000)")]
        public string DataSource { get; set; }

        /// <summary>
        /// 设置或获取租户介绍
        /// </summary>
        [MaxLength(1000)]
        [SugarColumn(ColumnDataType = "NVARCHAR(1000)", ColumnDescription="租户介绍")]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        [SugarColumn(ColumnDescription="是否可用")]
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取逻辑删除标志
        /// </summary>
        [SugarColumn(ColumnDescription="逻辑删除标志")]
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [SugarColumn(ColumnDescription="创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建用户主键
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="创建用户主键")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="创建人公司ID")]
        public long? CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="创建人部门ID")]
        public long? DeptId { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        [SugarColumn(ColumnDescription="最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="最后修改用户")]
        public virtual long? LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        [SugarColumn(ColumnDescription="删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription="删除用户")]
        public virtual long? DeleteUserId { get; set; }



    }
}
