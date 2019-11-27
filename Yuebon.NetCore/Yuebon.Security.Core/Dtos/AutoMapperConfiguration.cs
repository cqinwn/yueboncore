using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dependency;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Core.Dtos
{

    /// <summary>
    /// DTO对象映射配置
    /// </summary>
    [Dependency(ServiceLifetime.Singleton)]
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        

        public void CreateMaps(MapperConfigurationExpression mapper)
        {
            mapper.CreateMap<APP, AppOutputDto>();
        }
    }
}
