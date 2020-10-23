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

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleController : AreaApiController<Role, RoleOutputDto, RoleInputDto, IRoleService, string>
    {
        private IOrganizeService organizeService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param
        /// <param name="_organizeService"></param>
        public RoleController(IRoleService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;
            AuthorizeKey.ListKey = "Role/List";
            AuthorizeKey.InsertKey = "Role/Add";
            AuthorizeKey.UpdateKey = "Role/Edit";
            AuthorizeKey.UpdateEnableKey = "Role/Enable";
            AuthorizeKey.DeleteKey = "Role/Delete";
            AuthorizeKey.DeleteSoftKey = "Role/DeleteSoft";
            AuthorizeKey.ViewKey = "Role/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Role info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            info.Category = 1;
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
        protected override void OnBeforeUpdate(Role info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Role info)
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
        public override async Task<IActionResult> UpdateAsync(RoleInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            Role info = iService.Get(id);
            info.OrganizeId = tinfo.OrganizeId;
            info.FullName = tinfo.FullName;
            info.EnCode = tinfo.EnCode;
            info.EnabledMark = tinfo.EnabledMark;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;
            info.Type = tinfo.Type;

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
        public override async Task<CommonResult<PageResult<RoleOutputDto>>> FindWithPagerAsync([FromQuery]SearchModel search)
        {
            CommonResult<PageResult<RoleOutputDto>> result = new CommonResult<PageResult<RoleOutputDto>>();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            
            string where = GetPagerCondition(false);
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Keywords))
                {
                    where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", search.Keywords);
                };
            }
            where += " and Category=1";
            PagerInfo pagerInfo = GetPagerInfo();
            List<Role> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<RoleOutputDto> resultList = new List<RoleOutputDto>();
            foreach (Role item in list)
            {
                RoleOutputDto roleOutputDto = new RoleOutputDto();
                roleOutputDto = item.MapTo<RoleOutputDto>();
                roleOutputDto.OrganizeName = organizeService.Get(item.OrganizeId).FullName;
                resultList.Add(roleOutputDto);
            }
            PageResult<RoleOutputDto> pageResult = new PageResult<RoleOutputDto>
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