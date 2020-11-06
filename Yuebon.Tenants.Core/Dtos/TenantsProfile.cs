using AutoMapper;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantsProfile : Profile
    {
        /// <summary>
        /// /
        /// </summary>
        public TenantsProfile()
        {
            CreateMap<Tenant, TenantOutputDto>();
            CreateMap<TenantInputDto, Tenant>();
        }
    }
}
