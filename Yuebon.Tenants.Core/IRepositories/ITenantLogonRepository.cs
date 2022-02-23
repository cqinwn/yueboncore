using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.IRepositories
{
    /// <summary>
    /// 定义用户登录信息仓储接口
    /// </summary>
    public interface ITenantLogonRepository:IRepository<TenantLogon>
    {
        /// <summary>
        /// 根据租户ID获取租户登录信息实体
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        TenantLogon GetByTenantId(string tenantId);
    }
}