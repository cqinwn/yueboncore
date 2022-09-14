namespace Yuebon.AspNetCore.Controllers;

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
    public YuebonCurrentUser CurrentUser;

    #region 
    /// <summary>
    /// 重写基类在Action执行之前的事情
    /// 根据token获得当前用户，允许匿名的不需要获取用户
    /// </summary>
    /// <param name="context">重写方法的参数</param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        try
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            //匿名访问，不需要token认证、签名和登录
            var allowanyone = controllerActionDescriptor.MethodInfo.GetCustomAttribute(typeof(AllowAnonymousAttribute), true);
            if (allowanyone != null) return;

            CommonResult result = new CommonResult();
            //需要token认证
            string authHeader = context.HttpContext.Request.Headers["Authorization"];//Header中的token
            if (string.IsNullOrEmpty(authHeader))
            {
                result.ErrCode = "40004";
                result.ErrMsg = ErrCode.err40004;
                context.Result = ToJsonContent(result);
                return;
            }
            else
            {
                string token = string.Empty;
                if (authHeader != null && authHeader.StartsWith("Bearer ", StringComparison.Ordinal)) token = authHeader.Substring(7);
                TokenProvider tokenProvider = new TokenProvider();
                result = tokenProvider.ValidateToken(token);
                //token验证失败
                if (!result.Success)
                {
                    context.Result = ToJsonContent(result);
                }
                else
                {
                    #region 签名验证
                    bool boolSign = context.HttpContext.Request.Headers["sign"].SingleOrDefault().ToBool(true);
                    var isSign = controllerActionDescriptor.MethodInfo.GetCustomAttribute(typeof(NoSignRequiredAttribute), true);
                    //需要签名验证
                    if (isSign == null && boolSign)
                    {
                        CommonResult resultSign = SignHelper.CheckSign(context.HttpContext);
                         if (!resultSign.Success)
                        {
                            context.Result = ToJsonContent(resultSign);
                            return;
                        }
                    }
                    #endregion

                    #region 是否需要验证用户登录以及相关的功能权限
                    //是否需要用户登录
                    var isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttribute(typeof(NoPermissionRequiredAttribute));
                    //不需要登录
                    if (isDefined != null) return;
                    //需要登录和验证功能权限
                    if (result.ResData != null)
                    {
                        List<Claim> claimlist = result.ResData as List<Claim>;
                        string userId = claimlist[3].Value;

                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        var user = yuebonCacheHelper.Get<YuebonCurrentUser>("login_user_" + userId);
                        if (user != null)
                        {
                            CurrentUser = user;
                        }

                        var claims = new[] {
                           new Claim(YuebonClaimConst.UserId,userId),
                           new Claim(YuebonClaimConst.UserName,claimlist[2].Value),
                           new Claim(YuebonClaimConst.Role,claimlist[4].Value),
                           new Claim(YuebonClaimConst.TenantId,claimlist[5].Value),
                           new Claim(YuebonClaimConst.RealName,CurrentUser?.RealName)
                        };
                        var identity = new ClaimsIdentity(claims);
                        var principal = new ClaimsPrincipal(identity);
                        context.HttpContext.User = Appsettings.UserClaims= principal;
                        bool isAdmin = Permission.IsAdmin(user);
                        if (!isAdmin)
                        {                                
                            var authorizeAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(YuebonAuthorizeAttribute), true).OfType<YuebonAuthorizeAttribute>();
                            if (authorizeAttributes.FirstOrDefault() != null)
                            {
                                string function = authorizeAttributes.First().Function;
                                if (!string.IsNullOrEmpty(function))
                                {
                                    string functionCode = controllerActionDescriptor.ControllerName + "/" + function;

                                    bool bl = Permission.HasFunction(functionCode, userId);
                                    if (!bl)
                                    {
                                        result.ErrCode = "403";
                                        result.ErrMsg = ErrCode.err403;
                                        context.Result = ToJsonContent(result);
                                    }
                                }
                            }
                        }
                        return;
                    }
                    else
                    {
                        result.ErrCode = "40008";
                        result.ErrMsg = ErrCode.err40008;
                        context.Result = ToJsonContent(result);
                    }
                    #endregion

                }
                return;
            }
        }
        catch (Exception ex)
        {
            Log4NetHelper.Error("", ex);
            throw ex;
        }
    }
    #endregion

    /// <summary>
    /// 把object对象转换为ContentResult
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("api/ToJsonContent")]
    protected IActionResult ToJsonContent(object obj)
    {
        return Content(obj.ToJson());
    }


    /// <summary>
    /// 把object对象转换为ContentResult
    /// </summary>
    /// <param name="obj">转换对象</param>
    /// <param name="isNull">是否忽略空值</param>
    /// <returns></returns>
    [HttpPost]
    [Route("api/ToJsonContent")]
    protected IActionResult ToJsonContent(object obj,bool isNull=false)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,                                   //格式化json字符串
            AllowTrailingCommas = true,                             //可以结尾有逗号
            //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,//忽略 null 值 net6.0中IgnoreNullValues 已过时
            IgnoreReadOnlyProperties = true,                        //忽略只读属性
            PropertyNameCaseInsensitive = true,                     //忽略大小写
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        options.Converters.Add(new DateTimeJsonConverter());
        options.Converters.Add(new LongJsonConverter());
        return Content(JsonSerializer.Serialize(obj, options));
    }

    /// <summary>
    /// 根据Request参数获取分页对象数据
    /// </summary>
    /// <returns></returns>
    protected virtual PagerInfo GetPagerInfo()
    {
        int pageSize = Request.Query["length"].ToString() == null ? 1 : Request.Query["length"].ToString().ToInt();
        int pageIndex = 1;
        string currentPage = Request.Query["CurrentPage"].ToString();
        if (string.IsNullOrWhiteSpace(currentPage))
        {
            string start = Request.Query["start"].ToString();
            if (!string.IsNullOrWhiteSpace(start))
            {
                pageIndex = (start.ToInt() / pageSize) + 1;
            }
        }
        else
        {
            pageIndex = currentPage.ToInt();
        }
        PagerInfo pagerInfo = new PagerInfo();
        pagerInfo.CurrenetPageIndex = pageIndex;
        pagerInfo.PageSize = pageSize;
        return pagerInfo;
    }

    /// <summary>
    /// 获取token
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetToken")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
