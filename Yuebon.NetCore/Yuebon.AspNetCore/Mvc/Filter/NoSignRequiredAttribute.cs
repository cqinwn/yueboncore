namespace Yuebon.AspNetCore.Mvc.Filter;

/// <summary>
/// 不需要签名验证
/// </summary>
public class NoSignRequiredAttribute : ActionFilterAttribute
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
