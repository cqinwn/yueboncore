using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;

namespace Yuebon.WebApi.Areas.CMS.Controllers;

/// <summary>
/// 文章分类接口
/// </summary>
[ApiController]
[Route("api/CMS/[controller]")]
public class ArticlecategoryController : AreaApiController<Articlecategory, ArticlecategoryOutputDto,ArticlecategoryInputDto,IArticlecategoryService>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_iService"></param>
    public ArticlecategoryController(IArticlecategoryService _iService) : base(_iService)
    {
        iService = _iService;
    }
    /// <summary>
    /// 新增前处理数据
    /// </summary>
    /// <param name="info"></param>
    protected override void OnBeforeInsert(Articlecategory info)
    {
        info.Id = IdGeneratorHelper.IdSnowflake();
        info.CreatorTime = DateTime.Now;
        info.CreatorUserId = CurrentUser.UserId;
        info.DeleteMark = false;
        if (info.SortCode == null)
        {
            info.SortCode = 99;
        }
        if (info.ParentId == 0)
        {
            info.ClassLayer = 1;
            info.ParentId = 0;
        }
        else
        {
            info.ClassLayer = iService.GetById(info.ParentId).ClassLayer + 1;
        }
    }
    
    /// <summary>
    /// 在更新数据前对数据的修改操作
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    protected override void OnBeforeUpdate(Articlecategory info)
    {
        info.LastModifyUserId = CurrentUser.UserId;
        info.LastModifyTime = DateTime.Now;

        if (info.ParentId == 0)
        {
            info.ClassLayer = 1;
            info.ParentId = 0;
        }
        else
        {
            info.ClassLayer = iService.GetById(info.ParentId).ClassLayer + 1;
        }
    }

    /// <summary>
    /// 在软删除数据前对数据的修改操作
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    protected override void OnBeforeSoftDelete(Articlecategory info)
    {
        info.DeleteMark = true;
        info.DeleteTime = DateTime.Now;
        info.DeleteUserId = CurrentUser.UserId;
    }


    /// <summary>
    /// 异步更新数据
    /// </summary>
    /// <param name="tinfo"></param>
    /// <returns></returns>
    [HttpPost("Update")]
    [YuebonAuthorize("Edit")]
    public override async Task<IActionResult> UpdateAsync(ArticlecategoryInputDto tinfo)
    {
        CommonResult result = new CommonResult();

        Articlecategory info = iService.GetById(tinfo.Id);
        info.ParentId = tinfo.ParentId;
        info.Title = tinfo.Title;
        info.EnabledMark = tinfo.EnabledMark;
        info.SortCode = tinfo.SortCode;
        info.Description = tinfo.Description;

        OnBeforeUpdate(info);
        bool bl = await iService.UpdateAsync(info);
        if (bl)
        {
            result.ErrCode = ErrCode.successCode;
            result.ErrMsg = ErrCode.err0;
        }
        else
        {
            result.ErrMsg = ErrCode.err43002;
            result.ErrCode = "43002";
        }
        return ToJsonContent(result);
    }
    /// <summary>
    /// 获取文章分类适用于Vue 树形列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllCategoryTreeTable")]
    [YuebonAuthorize("List")]
    public async Task<IActionResult> GetAllCategoryTreeTable(string keyword)
    {
        CommonResult result = new CommonResult();
        try
        {
            List<ArticlecategoryOutputDto> list = await iService.GetAllArticlecategoryTreeTable(keyword);
            result.Success = true;
            result.ErrCode = ErrCode.successCode;
            result.ResData = list;
        }
        catch (Exception ex)
        {
            Log4NetHelper.Error("获取分类异常", ex);
            result.ErrMsg = ErrCode.err40110;
            result.ErrCode = "40110";
        }
        return ToJsonContent(result);
    }

    /// <summary>
    /// 异步批量物理删除
    /// </summary>
    /// <param name="info"></param>
    [HttpDelete("DeleteBatchAsync")]
    [YuebonAuthorize("Delete")]
    public override async Task<IActionResult> DeleteBatchAsync(DeletesInputDto info)
    {
        CommonResult result = new CommonResult();
        if (info.Ids.Length > 0)
        {
            result = await iService.DeleteBatchWhereAsync(info).ConfigureAwait(false);
            if (result.Success)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrCode = "43003";
            }
        }
        return ToJsonContent(result);
    }
}