﻿using Yuebon.CMS.IServices;
using Yuebon.Commons.Attributes;

namespace Yuebon.WebApi.Areas.CMS.Controllers.V1;

/// <summary>
/// 文章，通知公告接口
/// </summary>
[ApiController]
[SwaggerControllerView("文章","1.0.0")]
public class Articlenews_1_0_0_Controller : ArticlenewsController
{
    private IArticlecategoryService articlecategoryService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_iService"></param>
    /// <param name="_articlecategoryService"></param>
    public Articlenews_1_0_0_Controller(IArticlenewsService _iService, IArticlecategoryService _articlecategoryService) : base(_iService, _articlecategoryService)
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
