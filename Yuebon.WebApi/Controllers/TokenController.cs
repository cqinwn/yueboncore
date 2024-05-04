using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Asp.Versioning;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yuebon.WebApi.Controllers;

/// <summary>
/// Token令牌接口控制器
/// </summary>
[Route("api/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class TokenController : ControllerBase
{
    private  readonly IAPPService _iAPPService;
    private readonly JwtOption _jwtModel;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="iAPPService"></param>
    /// <param name="jwtModel"></param>
    public TokenController(IAPPService iAPPService,  JwtOption jwtModel)
    {
        _iAPPService = iAPPService;
        _jwtModel = jwtModel;
    }

    /// <summary>
    /// 根据应用信息获得token令牌
    /// </summary>
    /// <param name="grant_type">获取access_token填写client_credential</param>
    /// <param name="appid">应用唯一凭证，应用AppId</param>
    /// <param name="secret">应用密钥AppSecret</param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get(string grant_type, string appid, string secret)
    {
        CommonResult result = new CommonResult();
        if (!grant_type.Equals(GrantType.ClientCredentials))
        {
            result.ErrCode = "40003";
            result.ErrMsg = ErrCode.err40003;
            return ToJsonContent(result);
        }
        else if(string.IsNullOrEmpty(grant_type))
        {
            result.ErrCode = "40003";
            result.ErrMsg = ErrCode.err40003;
            return ToJsonContent(result);
        }
        string strHost = Request.Headers["Origin"].ToString();
        APP app =await _iAPPService.GetAPP(appid, secret);
        if (app == null)
        {
            result.ErrCode = "40001";
            result.ErrMsg = ErrCode.err40001;
        }
        else
        {
            if (!app.RequestUrl.Contains(strHost))
            {
                result.ErrCode = "40002";
                result.ErrMsg = ErrCode.err40002+"，你当前请求主机："+strHost+ ",请参考：http://docs.v.yuebon.com/guide/faq.html#%E6%8F%90%E7%A4%BA%E9%9C%80%E8%A6%81%E6%8E%88%E6%9D%83%E6%80%8E%E4%B9%88%E5%8A%9E";
            }
            else
            {
                TokenProvider tokenProvider = new TokenProvider(_jwtModel);
                TokenResult tokenResult = tokenProvider.GenerateToken(grant_type, appid, secret);
                result.ResData = tokenResult;
                result.ErrCode = "0";
                return ToJsonContent(result);
            }
        }
        return ToJsonContent(result);
    }


    /// <summary>
    /// 验证token的合法性。
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("CheckToken")]
    [AllowAnonymous]
    public IActionResult CheckToken(string token)
    {
        CommonResult result = new CommonResult();
        TokenProvider tokenProvider = new TokenProvider(_jwtModel);
        result = tokenProvider.ValidateToken(token);
        return ToJsonContent(result);
    }


    /// <summary>
    /// 刷新token。
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("RefreshToken")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken(string token)
    {
        CommonResult result = new CommonResult();
        TokenProvider tokenProvider = new TokenProvider(_jwtModel);
        if (!string.IsNullOrEmpty(token))
        {
            JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            #if DEBUG
            Log4NetHelper.Debug(jwtToken.ToJson());
            #endif
            if (jwtToken != null)
            {
                //根据应用获取token
                if (jwtToken.Subject == GrantType.ClientCredentials)
                {
                    TokenResult tresult = new TokenResult();
                    var claimlist = jwtToken?.Payload.Claims as List<Claim>;
                    string strHost = Request.Host.ToString();
                    APP app = await _iAPPService.GetAPP(claimlist[0].Value);
                    if (app == null)
                    {
                        result.ErrCode = "40001";
                        result.ErrMsg = ErrCode.err40001;
                    }
                    else
                    {
                        if (!app.RequestUrl.Contains(strHost))
                        {
                            result.ErrCode = "40002";
                            result.ErrMsg = ErrCode.err40002 + "，你当前请求主机：" + strHost;
                        }
                        else
                        {
                            TokenResult tokenResult = tokenProvider.GenerateToken(GrantType.ClientCredentials, app.AppId, app.AppSecret);
                            result.ResData = tokenResult;
                            result.ErrCode = "0";
                            result.Success = true;
                        }
                    }
                }
                // 用户账号密码登录获取token类型
                if (jwtToken.Subject == GrantType.Password)
                {
                    var claimlist = jwtToken?.Payload.Claims as List<Claim>;
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    UserInfo userInfo = yuebonCacheHelper.Get<UserInfo>(CacheConst.KeyLoginUserInfo + claimlist[3].Value);
                    TokenResult tokenResult = tokenProvider.LoginToken(userInfo, claimlist[0].Value);
                    TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                    yuebonCacheHelper.Replace(CacheConst.KeyLoginUserInfo + claimlist[3].Value, userInfo, expiresSliding,true);
                    result.ResData = tokenResult;
                    result.ErrCode = "0";
                    result.Success = true;
                }
            }
            else
            {
                result.ErrMsg = ErrCode.err40004;
                result.ErrCode = "40004";
            }
        }
        else
        {
            result.ErrMsg = ErrCode.err40004;
            result.ErrCode = "40004";
        }
        return ToJsonContent(result);
    }
    /// <summary>
    /// 把object对象转换为ContentResult
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("api/ToJsonContent")]
    protected IActionResult ToJsonContent(object obj)
    {
        string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return Content(obj.ToJson());
    }

}
