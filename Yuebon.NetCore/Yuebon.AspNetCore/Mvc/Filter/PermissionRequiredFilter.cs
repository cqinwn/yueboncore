using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;

namespace Yuebon.AspNetCore.Mvc.Filter
{
    /// <summary>
    /// 需要权限验证
    /// </summary>
    public class PermissionRequiredAttribute: ActionFilterAttribute
    {
        #region 字段和属性
        /// <summary>
        /// 模块别名，可配置更改
        /// </summary>
        public string Modules { get; set; }

        /// <summary>
        /// 权限动作
        /// </summary>
        public string Methods { get; set; }

        /// <summary>
        /// 权限访问控制器参数
        /// </summary>
        private string Sign { get; set; }

        /// <summary>
        /// 是否保存日志
        /// </summary>
        public bool IsLog { get; set; } = true;

        private string ActionArguments { get; set; }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            var isDefined = false;
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                   .Any(a => a.GetType().Equals(typeof(NoPermissionRequiredAttribute)))|| controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any()
            || controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any();
            }
            if (isDefined) return;

            string authHeader = filterContext.HttpContext.Request.Headers["Authorization"];//Header中的token
            string token = string.Empty;
            if (authHeader != null && authHeader.StartsWith("Bearer",StringComparison.Ordinal) && authHeader.Length > 10)
            {
                token = authHeader.Substring("Bearer ".Length).Trim();
            }
            TokenProvider tokenProvider = new TokenProvider();
            CommonResult result = new CommonResult();
            result = tokenProvider.ValidateToken(token);
            if (result.ResData == null)
            {
                throw new MyApiException(ErrCode.err40008, "40008");
            }
            else
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                string userId = result.ResData.ToString();
                if (!string.IsNullOrEmpty(userId))
                {
                    string functionCode = controllerActionDescriptor.ControllerName + "/" + controllerActionDescriptor.ActionName;
                    bool bl = Permission.HasFunction(functionCode, userId);
                    if (!bl)
                    {
                        throw new MyApiException(ErrCode.err40006, "40006");
                    }
                    base.OnActionExecuting(filterContext);
                    return;
                }
                else
                {
                    throw new MyApiException(ErrCode.err40008, "40008");
                }
            }
        }
    }
}
