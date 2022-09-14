namespace Yuebon.AspNetCore.Mvc.Filter;

/// <summary>
/// 不需要权限验证,不需要登录
/// </summary>
public class NoPermissionRequiredAttribute : ActionFilterAttribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterContext"></param>
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
    }
}
