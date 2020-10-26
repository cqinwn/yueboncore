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
using Yuebon.AspNetCore.UI;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Dtos;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class LogController : AreaApiController<Log, LogOutputDto, LogInputDto, ILogService, string>
    {

        private IOrganizeService organizeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_organizeService"></param>
        public LogController(ILogService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;

            AuthorizeKey.ListKey = "Log/List";
            AuthorizeKey.InsertKey = "Log/Add";
            AuthorizeKey.UpdateKey = "Log/Edit";
            AuthorizeKey.UpdateEnableKey = "Log/Enable";
            AuthorizeKey.DeleteKey = "Log/Delete";
            AuthorizeKey.DeleteSoftKey = "Log/DeleteSoft";
            AuthorizeKey.ViewKey = "Log/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Log info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Log info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Log info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }


        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPager1Async")]
        [YuebonAuthorize("List")]
        public async Task<CommonResult<PageResult<LogOutputDto>>> FindWithPager1Async([FromQuery]SearchInputDto<Log> search)
        {
            CommonResult<PageResult<LogOutputDto>> result = new CommonResult<PageResult<LogOutputDto>>();
            //string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            //string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            //bool order = orderByDir == "asc" ? false : true;

            //string where = GetPagerCondition(false);
            //if (search != null)
            //{
            //    if (!string.IsNullOrEmpty(search.Keywords))
            //    {
            //        where += string.Format(" and (Account like '%{0}%' or ModuleName like '%{0}%' or IPAddress like '%{0}%' or IPAddressName like '%{0}%' or Description like '%{0}%')", search.Keywords);
            //    };
            //    if (!string.IsNullOrEmpty(search.EnCode))
            //    {
            //        where += " and Type in('" + search.EnCode.Replace(",","','") + "')";
            //    }
            //}
            //PagerInfo pagerInfo = GetPagerInfo();
            //List<Log> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            //List<LogOutputDto> resultList = new List<LogOutputDto>();
            //foreach (Log item in list)
            //{
            //    LogOutputDto roleOutputDto = new LogOutputDto();
            //    roleOutputDto = item.MapTo<LogOutputDto>();
            //    if (!string.IsNullOrEmpty(roleOutputDto.OrganizeId))
            //    {
            //        roleOutputDto.OrganizeId = organizeService.Get(item.OrganizeId).FullName;
            //    }
            //    resultList.Add(roleOutputDto);
            //}
            //PageResult<LogOutputDto> pageResult = new PageResult<LogOutputDto>
            //{
            //    CurrentPage = pagerInfo.CurrenetPageIndex,
            //    Items = resultList,
            //    ItemsPerPage = pagerInfo.PageSize,
            //    TotalItems = pagerInfo.RecordCount
            //};
            result.ResData = await iService.FindWithPagerAsync(search);
            result.ErrCode = ErrCode.successCode;
            return result;
        }
    }
}