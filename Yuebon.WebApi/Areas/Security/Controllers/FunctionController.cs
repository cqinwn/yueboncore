using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 模块功能接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class FunctionController : AreaApiController<Function, FunctionOutputDto, FunctionInputDto, IFunctionService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public FunctionController(IFunctionService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "Function/List";
            AuthorizeKey.InsertKey = "Function/Add";
            AuthorizeKey.UpdateKey = "Function/Edit";
            AuthorizeKey.UpdateEnableKey = "Function/Enable";
            AuthorizeKey.DeleteKey = "Function/Delete";
            AuthorizeKey.DeleteSoftKey = "Function/DeleteSoft";
            AuthorizeKey.ViewKey = "Function/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Function info)
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
        protected override void OnBeforeUpdate(Function info)
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
        protected override void OnBeforeSoftDelete(Function info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public override async Task<IActionResult> InsertAsync(FunctionInputDto info)
        {
            CommonResult result = new CommonResult();
            Function function = info.MapTo<Function>();
            long ln = 0;
            if (info.IsBatch)
            {
                string strEnCode = info.EnCode;
                Function listInfo = new Function();
                listInfo = function;
                listInfo.FullName = info.FullName + "列表";
                listInfo.EnCode = strEnCode + "/List";
                listInfo.Icon = "";
                OnBeforeInsert(listInfo);
                string listId = listInfo.Id;
                ln = iService.Insert(listInfo);

                Function addInfo = new Function();
                addInfo = function;
                addInfo.Id = GuidUtils.CreateNo();
                addInfo.FullName = "新增";
                addInfo.EnCode = strEnCode + "/Add";
                addInfo.ParentId = listId;
                addInfo.Icon = "el-icon-plus";
                addInfo.SortCode = 1;
                OnBeforeInsert(addInfo);
                ln = iService.Insert(addInfo);

                Function editnfo = new Function();
                editnfo = function;
                editnfo.Id = GuidUtils.CreateNo();
                editnfo.FullName = "修改";
                editnfo.EnCode = strEnCode + "/Edit";
                editnfo.ParentId = listId;
                editnfo.Icon = "el-icon-edit";
                editnfo.SortCode = 2;
                OnBeforeInsert(editnfo);
                ln = iService.Insert(editnfo);


                Function enableInfo = new Function();
                enableInfo = function;
                enableInfo.Id = GuidUtils.CreateNo();
                enableInfo.FullName = "禁用";
                enableInfo.EnCode = strEnCode + "/Enable";
                enableInfo.ParentId = listId;
                enableInfo.Icon = "el-icon-video-pause";
                enableInfo.SortCode = 3;
                OnBeforeInsert(enableInfo);
                ln = iService.Insert(enableInfo);


                Function enableInfo1 = new Function();
                enableInfo1 = function;
                enableInfo1.Id = GuidUtils.CreateNo();
                enableInfo1.FullName = "启用";
                enableInfo1.EnCode = strEnCode + "/Enable";
                enableInfo1.ParentId = listId;
                enableInfo1.Icon = "el-icon-video-play";
                enableInfo1.SortCode = 4;
                OnBeforeInsert(enableInfo1);
                ln = iService.Insert(enableInfo1);


                Function deleteSoftInfo = new Function();
                deleteSoftInfo = function;
                deleteSoftInfo.Id = GuidUtils.CreateNo();
                deleteSoftInfo.FullName = "软删除";
                deleteSoftInfo.EnCode = strEnCode + "/DeleteSoft";
                deleteSoftInfo.ParentId = listId;
                deleteSoftInfo.Icon = "el-icon-delete";
                deleteSoftInfo.SortCode = 5;
                OnBeforeInsert(deleteSoftInfo);
                ln = iService.Insert(deleteSoftInfo);


                Function deleteInfo = new Function();
                deleteInfo = function;
                deleteInfo.Id = GuidUtils.CreateNo();
                deleteInfo.FullName = "删除";
                deleteInfo.EnCode = strEnCode + "/Delete";
                deleteInfo.ParentId = listId;
                deleteInfo.Icon = "el-icon-delete";
                deleteInfo.SortCode = 6;
                OnBeforeInsert(deleteInfo);
                ln = iService.Insert(deleteInfo);
            }
            else
            {
                OnBeforeInsert(function);
                ln = await iService.InsertAsync(function);
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
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(FunctionInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            Function info = iService.Get(id);
            info.FullName = tinfo.FullName;
            info.EnCode = tinfo.EnCode;
            info.SystemTypeId = tinfo.SystemTypeId;
            info.ParentId = tinfo.ParentId;
            info.Icon = tinfo.Icon;
            info.EnabledMark = tinfo.EnabledMark;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;
            info.IsPublic = tinfo.IsPublic;


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
        /// 根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限
        /// </summary>
        /// <param name="enCode">菜单功能编码</param>
        /// <returns></returns>
        [HttpGet("GetListByItemCode")]
        [NoPermissionRequired]
        public async Task<IActionResult> GetListByItemCode(string enCode)
        {
            CommonResult result = new CommonResult();
            try
            {
                IEnumerable<FunctionOutputDto> list = await iService.GetListByParentEnCode(enCode);
                result.ErrCode = ErrCode.successCode;
                result.ResData = list;
            }
            catch(Exception ex)
            {
                Log4NetHelper.Error("", ex);
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 获取功能菜单适用于Vue 树形列表
        /// </summary>
        /// <param name="systemTypeId">子系统Id</param>
        /// <returns></returns>
        [HttpGet("GetAllFunctionTreeTable")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllFunctionTreeTable(string systemTypeId)
        {
            CommonResult result = new CommonResult();
            try
            {
                List<FunctionTreeTableOutputDto> list = await iService.GetAllFunctionTreeTable(systemTypeId);
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ResData = list;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取菜单异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }


    }
}