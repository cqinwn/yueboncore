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
using Yuebon.Commons.Cache;
using Newtonsoft.Json;
using Yuebon.Commons.Json;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.UI;
using Yuebon.AspNetCore.ViewModel;
using Yuebon.Commons.Encrypt;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class SystemTypeController : AreaApiController<SystemType, SystemTypeOutputDto, SystemTypeInputDto, ISystemTypeService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public SystemTypeController(ISystemTypeService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "SystemType/List";
            AuthorizeKey.InsertKey = "SystemType/Add";
            AuthorizeKey.UpdateKey = "SystemType/Edit";
            AuthorizeKey.UpdateEnableKey = "SystemType/Enable";
            AuthorizeKey.DeleteKey = "SystemType/Delete";
            AuthorizeKey.DeleteSoftKey = "SystemType/DeleteSoft";
            AuthorizeKey.ViewKey = "SystemType/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(SystemType info)
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
        protected override void OnBeforeUpdate(SystemType info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(SystemType info)
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
        public override async Task<IActionResult> UpdateAsync(SystemTypeInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            SystemType info = iService.Get(id);
            info.FullName = tinfo.FullName;
            info.EnCode = tinfo.EnCode;
            info.Url = tinfo.Url;
            info.AllowEdit = tinfo.AllowEdit;
            info.AllowDelete = tinfo.AllowDelete;
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
        public override async Task<IActionResult> FindWithPagerAsync([FromQuery]SearchModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition(false);

            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", search.Keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<SystemType> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<SystemTypeOutputDto> resultList = list.MapTo<SystemTypeOutputDto>();
           
            PageResult<SystemTypeOutputDto> pageResult = new PageResult<SystemTypeOutputDto>
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
        /// 获取所有子系统
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSubSystemList")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetSubSystemList()
        {
            CommonResult result = new CommonResult();
            try
            {
                IEnumerable<SystemType> list = await iService.GetAllAsync();
                result.ErrCode = ErrCode.successCode;
                result.ResData = list.MapTo<SystemTypeOutputDto>();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获子系统异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 系统切换时获取凭据
        /// 适用于不同子系统分别独立部署站点场景
        /// </summary>
        /// <param name="systype"></param>
        /// <returns></returns>
        [HttpGet("YuebonConnecSys")]
        [YuebonAuthorize("")]
        public async Task<IActionResult> YuebonConnecSys(string systype)
        {
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(systype))
                {
                    SystemType systemType = iService.GetByCode(systype);
                    string openmf = MD5Util.GetMD5_32(DEncrypt.Encrypt(CurrentUser.UserId + systemType.Id, GuidUtils.NewGuidFormatN())).ToLower();
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    yuebonCacheHelper.Add("openmf" + openmf, CurrentUser.UserId);
                    result.ErrCode = ErrCode.successCode;
                    result.ResData = systemType.Url + "?openmf=" + openmf;
                }
                else
                {
                    result.ErrCode = ErrCode.failCode;
                    result.ErrMsg = "切换子系统参数错误";
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("切换子系统异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }
    }
}