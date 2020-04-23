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
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.UI;

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
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public override async Task<IActionResult> FindWithPagerAsync([FromQuery]SearchModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (!string.IsNullOrEmpty(search.EnCode))
            {
                Function function = await iService.GetWhereAsync("EnCode='"+ search.EnCode + "'");
                if (function != null)
                {
                    where += "and ParentId='" + function.Id + "'";
                }
            }
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                    where += "and (FullName like '%" + search.Keywords + "%' or EnCode like '%" + search.Keywords + "%')";
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<Function> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<FunctionOutputDto> resultList = list.MapTo<FunctionOutputDto>();
            PageResult<FunctionOutputDto> pageResult = new PageResult<FunctionOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = resultList,
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            result.ResData = pageResult;
            result.ErrCode = ErrCode.successCode;
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