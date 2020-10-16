using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 租户，数据实体对象
    /// </summary>
    [Table("Sys_Tenant")]
    [Serializable]
    public class Tenant:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// 设置或获取租户名称
        /// </summary>
        public string TenantName { get; set; }

        /// 设置或获取公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// 设置或获取访问域名
        /// </summary>
        public string HostDomain { get; set; }

        /// 设置或获取联系人
        /// </summary>
        public string LinkMan { get; set; }

        /// 设置或获取联系电话
        /// </summary>
        public string Telphone { get; set; }

        /// 设置或获取数据源，分库使用
        /// </summary>
        public string DataSource { get; set; }

        /// 设置或获取租户介绍
        /// </summary>
        public string Description { get; set; }

        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// 设置或获取删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// 设置或获取创建人
        /// </summary>
        public string CreatorUserId { get; set; }

        /// 设置或获取创建人组织
        /// </summary>
        public string CompanyId { get; set; }

        /// 设置或获取部门
        /// </summary>
        public string DeptId { get; set; }

        /// 设置或获取修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// 设置或获取修改人
        /// </summary>
        public string LastModifyUserId { get; set; }

        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// 设置或获取删除人
        /// </summary>
        public string DeleteUserId { get; set; }

    }
}