using System;
using Yuebon.Commons.IServices;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.IServices
{
    /// <summary>
    /// 定义用户登录信息服务接口
    /// </summary>
    public interface ITenantLogonService:IService<TenantLogon,TenantLogonOutputDto, string>
    {

    }
}
