using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 租户输入对象模型
    /// </summary>
    [AutoMap(typeof(Tenant))]
    [Serializable]
    public class TenantInputDto: IInputDto<string>
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

    }
}