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
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;
using Yuebon.AspNetCore.Mvc;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class MenuController : AreaApiController<Menu, MenuOutputDto, MenuInputDto, IMenuService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public MenuController(IMenuService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "Menu/List";
            AuthorizeKey.InsertKey = "Menu/Add";
            AuthorizeKey.UpdateKey = "Menu/Edit";
            AuthorizeKey.UpdateEnableKey = "Menu/Enable";
            AuthorizeKey.DeleteKey = "Menu/Delete";
            AuthorizeKey.DeleteSoftKey = "Menu/DeleteSoft";
            AuthorizeKey.ViewKey = "Menu/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Menu info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.Layers = 1;
                info.ParentId = "";
            }
            else
            {
                info.Layers = iService.Get(info.ParentId).Layers + 1;
            }
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Menu info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.Layers = 1;
                info.ParentId = "";
            }
            else
            {
                info.Layers = iService.Get(info.ParentId).Layers + 1;
            }
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Menu info)
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
        public override async Task<IActionResult> UpdateAsync(MenuInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            Menu info = iService.Get(id);
            info.FullName = tinfo.FullName;
            info.EnCode = tinfo.EnCode;
            info.SystemTypeId = tinfo.SystemTypeId;
            info.UrlAddress = tinfo.UrlAddress;
            info.ParentId= tinfo.ParentId;
            info.Icon = tinfo.Icon;
            info.EnabledMark = tinfo.EnabledMark;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;
            info.IsMenu = tinfo.IsMenu;


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
        /// <summary>
        /// 获取功能菜单适用于Vue 树形列表
        /// </summary>
        /// <param name="systemTypeId">子系统Id</param>
        /// <returns></returns>
        [HttpGet("GetAllMenuTreeTable")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllMenuTreeTable(string systemTypeId)
        {
            CommonResult result = new CommonResult();
            try
            {
                List<MenuTreeTableOutputDto> list = await iService.GetAllMenuTreeTable(systemTypeId);
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ResData = list;
            }catch(Exception ex)
            {
                Log4NetHelper.Error("获取菜单异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }
    }
}