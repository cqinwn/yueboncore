using Microsoft.AspNetCore.Http;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Result;

namespace Yuebon.Extensions.Middlewares;

/// <summary>
/// Swagger UI 访问需要登录才能访问
/// </summary>
public class SwaggerBasicAuthMiddleware
{
    private readonly RequestDelegate next;


    public SwaggerBasicAuthMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 也可以根据是否是本地做判断 IsLocalRequest
        if (context.Request.Path.Value.ToLower().Contains("index.html"))
        {
            // 判断权限是否正确
            if (IsAuthorized(context))
            {
                await next.Invoke(context);
                return;
            }

            // 无权限，跳转swagger登录页
            context.Response.Redirect("/swg-login.html");
        }
        else
        {
            await next.Invoke(context);
        }
    }

    public bool IsAuthorized(HttpContext context)
    {
        // 使用session模式
        // 可以使用其他的
        string token=context.Request.Cookies["yuebon_soft_token"];
        CommonResult result = new CommonResult();
        TokenProvider tokenProvider = new TokenProvider();
        result = tokenProvider.ValidateToken(token);
        return result.Success;
    }
}
