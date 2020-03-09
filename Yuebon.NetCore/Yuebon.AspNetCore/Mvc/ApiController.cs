using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
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
        /// 验证token的合法性。如果不合法，返回MyApiException异常
        /// </summary>
        /// <returns></returns>
        [HttpPost("CheckToken")]
        [HiddenApi]
        public CommonResult CheckToken(string token="")
        {
            CommonResult result = new CommonResult();
            string strHost = Request.Host.ToString();
            if (!strHost.Contains("localhost"))
            {
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
                        User userInfo = new UserApp().GetUserById(userId);
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
            }
            else
            {
                result.ErrCode = "0";
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
