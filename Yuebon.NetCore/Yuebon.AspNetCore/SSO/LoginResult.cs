using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.AspNetCore.SSO
{
    /// <summary>
    /// 登录返回结果
    /// </summary>
    public class LoginResult: CommonResult
    {
        /// <summary>
        /// 跳转Url
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
