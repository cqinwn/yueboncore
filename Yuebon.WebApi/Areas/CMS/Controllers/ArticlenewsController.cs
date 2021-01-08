using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.Models;
using Yuebon.CMS.IServices;
using Yuebon.AspNetCore.Mvc;

namespace Yuebon.WebApi.Areas.CMS.Controllers
{
    /// <summary>
    /// 文章，通知公告接口
    /// </summary>
    [ApiController]
    [Route("api/CMS/[controller]")]
    public class ArticlenewsController : AreaApiController<Articlenews, ArticlenewsOutputDto,ArticlenewsInputDto,IArticlenewsService,string>
    {
        private IArticlecategoryService articlecategoryService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_articlecategoryService"></param>
        public ArticlenewsController(IArticlenewsService _iService,IArticlecategoryService _articlecategoryService) : base(_iService)
        {
            iService = _iService;
            articlecategoryService = _articlecategoryService;
            AuthorizeKey.ListKey = "Articlenews/List";
            AuthorizeKey.InsertKey = "Articlenews/Add";
            AuthorizeKey.UpdateKey = "Articlenews/Edit";
            AuthorizeKey.UpdateEnableKey = "Articlenews/Enable";
            AuthorizeKey.DeleteKey = "Articlenews/Delete";
            AuthorizeKey.DeleteSoftKey = "Articlenews/DeleteSoft";
            AuthorizeKey.ViewKey = "Articlenews/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Articlenews info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CategoryName = articlecategoryService.Get(info.CategoryId).Title;
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Articlenews info)
        {
            info.CategoryName = articlecategoryService.Get(info.CategoryId).Title;
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Articlenews info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }


        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(ArticlenewsInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            Articlenews info = iService.Get(id);
            info.CategoryId = tinfo.CategoryId;
            info.Title = tinfo.Title;
            info.EnabledMark = tinfo.EnabledMark;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;

            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info, id).ConfigureAwait(false);
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
    }
}