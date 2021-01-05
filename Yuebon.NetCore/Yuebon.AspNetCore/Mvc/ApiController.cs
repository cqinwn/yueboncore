using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// WebApi控制器基类
    /// </summary>
    [ApiController]
    [EnableCors("yuebonCors")]
    public class ApiController : Controller
    {
        /// <summary>
        /// 当前登录的用户属性
        /// </summary>
        public YuebonCurrentUser CurrentUser;
        private ILogRepository service = new LogRepository();
        #region 
        /// <summary>
        /// 重写基类在Action执行之前的事情
        /// 根据token获得当前用户，允许匿名的不需要获取用户
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;

            try
            {   //匿名访问不需要token认证
                var allowanyone = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any()
                || controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(IAllowAnonymous), true).Any();
                if (!allowanyone)
                {
                    var identities = filterContext.HttpContext.User.Identities;
                    var claimsIdentity = identities.First<ClaimsIdentity>();
                    if (claimsIdentity != null)
                    {
                        List<Claim> claimlist= claimsIdentity.Claims as List<Claim>;
                        if (claimlist.Count > 0)
                        {
                            string userId = claimlist[0].Value;
                            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                            var user = yuebonCacheHelper.Get("login_user_" + userId).ToJson().ToObject<YuebonCurrentUser>();
                            if (user != null)
                            {
                                CurrentUser = user;
                            }
                        }
                    }
                }
                Log logEntity = new Log();
                if (CurrentUser != null)
                {
                    logEntity.Account = CurrentUser.Account;
                    logEntity.NickName = CurrentUser.NickName;
                    logEntity.IPAddressName = CurrentUser.IPAddressName;
                }
                logEntity.IPAddress = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
                logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                logEntity.Result = false;
                logEntity.Description = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;
                logEntity.Type = "Visit";
                service.Insert(logEntity);
                base.OnActionExecuting(filterContext);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("", ex);
                //throw new MyApiException("", "", ex);
            }
        }
        #endregion

        /// <summary>
        /// 把object对象转换为ContentResult
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ToJsonContent")]
        protected IActionResult ToJsonContent(object obj)
        {
            return Content(obj.ToJson());
        }


        /// <summary>
        /// 把object对象转换为ContentResult
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ToJsonContent")]
        protected IActionResult ToJsonContent(object obj,bool isNull=false)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,                                   //格式化json字符串
                AllowTrailingCommas = true,                             //可以结尾有逗号
                IgnoreNullValues = true,                              //可以有空值,转换json去除空值属性
                IgnoreReadOnlyProperties = true,                        //忽略只读属性
                PropertyNameCaseInsensitive = true,                     //忽略大小写
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            options.Converters.Add(new DateTimeJsonConverter());
            return Content(JsonSerializer.Serialize(obj, options));
        }

        /// <summary>
        /// 根据Request参数获取分页对象数据
        /// </summary>
        /// <returns></returns>
        protected virtual PagerInfo GetPagerInfo()
        {
            int pageSize = Request.Query["length"].ToString() == null ? 1 : Request.Query["length"].ToString().ToInt();
            int pageIndex = 1;
            string currentPage = Request.Query["CurrentPage"].ToString();
            if (string.IsNullOrWhiteSpace(currentPage))
            {
                string start = Request.Query["start"].ToString();
                if (!string.IsNullOrWhiteSpace(start))
                {
                    pageIndex = (start.ToInt() / pageSize) + 1;
                }
            }
            else
            {
                pageIndex = currentPage.ToInt();
            }
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.CurrenetPageIndex = pageIndex;
            pagerInfo.PageSize = pageSize;
            return pagerInfo;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetToken")]
        [HiddenApi]
        public string GetToken()
        {
            string token = HttpContext.Request.Query["Token"];
            if (!String.IsNullOrEmpty(token)) return token;
            string authHeader = HttpContext.Request.Headers["Authorization"];//Header中的token
            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                token = authHeader.Substring("Bearer ".Length).Trim();
                return token;
            }
            var cookie = HttpContext.Request.Cookies["Token"];
            return cookie == null ? String.Empty : cookie;
        }

    }
}
