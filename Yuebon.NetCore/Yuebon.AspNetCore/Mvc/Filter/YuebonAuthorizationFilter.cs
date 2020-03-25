using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;

namespace Yuebon.AspNetCore.Mvc
{
    /// <summary>
    /// 功能权限授权验证
    /// </summary>
    public class YuebonAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private static AuthorizationPolicy _policy_ = new AuthorizationPolicy(new[] { new DenyAnonymousAuthorizationRequirement() }, new string[] { });
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }
            //匿名访问不需要token认证
            var allowanyone = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any()
            || controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any();
            if (allowanyone)
            {
                return;
            }
            //需要token认证
            string authHeader = context.HttpContext.Request.Headers["Authorization"];//Header中的token
            if (string.IsNullOrEmpty(authHeader))
            {
                context.Result = new JsonResult(new CommonResult(ErrCode.err40004, "40000"));
                return;
            }
            else
            {
                string token = string.Empty;
                if (authHeader != null && authHeader.StartsWith("Bearer") && authHeader.Length > 10)
                {
                    token = authHeader.Substring("Bearer ".Length).Trim();
                }
                TokenProvider tokenProvider = new TokenProvider();
                CommonResult result = new CommonResult();
                result = tokenProvider.ValidateToken(token);
                //token验证失败
                if (!result.Success)
                {
                    context.Result = new JsonResult(result);
                }
                else
                {
                    //是否需要用户登录
                    var isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                          .Any(a => a.GetType().Equals(typeof(NoPermissionRequiredAttribute))) ;
                    //不需要登录
                    if (isDefined)
                    {
                        return;
                    }
                    //需要登录和验证功能权限
                    string userId = result.ResData.ToString();
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var authorizeAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(YuebonAuthorizeAttribute), true).OfType<YuebonAuthorizeAttribute>();
                        if (authorizeAttributes.First() != null)
                        {
                            string function = authorizeAttributes.First().Function;
                            if (!string.IsNullOrEmpty(function))
                            {
                                string functionCode = controllerActionDescriptor.ControllerName + "/" + function;
                                bool bl = new Permission().HasFunction(functionCode, userId);
                                if (!bl)
                                {
                                    context.Result = new JsonResult(new CommonResult(ErrCode.err40006, "40006"));
                                }
                            }
                        }
                        return;
                    }
                    else
                    {
                        context.Result = new JsonResult(new CommonResult(ErrCode.err40008, "40008"));
                    }
                }
                return;
            }

        }
    }
}
