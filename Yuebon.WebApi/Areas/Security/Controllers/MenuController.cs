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
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.ViewModel;
using System.Linq;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Core.Dtos;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 功能菜单接口
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

            if (info.MenuType == "F")
            {
                info.IsFrame = false;
                info.Component = "";
                info.UrlAddress = "";
            }

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public override async Task<IActionResult> InsertAsync(MenuInputDto info)
        {
            CommonResult result = new CommonResult();
            Menu menu = info.MapTo<Menu>();
            long ln = 0;
            if (info.IsBatch)
            {
                string strEnCode = info.EnCode;
                Menu listInfo = new Menu();
                listInfo = menu;
                listInfo.FullName ="列表";
                listInfo.EnCode = strEnCode + "/List";
                listInfo.Icon = "list";
                OnBeforeInsert(listInfo);
                string listId = info.ParentId;
                ln = iService.Insert(listInfo);

                Menu addInfo = new Menu();
                addInfo = menu;
                addInfo.Id = GuidUtils.CreateNo();
                addInfo.FullName = "新增";
                addInfo.EnCode = strEnCode + "/Add";
                addInfo.ParentId = listId;
                addInfo.Icon = "add";
                addInfo.SortCode = 1;
                OnBeforeInsert(addInfo);
                ln = iService.Insert(addInfo);

                Menu viewInfo = new Menu();
                viewInfo = menu;
                viewInfo.Id = GuidUtils.CreateNo();
                viewInfo.FullName = "查看";
                viewInfo.EnCode = strEnCode + "/View";
                viewInfo.ParentId = listId;
                viewInfo.Icon = "eye-open";
                viewInfo.SortCode = 1;
                OnBeforeInsert(viewInfo);
                ln = iService.Insert(viewInfo);

                Menu editnfo = new Menu();
                editnfo = menu;
                editnfo.Id = GuidUtils.CreateNo();
                editnfo.FullName = "修改";
                editnfo.EnCode = strEnCode + "/Edit";
                editnfo.ParentId = listId;
                editnfo.Icon = "write";
                editnfo.SortCode = 2;
                OnBeforeInsert(editnfo);
                ln = iService.Insert(editnfo);


                Menu enableInfo = new Menu();
                enableInfo = menu;
                enableInfo.Id = GuidUtils.CreateNo();
                enableInfo.FullName = "禁用";
                enableInfo.EnCode = strEnCode + "/Enable";
                enableInfo.ParentId = listId;
                enableInfo.Icon = "pause";
                enableInfo.SortCode = 3;
                OnBeforeInsert(enableInfo);
                ln = iService.Insert(enableInfo);


                Menu enableInfo1 = new Menu();
                enableInfo1 = menu;
                enableInfo1.Id = GuidUtils.CreateNo();
                enableInfo1.FullName = "启用";
                enableInfo1.EnCode = strEnCode + "/Enable";
                enableInfo1.ParentId = listId;
                enableInfo1.Icon = "play";
                enableInfo1.SortCode = 4;
                OnBeforeInsert(enableInfo1);
                ln = iService.Insert(enableInfo1);


                Menu deleteSoftInfo = new Menu();
                deleteSoftInfo = menu;
                deleteSoftInfo.Id = GuidUtils.CreateNo();
                deleteSoftInfo.FullName = "软删除";
                deleteSoftInfo.EnCode = strEnCode + "/DeleteSoft";
                deleteSoftInfo.ParentId = listId;
                deleteSoftInfo.Icon = "remove";
                deleteSoftInfo.SortCode = 5;
                OnBeforeInsert(deleteSoftInfo);
                ln = iService.Insert(deleteSoftInfo);


                Menu deleteInfo = new Menu();
                deleteInfo = menu;
                deleteInfo.Id = GuidUtils.CreateNo();
                deleteInfo.FullName = "删除";
                deleteInfo.EnCode = strEnCode + "/Delete";
                deleteInfo.ParentId = listId;
                deleteInfo.Icon = "remove";
                deleteInfo.SortCode = 6;
                OnBeforeInsert(deleteInfo);
                ln = iService.Insert(deleteInfo);
            }
            else
            {
                OnBeforeInsert(menu);
                ln = await iService.InsertAsync(menu);
            }

            if (ln >= 0)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
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
            info.ParentId= tinfo.ParentId;
            info.Icon = tinfo.Icon;
            info.EnabledMark = tinfo.EnabledMark;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;
            info.MenuType = tinfo.MenuType;
            info.ActiveMenu = tinfo.ActiveMenu;
            if (info.MenuType == "F")
            {
                info.IsFrame = false;
                info.Component = "";
                info.UrlAddress = "";
            }
            else
            {
                info.Component = tinfo.Component;
                info.IsFrame = tinfo.IsFrame;
                info.UrlAddress = tinfo.UrlAddress;
            }
            info.IsShow = tinfo.IsShow;


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


        /// <summary>
        /// 异步批量物理删除
        /// </summary>
        /// <param name="info"></param>
        [HttpDelete("DeleteBatchAsync")]
        [YuebonAuthorize("Delete")]
        public override async Task<IActionResult> DeleteBatchAsync(DeletesInputDto info)
        {
            CommonResult result = new CommonResult();
             
            if (info.Ids.Length>0)
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
}