using Yuebon.Commons.IServices;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.IServices
{
    /// <summary>
    /// 定义租户服务接口
    /// </summary>
    public interface ITenantService:IService<Tenant,TenantOutputDto, string>
    {
    }
}
