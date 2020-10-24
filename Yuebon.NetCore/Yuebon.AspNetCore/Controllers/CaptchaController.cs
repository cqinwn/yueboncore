using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Net;
using Yuebon.Commons.VerificationCode;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ApiController
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="captcha"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [NoPermissionRequired]
        public async Task<IActionResult> CaptchaAsync()
        {
            Captcha captcha = new Captcha();
            var code =await  captcha.GenerateRandomCaptchaAsync();
            var result =await  captcha.GenerateCaptchaImageAsync(code);
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            TimeSpan expiresSliding = DateTime.Now.AddMinutes(1) - DateTime.Now;
            yuebonCacheHelper.Add("ValidateCode"+ strIp, code, expiresSliding,false);
            return File(result.CaptchaMemoryStream.ToArray(), "image/png");
        }
    }
}
