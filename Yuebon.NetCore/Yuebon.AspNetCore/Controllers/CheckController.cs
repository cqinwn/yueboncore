using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    ///  sso验证
    /// <para>其他站点通过后台Post来认证</para>
    /// <para>或使用静态类Yuebon.Security.Application.SSO.AuthHelper访问</para>
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CheckController : ControllerBase
    {
        private SSOAuthHelper ssoAuthHelper=IoCContainer.Resolve<SSOAuthHelper>();
        private readonly JwtOption jwtModel;

        public CheckController(JwtOption _jwtModel)
        {
            this.jwtModel = _jwtModel;
        }

        /// <summary>
        /// 检验token是否有效
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="requestid">请求Id备用参数.</param>
        [HttpGet("GetStatus")]
        public CommonResult<bool> GetStatus(string token, string requestid = "")
        {
            var result = new CommonResult<bool>();
            try
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                result.Result = yuebonCacheHelper.Get(token) != null;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrCode = "500";
                result.ErrMsg = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 根据token获取用户及用户可访问的所有资源
        /// </summary>
        /// <param name="token"></param>
        /// <param name="requestid">备用参数.</param>
        [HttpGet("GetUserWithAccessedCtrls")]
        public CommonResult<UserWithAccessedCtrls> GetUserWithAccessedCtrls(string token, string requestid = "")
        {
            var result = new CommonResult<UserWithAccessedCtrls>();
            try
            {
                CommonResult commonResult = new CommonResult();
                token = GetToken();
                TokenProvider tokenProvider = new TokenProvider(jwtModel);
                commonResult = tokenProvider.ValidateToken(token);
                if (commonResult.ErrCode == ErrCode.successCode)
                {
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    if (commonResult.ResData != null)
                    {
                        string userId = commonResult.ResData.ToString();
                        var user = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                        if (user != null)
                        {
                            result.ResData = new AuthorizeApp().GetAccessedControls(user.Account);
                            result.ErrCode = ErrCode.successCode;
                            result.Success = true;
                        }
                        else
                        {
                           User user1 = new UserApp().GetUserById(userId);
                            result.ResData = new AuthorizeApp().GetAccessedControls(user1.Account);
                            result.ErrCode = ErrCode.successCode;
                            result.Success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrCode = "500";
                result.ErrMsg = ex.Message;
            }

            return result;

        }

        /// <summary>
        /// 根据token获取用户名称
        /// </summary>
        /// <param name="token"></param>
        /// <param name="requestid">备用参数.</param>
        [HttpGet("GetUserName")]
        public CommonResult<string> GetUserName(string token, string requestid = "")
        {
            var result = new CommonResult<string>();
            try
            {
                CommonResult commonResult = new CommonResult();
                token = GetToken();
                TokenProvider tokenProvider = new TokenProvider(jwtModel);
                commonResult = tokenProvider.ValidateToken(token);
                if (commonResult.ErrCode == ErrCode.successCode)
                {
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();

                    string userId = commonResult.ResData.ToString();
                    var user = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                    if (user != null)
                    {
                        result.ResData = user.Account;
                        result.Success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrCode = "500";
                result.ErrMsg = ex.Message;
            }

            return result;
        }
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="request">登录参数</param>
        /// <returns></returns>
        [HttpPost("Login")]
        public LoginResult Login([FromBody]PassportLoginRequest request)
        {
            var result = new LoginResult();
            try
            {
                result = ssoAuthHelper.Validate(request);
            }
            catch (Exception ex)
            {
                result.ErrCode = "500";
                result.ErrMsg = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="token"></param>
        /// <param name="requestid">备用参数.</param>
        [HttpPost("Logout")]
        public bool Logout(string token,string requestid = "")
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Remove(token);
            var user = yuebonCacheHelper.Get<UserAuthSession>(token);
            yuebonCacheHelper.Remove("login_user_" + user.UserId);
            yuebonCacheHelper.Remove("User_Function_" + user.UserId);
            yuebonCacheHelper.Remove("User_Menu_" + user.UserId);
            yuebonCacheHelper.Remove("SysSetting");
            return true;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        private string GetToken()
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