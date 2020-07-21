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
using Yuebon.Authorizer.Dtos;
using Yuebon.Authorizer.Models;
using Yuebon.Authorizer.IServices;
using Yuebon.Commons.Encrypt;

namespace Yuebon.WebApi.Areas.Authorizer.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Authorizer/[controller]")]
    public class RegistryCodeController : AreaApiController<RegistryCode, RegistryCodeOutputDto, RegistryCodeInputDto, IRegistryCodeService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public RegistryCodeController(IRegistryCodeService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "RegistryCode/List";
            AuthorizeKey.InsertKey = "RegistryCode/Add";
            AuthorizeKey.UpdateKey = "RegistryCode/Edit";
            AuthorizeKey.UpdateEnableKey = "RegistryCode/Enable";
            AuthorizeKey.DeleteKey = "RegistryCode/Delete";
            AuthorizeKey.DeleteSoftKey = "RegistryCode/DeleteSoft";
            AuthorizeKey.ViewKey = "RegistryCode/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(RegistryCode info)
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
        protected override void OnBeforeUpdate(RegistryCode info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(RegistryCode info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
        /// <summary>
        /// 根据机器特征码获取注册序列号
        /// </summary>
        /// <param name="machineCode">机器特征码</param>
        public IActionResult GetRegCode(string machineCode)
        {
            CommonResult result = new CommonResult();
            try
            {
                RSASecurityHelper.RSAEncrypSignature(machineCode,);
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
                Log4NetHelper.Error("获取注册序列号异常", ex);
            }
            return ToJsonContent(result);
        }
    }
}