using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.IServices;
using Yuebon.Tenants.Models;

namespace Yuebon.SecurityApi.Areas.Security.Controllers
{
    /// <summary>
    /// 租户接口
    /// </summary>
    [ApiController]
    [Route("api/Tenants/[controller]")]
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
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(TenantInputDto tinfo)
        {
            CommonResult result = new CommonResult();
            if (!tinfo.TenantName.ToLower().IsAlphanumeric())
            {
                result.ErrMsg = "名称只能是字母和数字";
                result.ErrCode = "43002";
                return ToJsonContent(result);
            }
            Tenant info = iService.Get(tinfo.Id);
            info.TenantName = tinfo.TenantName;
            info.CompanyName = tinfo.CompanyName;
            info.HostDomain = tinfo.HostDomain;
            info.DataSource = tinfo.DataSource;
            info.LinkMan = tinfo.LinkMan;
            info.Telphone = tinfo.Telphone;
            info.EnabledMark = tinfo.EnabledMark;
            info.Description = tinfo.Description;
            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info, tinfo.Id).ConfigureAwait(false);
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