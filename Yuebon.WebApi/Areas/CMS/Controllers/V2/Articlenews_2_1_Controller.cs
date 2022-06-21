using Yuebon.CMS.IServices;
using Yuebon.Commons.Attributes;

namespace Yuebon.WebApi.Areas.CMS.Controllers.V2;

/// <summary>
/// 文章，通知公告接口
/// </summary>
[ApiVersion("2.1")]
[SwaggerControllerView("文章", "2.0.1")]
[ApiController]
public class Articlenews_2_1_Controller : ArticlenewsController
{
    private IArticlecategoryService articlecategoryService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_iService"></param>
    /// <param name="_articlecategoryService"></param>
    public Articlenews_2_1_Controller(IArticlenewsService _iService, IArticlecategoryService _articlecategoryService) : base(_iService, _articlecategoryService)
    {
        articlecategoryService = _articlecategoryService;
        iService = _iService;
    }

    /// <summary>
    /// 获取分类及该分类文章标题
    /// </summary>
    [HttpGet("GetCategoryArticle")]
    [AllowAnonymous]
    public override async Task<IActionResult> GetCategoryArticle()
    {
        CommonResult result = new CommonResult();
        result.ResData = await iService.GetCategoryArticleList();
        result.ErrCode = ErrCode.successCode;
        result.ErrMsg = ErrCode.err0;
        return ToJsonContent(result);
    }
}
