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

namespace Yuebon.SecurityApi.Areas.Security.Controllers
{
    /// <summary>
    /// 租户接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class TentantController : AreaApiController<Tentant, TentantOutputDto,TentantInputDto,ITentantService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public TentantController(ITentantService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "Tentant/List";
            AuthorizeKey.InsertKey = "Tentant/Add";
            AuthorizeKey.UpdateKey = "Tentant/Edit";
            AuthorizeKey.UpdateEnableKey = "Tentant/Enable";
            AuthorizeKey.DeleteKey = "Tentant/Delete";
            AuthorizeKey.DeleteSoftKey = "Tentant/DeleteSoft";
            AuthorizeKey.ViewKey = "Tentant/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Tentant info)
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
        protected override void OnBeforeUpdate(Tentant info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Tentant info)
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
        public override async Task<IActionResult> UpdateAsync(TentantInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();

            Tentant info = iService.Get(id);
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
    }
}