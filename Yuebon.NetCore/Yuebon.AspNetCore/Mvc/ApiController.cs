using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

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
        public UserAuthSession CurrentUser;
        private ILogService logService = IoCContainer.Resolve<ILogService>();
        private IUserService userService = IoCContainer.Resolve<IUserService>();
        #region 
        /// <summary>
        /// 重新基类在Action执行之前的事情
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
                    string useridcookie = CookiesHelper.ReadCookie(filterContext.HttpContext, "loginuser");
                    string authHeader = HttpContext.Request.Headers["Authorization"];//Header中的token
                    CommonResult result = new CommonResult();
                    string token = string.Empty;
                    if (authHeader != null && authHeader.StartsWith("Bearer") && authHeader.Length > 10)
                    {
                        token = authHeader.Substring("Bearer ".Length).Trim();
                    }
                    TokenProvider tokenProvider = new TokenProvider();
                    result = tokenProvider.ValidateToken(token);
                    if (result.ResData != null)
                    {
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        List<Claim> claimlist = result.ResData as List<Claim>;
                        string userId = claimlist[3].Value;
                        var user = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                        if (user != null)
                        {
                            CurrentUser = user;
                        }
                    }
                }
                base.OnActionExecuting(filterContext);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("", ex);
                throw new MyApiException("", "", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    try
        //    {
        //        if (CurrentUser != null)
        //        {
        //            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
        //            string moudleName = controllerActionDescriptor.ControllerName + "/" + controllerActionDescriptor.ActionName;
        //            var authorizeAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(YuebonAuthorizeAttribute), true).OfType<YuebonAuthorizeAttribute>();
        //            if (authorizeAttributes.Count()>0)
        //            {
        //                if (authorizeAttributes.First() != null)
        //                {
        //                    string function = authorizeAttributes.First().Function;

        //                    if (!string.IsNullOrEmpty(function))
        //                    {
        //                        string operationType = "";
        //                        switch (function)
        //                        {
        //                            case "Add":
        //                                operationType = DbLogType.Create.ToString();
        //                                break;
        //                            case "Edit":
        //                                operationType = DbLogType.Update.ToString();
        //                                break;
        //                            case "Delete":
        //                                operationType = DbLogType.Delete.ToString();
        //                                break;
        //                            case "DeleteSoft":
        //                                operationType = DbLogType.DeleteSoft.ToString();
        //                                break;
        //                            case "List":
        //                                operationType = DbLogType.Visit.ToString();
        //                                break;
        //                            case "Exit":
        //                                operationType = DbLogType.Exit.ToString();
        //                                break;
        //                            default:
        //                                operationType = DbLogType.Other.ToString();
        //                                break;

        //                        }
        //                        logService.OnOperationLog(controllerActionDescriptor.ControllerName, operationType, controllerActionDescriptor.ActionName, CurrentUser);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4NetHelper.Error("", ex);
        //        throw new MyApiException("", "", ex);
        //    }
        //}
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
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string result = JsonConvert.SerializeObject(obj, settings);
            return Content(obj.ToJson());
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
        /// 验证token的合法性。如果不合法，返回MyApiException异常
        /// </summary>
        /// <returns></returns>
        [HttpPost("CheckToken")]
        [HiddenApi]
        public CommonResult CheckToken(string token = "")
        {
            CommonResult result = new CommonResult();
            string strHost = Request.Host.ToString();
            if (string.IsNullOrEmpty(token))
            {
                string authHeader = HttpContext.Request.Headers["Authorization"];//Header中的token
                token = string.Empty;
                if (authHeader != null && authHeader.StartsWith("Bearer") && authHeader.Length > 10)
                {
                    token = authHeader.Substring("Bearer ".Length).Trim();
                }
            }
            TokenProvider tokenProvider = new TokenProvider();
            result = tokenProvider.ValidateToken(token);
            if (result.ResData != null)
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                string userId = result.ResData.ToString();
                var user = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                if (user != null)
                {
                    CurrentUser = user;
                }
                else
                {
                    User userInfo = userService.Get(userId);
                    var currentSession = new UserAuthSession
                    {
                        UserId = userInfo.Id,
                        Account = userInfo.Account,
                        Name = userInfo.RealName,
                        NickName = userInfo.NickName,
                        CreateTime = DateTime.Now,
                        HeadIcon = userInfo.HeadIcon,
                        Gender = userInfo.Gender,
                        ReferralUserId = userInfo.ReferralUserId,
                        MemberGradeId = userInfo.MemberGradeId,
                        Role = new RoleApp().GetRoleEnCode(userInfo.RoleId)
                    };
                    CurrentUser = currentSession;
                    TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                    yuebonCacheHelper.Add("login_user_" + userInfo.Id, currentSession, expiresSliding, true);
                }
            } 
            return result;
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
