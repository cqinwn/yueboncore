using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Models;
using Yuebon.Commons.Net;
using Yuebon.Commons.VerificationCode;
using Yuebon.Security.Dtos;

namespace Yuebon.WebApi.Controllers
{
    /// <summary>
    /// 验证码接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ApiController
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [NoPermissionRequired]
        public async Task<CommonResult<AuthGetVerifyCodeOutputDto>> CaptchaAsync()
        {
            Captcha captcha = new Captcha();
            var code =await  captcha.GenerateRandomCaptchaAsync().ConfigureAwait(false);
            var result =await  captcha.GenerateCaptchaImageAsync(code);
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            TimeSpan expiresSliding = DateTime.Now.AddMinutes(5) - DateTime.Now;
            
            yuebonCacheHelper.Add("ValidateCode"+ result.Timestamp.ToString("yyyyMMddHHmmssffff"), code, expiresSliding,false);
            AuthGetVerifyCodeOutputDto authGetVerifyCodeOutputDto = new AuthGetVerifyCodeOutputDto();
            authGetVerifyCodeOutputDto.Img =Convert.ToBase64String(result.CaptchaMemoryStream.ToArray());
            authGetVerifyCodeOutputDto.Key = result.Timestamp.ToString("yyyyMMddHHmmssffff");
            CommonResult<AuthGetVerifyCodeOutputDto> commonResult = new CommonResult<AuthGetVerifyCodeOutputDto>();
            commonResult.ErrCode= ErrCode.successCode;
            commonResult.ResData = authGetVerifyCodeOutputDto;
            return commonResult;
        }
    }
}
