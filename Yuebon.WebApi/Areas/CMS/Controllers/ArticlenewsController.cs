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

namespace Yuebon.WebApi.Areas.CMS.Controllers
{
    /// <summary>
    /// 文章，通知公告接口
    /// </summary>
    [ApiController]
    [Route("api/CMS/[controller]")]
    public class ArticlenewsController : AreaApiController<Articlenews, ArticlenewsOutputDto,ArticlenewsInputDto,IArticlenewsService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public ArticlenewsController(IArticlenewsService _iService) : base(_iService)
        {
            iService = _iService;
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
    }
}