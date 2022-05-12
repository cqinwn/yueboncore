using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Models;
using Yuebon.CMS.IServices;
using Yuebon.Commons.Attributes;
using Yuebon.Commons.Models;

namespace Yuebon.WebApi.Areas.CMS.Controllers.V1
{
    /// <summary>
    /// 文章，通知公告接口
    /// </summary>
    [ApiVersion("1.1")]
    [ApiController]
    [SwaggerControllerView("文章", "1.0.1")]
    public class Articlenews_1_1_Controller : ArticlenewsController
    {
        private IArticlecategoryService articlecategoryService;
        public Articlenews_1_1_Controller(IArticlenewsService _iService, IArticlecategoryService _articlecategoryService) : base(_iService, _articlecategoryService)
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
}
