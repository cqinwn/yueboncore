using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Authorizer.Models;

namespace Yuebon.Authorizer.Dtos
{
    public class AuthorizerProfile : Profile
    {
        public AuthorizerProfile()
        {
           CreateMap<RegistryCode, RegistryCodeOutputDto>();
           CreateMap<RegistryCodeInputDto, RegistryCode>();

        }
    }
}
