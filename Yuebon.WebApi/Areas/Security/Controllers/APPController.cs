using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 应用管理接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class APPController : AreaApiController<APP, AppOutputDto, APPInputDto, IAPPService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public APPController(IAPPService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(APP info)
        {
            info.Id = GuidUtils.CreateNo();
            info.AppSecret = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            if (info.IsOpenAEKey)
            {
                info.EncodingAESKey = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            }
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
        protected override void OnBeforeUpdate(APP info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(APP info)
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
        public override async Task<IActionResult> UpdateAsync(APPInputDto tinfo)
        {
            CommonResult result = new CommonResult();

            APP info = iService.Get(tinfo.Id);
            info.AppId = tinfo.AppId;
            info.RequestUrl = tinfo.RequestUrl;
            info.Token = tinfo.Token;
            info.EnabledMark = tinfo.EnabledMark;
            info.Description = tinfo.Description;

            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info, tinfo.Id).ConfigureAwait(true);
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
        /// 重置AppSecret
        /// </summary>
        /// <returns></returns>
        [HttpGet("ResetAppSecret")]
        [YuebonAuthorize("ResetAppSecret")]
        public async Task<IActionResult> ResetAppSecret(string id)
        {
            CommonResult result = new CommonResult();
            APP aPP = iService.Get(id);
            aPP.AppSecret = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            bool bl = await iService.UpdateAsync(aPP, id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = aPP.AppSecret;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 重置消息加密密钥EncodingAESKey
        /// </summary>
        /// <returns></returns>
        [HttpGet("ResetEncodingAESKey")]
        [YuebonAuthorize("ResetEncodingAESKey")]
        public async Task<IActionResult> ResetEncodingAESKey(string id)
        {
            CommonResult result = new CommonResult();
            APP aPP = iService.Get(id);
            aPP.EncodingAESKey = MD5Util.GetMD5_32(GuidUtils.NewGuidFormatN()).ToUpper();
            bool bl = await iService.UpdateAsync(aPP, id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = aPP.EncodingAESKey;
                result.Success = true;
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