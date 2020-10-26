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
using Yuebon.AspNetCore.UI;
using Yuebon.Commons.Dtos;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class FilterIPController : AreaApiController<FilterIP, FilterIPOutputDto, FilterIPInputDto, IFilterIPService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public FilterIPController(IFilterIPService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "FilterIP/List";
            AuthorizeKey.InsertKey = "FilterIP/Add";
            AuthorizeKey.UpdateKey = "FilterIP/Edit";
            AuthorizeKey.UpdateEnableKey = "FilterIP/Enable";
            AuthorizeKey.DeleteKey = "FilterIP/Delete";
            AuthorizeKey.DeleteSoftKey = "FilterIP/DeleteSoft";
            AuthorizeKey.ViewKey = "FilterIP/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(FilterIP info)
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
        protected override void OnBeforeUpdate(FilterIP info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(FilterIP info)
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
        public override async Task<IActionResult> UpdateAsync(FilterIPInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            FilterIP info = iService.Get(id);
            info.FilterType = tinfo.FilterType;
            info.EndIP = tinfo.EndIP;
            info.StartIP = tinfo.StartIP;
            info.SortCode = tinfo.SortCode;
            info.EnabledMark = tinfo.EnabledMark;
            info.Description = tinfo.Description;

            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info, id).ConfigureAwait(true);
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
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public override async Task<CommonResult<PageResult<FilterIPOutputDto>>> FindWithPagerAsync([FromQuery]SearchInputDto<FilterIP> search)
        {
            CommonResult<PageResult<FilterIPOutputDto>> result = new CommonResult<PageResult<FilterIPOutputDto>>();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition(false);

            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (StartIP like '%{0}%' or EndIP like '%{0}%')", search.Keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<FilterIP> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<FilterIPOutputDto> resultList = list.MapTo<FilterIPOutputDto>();

            PageResult<FilterIPOutputDto> pageResult = new PageResult<FilterIPOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = resultList,
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            result.ResData = pageResult;
            result.ErrCode = ErrCode.successCode;
            return result;
        }
    }
}