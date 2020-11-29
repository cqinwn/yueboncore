using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
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
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.AspNetCore.Mvc.Filter
{
    /// <summary>
    /// 表示一个特性，该特性用于全局捕获程序运行异常信息。
    /// </summary>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {

        private ILogRepository service = new LogRepository();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            YuebonCurrentUser currentUser = new YuebonCurrentUser();
            string requestHost = context.HttpContext.Request.Host.ToString();
            string requestPath = context.HttpContext.Request.Path.ToString();
            string queryString = context.HttpContext.Request.QueryString.ToString();
            var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            Log4NetHelper.Error(type, "全局捕获程序运行异常信息", context.Exception);
            CommonResult result = new CommonResult();
            if (exception is MyApiException myApiex)
            {
                context.HttpContext.Response.StatusCode = 200;
                context.ExceptionHandled = true;
                result.ErrMsg = myApiex.Msg;
                result.ErrCode = myApiex.ErrCode;
            }
            else
            {
                result.ErrMsg = "程序异常,服务端出现异常![异常消息]" + exception.Message;
                result.ErrCode = "500";
            }
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
            context.Result = new JsonResult(result,options);
            Log logEntity = new Log();
            var identities = context.HttpContext.User.Identities;
            var claimsIdentity = identities.First<ClaimsIdentity>();
            if (claimsIdentity != null)
            {
                List<Claim> claimlist = claimsIdentity.Claims as List<Claim>;
                if (claimlist.Count > 0)
                {
                    string userId = claimlist[0].Value;
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    var user = JsonSerializer.Deserialize<YuebonCurrentUser>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                    if (user != null)
                    {
                        currentUser = user;
                    }
                }
            }
            logEntity.Account = currentUser.Account;
            logEntity.NickName = currentUser.NickName;
            logEntity.Date = logEntity.CreatorTime = DateTime.Now;
            logEntity.IPAddress = currentUser.CurrentLoginIP;
            logEntity.IPAddressName = currentUser.IPAddressName;
            logEntity.Result = false;
            logEntity.Description = exception.Message;
            logEntity.Type = "Exception";
            service.Insert(logEntity);
        }
    }
}
