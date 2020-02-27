/*******************************************************************************
 * Copyright © 2017-2020 Yuebon.Framework 版权所有
 * Author: Yuebon
 * Description: Yuebon快速开发平台
 * Website：http://www.yuebon.com
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IoC;

namespace Yuebon.Commons.Extensions
{
    public static class IoCContainerExtensions
    {
        public static void AddAspect(this IoCContainer container)
        {
            if(container==null)
                throw new ArgumentNullException(nameof(container));
        }
    }
}
