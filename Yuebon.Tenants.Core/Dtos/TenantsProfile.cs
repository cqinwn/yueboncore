using AutoMapper;
using System.Collections.Generic;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
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
