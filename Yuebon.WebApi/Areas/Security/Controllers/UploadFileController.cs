using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.UI;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 文件管理
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class UploadFileController : AreaApiController<UploadFile, UploadFileOutputDto, UploadFileInputDto, IUploadFileService, string>
    {
        public UploadFileController(IUploadFileService _iService) : base(_iService)
        {
            iService = _iService;
        }


        /// <summary>
        /// 异步批量物理删除
        /// </summary>
        /// <param name="ids">主键Id</param>
        [HttpDelete("DeleteBatchAsync")]
        [YuebonAuthorize("Delete")]
        public override async Task<IActionResult> DeleteBatchAsync(string ids)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            string newIds = ids.ToString();
            where = "id in ('" + newIds.Trim(',').Replace(",", "','") + "')";

            if (!string.IsNullOrEmpty(where))
            {
                string[] jobsId = ids.Split(",");
                foreach (var item in jobsId)
                {
                    if (string.IsNullOrEmpty(item)) continue;
                    UploadFile uploadFile = new UploadFileApp().Get(item.ToString());
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    SysSetting sysSetting = JsonSerializer.Deserialize<SysSetting>(yuebonCacheHelper.Get("SysSetting").ToJson());
                    if (uploadFile != null)
                    {
                        if (System.IO.File.Exists(sysSetting.LocalPath + "/" + uploadFile.FilePath))
                            System.IO.File.Delete(sysSetting.LocalPath + "/" + uploadFile.FilePath);
                        if (!string.IsNullOrEmpty(uploadFile.Thumbnail))
                        {
                            if (System.IO.File.Exists(sysSetting.LocalPath + "/" + uploadFile.Thumbnail))
                                System.IO.File.Delete(sysSetting.LocalPath + "/" + uploadFile.Thumbnail);
                        }
                    }
                }
                bool bl = await iService.DeleteBatchWhereAsync(where).ConfigureAwait(false);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }
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
                where += string.Format(" and  FileName like '%{0}%' ", search.Keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<UploadFile> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<UploadFileOutputDto> resultList = list.MapTo<UploadFileOutputDto>();

            PageResult<UploadFileOutputDto> pageResult = new PageResult<UploadFileOutputDto>
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
    }
}