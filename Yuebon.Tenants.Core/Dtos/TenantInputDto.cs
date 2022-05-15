using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Enums;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Dtos
{
    /// <summary>
    /// 租户输入对象模型
    /// </summary>
    [AutoMap(typeof(Tenant))]
    [Serializable]
    public class TenantInputDto: IInputDto
    {

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取租户名称
        /// </summary>
        [MaxLength(50)]
        public string TenantName { get; set; }

        /// <summary>
        /// 设置或获取公司名称
        /// </summary>
        [MaxLength(50)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 租户类型
        /// </summary>
        public int TenantType { get; set; }
        /// <summary>
        /// 设置或获取访问域名
        /// </summary>
        [MaxLength(200)]
        public string HostDomain { get; set; }

        /// <summary>
        /// 设置或获取联系人
        /// </summary>
        [MaxLength(50)]
        public string LinkMan { get; set; }

        /// <summary>
        /// 设置或获取联系电话
        /// </summary>
        [MaxLength(50)]
        public string Telphone { get; set; }
        /// <summary>
        /// 架构
        /// </summary>
        public int Schema { get; set; }
        /// <summary>
        /// 设置或获取数据源，分库使用
        /// </summary>
        [MaxLength(2000)]
        public string DataSource { get; set; }

        /// <summary>
        /// 设置或获取租户介绍
        /// </summary>
        [MaxLength(2000)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool EnabledMark { get; set; }


    }
}
