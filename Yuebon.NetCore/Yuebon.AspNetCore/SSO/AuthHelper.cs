using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Yuebon.Commons;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using IdentityModel.Client;
using System.Threading.Tasks;
using Yuebon.Security.Dtos;

namespace Yuebon.AspNetCore.SSO
{
    /// <summary>
    /// SSO授权登录
    /// </summary>
    public class AuthHelper
    {
        private HttpHelper _helper;
        private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AuthHelper(IHttpContextAccessor httpContextAccessor)
        {
            _helper = new HttpHelper(Configs.GetConfigurationValue("AppSetting", "SSOPassport"));
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 根据URL中的Token参数或Cookie获取token
        /// </summary>
        /// <returns></returns>
        private string GetToken()
        {
            string token = _httpContextAccessor.HttpContext.Request.Query["Token"];
            if (!String.IsNullOrEmpty(token)) return token;
            string authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];//Header中的token
            if (authHeader != null && authHeader.StartsWith("Bearer",StringComparison.Ordinal))
            {
                token = authHeader.Substring("Bearer ".Length).Trim();
                return token;
            }
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["Token"];
            return cookie == null ? String.Empty : cookie;
        }
        /// <summary>
        /// 检查用户登录状态
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="remark">备注信息</param>
        /// <returns></returns>
        public bool CheckLogin(string token, string remark = "")
        {
            if (String.IsNullOrEmpty(token) || String.IsNullOrEmpty(GetToken()))
                return false;

            var requestUri = string.Format("/api/Check/GetStatus?token={0}&requestid={1}", token, remark);

            try
            {
                var value = _helper.Get(null, requestUri);
                var result = JsonHelper.ToObject<CommonResult<bool>>(value);
                if (result.Success)
                {
                    return result.Result;
                }
                throw new Exception(result.ErrMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查用户登录状态
        /// <para>通过URL中的Token参数或Cookie中的Token</para>
        /// </summary>
        /// <param name="remark">备注信息</param>
        public bool CheckLogin(string remark = "")
        {
            return CheckLogin(GetToken(), remark);
        }
        /// <summary>
        /// 获取当前登录的用户信息
        /// <para>通过URL中的Token参数或Cookie中的Token</para>
        /// </summary>
        /// <param name="remark">The remark.</param>
        /// <returns>LoginUserVM.</returns>
        public UserWithAccessedCtrls GetCurrentUser(string remark = "")
        {

            var requestUri = string.Format("/api/Check/GetUserWithAccessedCtrls?token={0}&requestid={1}", GetToken(), remark);

            try
            {
                var value = _helper.Get(null, requestUri);
                var result = JsonHelper.ToObject<CommonResult<UserWithAccessedCtrls>>(value);
                if (result.Success)
                {
                    return result.Result;
                }
                throw new Exception(result.ErrMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获取当前登录的用户名
        /// <para>通过URL中的Token参数或Cookie中的Token</para>
        /// </summary>
        /// <param name="remark">The remark.</param>
        /// <returns>System.String.</returns>
        public string GetUserName(string remark = "")
        {
            var requestUri = String.Format("/api/Check/GetUserName?token={0}&requestid={1}", GetToken(), remark);

            try
            {
                var value = _helper.Get(null, requestUri);
                var result = JsonHelper.ToObject<CommonResult<string>>(value);
                if (result.Success)
                {
                    return result.Result;
                }
                throw new Exception(result.ErrMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="appKey">应用程序key.</param>
        /// <param name="account">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>System.String.</returns>
        public LoginResult Login(string appKey, string account, string pwd)
        {
            try
            {
                var requestUri = string.Format("/api/Check/Login?account={0}&password={1}&systemCode={2}", account, pwd, appKey);

                try
                {
                    var value = _helper.Get(null, requestUri);
                    var result = JsonHelper.ToObject<LoginResult>(value);
                    if (result.Success)
                    {
                        return result;
                    }
                    throw new Exception(result.ErrMsg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        public bool Logout()
        {
            var token = GetToken();
            if (String.IsNullOrEmpty(token)) return true;

            var requestUri = String.Format("/api/Check/Logout?token={0}&requestid={1}", token, "");

            try
            {
                var value = _helper.Post(null, requestUri);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
