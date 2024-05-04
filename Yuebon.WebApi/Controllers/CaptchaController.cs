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
    public CommonResult<AuthGetVerifyCodeOutputDto> CaptchaAsync()
    {
        var kvItem = CaptchaHelper.SimpleInput(4, false, true, false, false, false);
        var imgBase64 = kvItem.Key.Image_Base64.Substring(kvItem.Key.Image_Base64.IndexOf(',') + 1);

        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        TimeSpan expiresSliding = DateTime.Now.AddMinutes(5) - DateTime.Now;
        long vcodeId = IdGeneratorHelper.IdSnowflake();
        yuebonCacheHelper.Add(CacheConst.KeyVerCode+ vcodeId.ToString(), kvItem.Value.DataCode, expiresSliding,false);
        AuthGetVerifyCodeOutputDto authGetVerifyCodeOutputDto = new AuthGetVerifyCodeOutputDto();
        authGetVerifyCodeOutputDto.Img = imgBase64;
        authGetVerifyCodeOutputDto.Key = vcodeId.ToString();
        CommonResult<AuthGetVerifyCodeOutputDto> commonResult = new CommonResult<AuthGetVerifyCodeOutputDto>();
        commonResult.ErrCode= ErrCode.successCode;
        commonResult.Success = true;
        commonResult.ResData = authGetVerifyCodeOutputDto;
        return commonResult;
    }
}
