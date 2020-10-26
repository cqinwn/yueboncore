using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Mvc
{
    /// <summary>
    /// 功能权限授权验证筛选
    /// </summary>
    public class YuebonAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// 授权验证
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
            CommonResult result = new CommonResult();
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,                                   //格式化json字符串
                AllowTrailingCommas = true,                             //可以结尾有逗号
                //IgnoreNullValues = true,                              //可以有空值,转换json去除空值属性
                IgnoreReadOnlyProperties = true,                        //忽略只读属性
                PropertyNameCaseInsensitive = true,                     //忽略大小写
                                                                        //PropertyNamingPolicy = JsonNamingPolicy.CamelCase     //命名方式是默认还是CamelCase
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            options.Converters.Add(new DateTimeJsonConverter());
            //需要token认证
            string authHeader = context.HttpContext.Request.Headers["Authorization"];//Header中的token
            if (string.IsNullOrEmpty(authHeader))
            {

                result.ErrCode = "40004";
                result.ErrMsg = ErrCode.err40004;
                context.Result = new JsonResult(result, options);
                return;
            }
            else
            {
                string token = string.Empty;
                if (authHeader != null && authHeader.StartsWith("Bearer",StringComparison.Ordinal) && authHeader.Length > 10)
                {
                    token = authHeader.Substring("Bearer ".Length).Trim();
                }
                TokenProvider tokenProvider = new TokenProvider();
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
                    if (result.ResData != null)
                    {
                        List<Claim> claimlist = result.ResData as List<Claim>;
                        string userId = claimlist[3].Value;
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        var user = JsonSerializer.Deserialize<YuebonCurrentUser>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                       
                        if (user == null)
                        {
                            result.ErrCode = "40008";
                            result.ErrMsg = ErrCode.err40008;
                            context.Result = new JsonResult(result, options);
                            return;
                        }
                        var claims = new[] {
                           new Claim(YuebonClaimTypes.UserId,userId),
                           new Claim(YuebonClaimTypes.UserName,claimlist[2].Value),
                           new Claim(YuebonClaimTypes.Role,claimlist[4].Value),
                           new Claim(YuebonClaimTypes.TenantId,user.TenantId)
                        };
                        var identity = new ClaimsIdentity(claims);
                        var principal = new ClaimsPrincipal(identity);
                        context.HttpContext.User = principal;
                        bool isAdmin = Permission.IsAdmin(user);
                        if (!isAdmin)
                        {
                            var authorizeAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(YuebonAuthorizeAttribute), true).OfType<YuebonAuthorizeAttribute>();
                            if (authorizeAttributes.First() != null)
                            {
                                string function = authorizeAttributes.First().Function;
                                if (!string.IsNullOrEmpty(function))
                                {
                                    string functionCode = controllerActionDescriptor.ControllerName + "/" + function;

                                    bool bl = Permission.HasFunction(functionCode, userId);
                                    if (!bl)
                                    {
                                        result.ErrCode = "40006";
                                        result.ErrMsg = ErrCode.err40006;
                                        context.Result = new JsonResult(result, options);
                                    }
                                }
                            }
                        }
                        return;
                    }
                    else
                    {
                        result.ErrCode = "40008";
                        result.ErrMsg = ErrCode.err40008;
                        context.Result = new JsonResult(result, options);
                    }
                }
                return;
            }

        }
    }
}
