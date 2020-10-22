using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
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
            // HttpContext.Session.SetString("LoginValidateCode", code);
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            TimeSpan expiresSliding = DateTime.Now.AddMinutes(2) - DateTime.Now;
            yuebonCacheHelper.Add("LoginValidateCode", code, expiresSliding,false);
            return File(result.CaptchaMemoryStream.ToArray(), "image/png");
        }
    }
}
