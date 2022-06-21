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
    /// <summary>
    /// AutoMapperService
    /// </summary>
    public class AutoMapperService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public static void UsePack(IServiceProvider provider)
        {
            IMapper mapper = provider.GetService<IMapper>();
            MapperExtensions.SetMapper(mapper);
        }
    }
}
