using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class YuebonAuthorizeAttribute: AuthorizeAttribute
    {
        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permission"></param>
        public YuebonAuthorizeAttribute(string permission)
        {
            Permission = permission;
        }
    }
}
