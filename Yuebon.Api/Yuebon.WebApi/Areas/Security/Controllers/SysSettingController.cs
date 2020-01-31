using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 系统基本信息
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class SysSettingController : ApiController
    {
        /// <summary>
        /// 获取系统基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        public  IActionResult GetInfo()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (result.ErrCode == ErrCode.successCode)
            {
                SysSetting sysSetting = JsonConvert.DeserializeObject<SysSetting>(yuebonCacheHelper.Get("SysSetting").ToJson());
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