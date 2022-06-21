using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义用户登录信息服务接口
    /// </summary>
    public interface ITenantLogonService:IService<TenantLogon,TenantLogonOutputDto>
    {

    }
}
