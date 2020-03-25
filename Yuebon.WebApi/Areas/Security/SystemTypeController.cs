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

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class SystemTypeController : AreaApiController<SystemType, SystemTypeOutputDto, ISystemTypeService,string>
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
        /// 获取系统基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        [NoPermissionRequired]
        public IActionResult GetInfo()
        {
            CommonResult result = new CommonResult();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                SysSetting sysSetting = JsonConvert.DeserializeObject<SysSetting>(yuebonCacheHelper.Get("SysSetting").ToJson());
                if (sysSetting != null)
                {
                    result.ResData = sysSetting;
                    result.Success = true;
                }
                else
                {
                    sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
                    if (sysSetting != null)
                    {
                        result.ResData = sysSetting;
                        result.Success = true;
                    }
                    else
                    {
                        result.ErrMsg = ErrCode.err60001;
                        result.ErrCode = "60001";
                    }
                }
            return ToJsonContent(result);
        }
    }
}