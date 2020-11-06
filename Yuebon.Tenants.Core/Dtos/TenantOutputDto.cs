using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Tenants.Dtos
{
    /// <summary>
    /// 租户输出对象模型
    /// </summary>
    [Serializable]
    public class TenantOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

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
        /// 设置或获取数据源，分库使用
        /// </summary>
        [MaxLength(200)]
        public string DataSource { get; set; }

        /// <summary>
        /// 设置或获取租户介绍
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        [MaxLength(50)]
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取修改人
        /// </summary>
        [MaxLength(50)]
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        [MaxLength(50)]
        public string DeleteUserId { get; set; }


    }
}
