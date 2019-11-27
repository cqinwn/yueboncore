using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Mapping;

namespace Yuebon.Commons.Module
{
    public class AutoMapperService
    {
        public static void UsePack(IServiceProvider provider)
        {
            IMapper mapper = provider.GetService<IMapper>();
            MapperExtensions.SetMapper(mapper);
        }
    }
}
