using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Enums;

namespace Yuebon.Commons.Options
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public  long UserId{get;set; }

        /// <summary>
        /// 账号
        /// </summary>
        public  string UserName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public  string RealName { get; set; }

        /// <summary>
        /// 是否超级管理
        /// </summary>
        public  string SuperAdmin { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public  long TenantId { get; set; }

        /// <summary>
        /// 组织机构Id
        /// </summary>
        public  long OrgId { get; set; }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public  string OrgName { get; set; }

        /// <summary>
        /// 微信标识OpenId
        /// </summary>
        public  string OpenId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public  string Role { get; set; }

        /// <summary>
        /// 租户数据架构
        /// </summary>
        public TenantSchemaEnum TenantSchema { get; set; }

        /// <summary>
        /// 租户独立数据库时的数据源配置
        /// </summary>
        public string TenantDataSource { get; set; }

        /// <summary>
        /// 租户名称
        /// </summary>
        public string TenantName { get; set; }
    }
}
