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
using System.Text.Json;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;

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
                            var user = JsonSerializer.Deserialize<YuebonCurrentUser>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                            if (user != null)
                            {
                                CurrentUser = user;
                            }
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
