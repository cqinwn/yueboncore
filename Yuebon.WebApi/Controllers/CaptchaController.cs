using Yuebon.Commons.VerificationCode;

namespace Yuebon.WebApi.Controllers;

/// <summary>
/// 验证码接口
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
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
        var code =await  captcha.GenerateRandomCaptchaAsync();
        var result =await  captcha.GenerateCaptchaImageAsync(code);
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        TimeSpan expiresSliding = DateTime.Now.AddMinutes(5) - DateTime.Now;
        long vcodeId = IdGeneratorHelper.IdSnowflake();
        yuebonCacheHelper.Add("ValidateCode"+ vcodeId.ToString(), code, expiresSliding,false);
        AuthGetVerifyCodeOutputDto authGetVerifyCodeOutputDto = new AuthGetVerifyCodeOutputDto();
        authGetVerifyCodeOutputDto.Img =Convert.ToBase64String(result.CaptchaMemoryStream.ToArray());
        authGetVerifyCodeOutputDto.Key = vcodeId.ToString();
        CommonResult<AuthGetVerifyCodeOutputDto> commonResult = new CommonResult<AuthGetVerifyCodeOutputDto>();
        commonResult.ErrCode= ErrCode.successCode;
        commonResult.ResData = authGetVerifyCodeOutputDto;
        return commonResult;
    }
}
