using Yuebon.Commons.Pages;
using Yuebon.Security.Application.Dtos;

namespace Yuebon.SecurityApi.Areas.Security.Controllers;

/// <summary>
/// 访问/操作日志接口
/// </summary>
[ApiController]
[Route("api/Security/[controller]")]
public class VisitLogController : AreaApiController<VisitLog, VisitlogOutputDto,VisitLogInputDto,IVisitlogService>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_iService"></param>
    public VisitLogController(IVisitlogService _iService) : base(_iService)
    {
        iService = _iService;
    }


    /// <summary>
    /// 异步分页查询
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpPost("FindWithPagerSearchAsync")]
    [YuebonAuthorize("List")]
    public async Task<IActionResult> FindWithPagerSearchAsync(SearchVisitLogModel search)
    {
        CommonResult<PageResult<VisitlogOutputDto>> result = new CommonResult<PageResult<VisitlogOutputDto>>();
        result.ResData = await iService.FindWithPagerSearchAsync(search);
        result.ErrCode = ErrCode.successCode;
        return ToJsonContent(result);
    }
}