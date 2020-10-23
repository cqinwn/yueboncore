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
using Senparc.Weixin.MP.AdvancedAPIs;
using Yuebon.Commons.Extend;
using Yuebon.AspNetCore.UI;

namespace Yuebon.SecurityApi.Areas.Security.Controllers
{
    /// <summary>
    /// 租户接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class TenantController : AreaApiController<Tenant, TenantOutputDto,TenantInputDto,ITenantService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public TenantController(ITenantService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "Tenant/List";
            AuthorizeKey.InsertKey = "Tenant/Add";
            AuthorizeKey.UpdateKey = "Tenant/Edit";
            AuthorizeKey.UpdateEnableKey = "Tenant/Enable";
            AuthorizeKey.DeleteKey = "Tenant/Delete";
            AuthorizeKey.DeleteSoftKey = "Tenant/DeleteSoft";
            AuthorizeKey.ViewKey = "Tenant/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Tenant info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DeptId;
            info.DeleteMark = false;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Tenant info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Tenant info)
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
        public override async Task<IActionResult> UpdateAsync(TenantInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();
            if (!tinfo.TenantName.ToLower().IsAlphanumeric())
            {
                result.ErrMsg = "名称只能是字母和数字";
                result.ErrCode = "43002";
                return ToJsonContent(result);
            }
            Tenant info = iService.Get(id);
            info.TenantName = tinfo.TenantName;
            info.CompanyName = tinfo.CompanyName;
            info.HostDomain = tinfo.HostDomain;
            info.DataSource = tinfo.DataSource;
            info.LinkMan = tinfo.LinkMan;
            info.Telphone = tinfo.Telphone;
            info.EnabledMark = tinfo.EnabledMark;
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

        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public override async Task<CommonResult<PageResult<TenantOutputDto>>> FindWithPagerAsync([FromQuery] SearchModel search)
        {
            CommonResult<PageResult<TenantOutputDto>> result = new CommonResult<PageResult<TenantOutputDto>>();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Keywords))
                {
                    where += " and (TenantName like '%" + search.Keywords + "%' or CompanyName like '%" + search.Keywords + "%')";
                };
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<Tenant> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<TenantOutputDto> resultList = list.MapTo<TenantOutputDto>();
            PageResult<TenantOutputDto> pageResult = new PageResult<TenantOutputDto>
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