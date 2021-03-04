using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Dtos
{
    public class TenantsProfile : Profile
    {
        public TenantsProfile()
        {
           CreateMap<Tenant, TenantOutputDto>();
           CreateMap<TenantInputDto, Tenant>();
            CreateMap<TenantLogon, TenantLogonOutputDto>();
            CreateMap<TenantLogonInputDto, TenantLogon>();

        }
    }
}
