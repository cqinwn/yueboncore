﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApi.Areas.Security.Models;

namespace Yuebon.WebApi.Areas.Security
{
    /// <summary>
    /// 系统基本信息
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class SysSettingController : ApiController
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUserService userService;
        private readonly IMenuService menuService;
        private readonly IRoleService roleService;
        private readonly ILogService logService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="_userService"></param>
        /// <param name="_menuService"></param>
        /// <param name="_roleService"></param>
        /// <param name="_logService"></param>
        public SysSettingController(IWebHostEnvironment hostingEnvironment, IUserService _userService, IMenuService _menuService, IRoleService _roleService, ILogService _logService)
        {
            _hostingEnvironment = hostingEnvironment;
            userService = _userService;
            menuService = _menuService;
            roleService = _roleService;
            logService = _logService;
        }

        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSysInfo")]
        [YuebonAuthorize("")]
        public async Task<IActionResult> GetSysInfo()
        {
            CommonResult result = new CommonResult();
            try
            {
                SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
                DashboardOutModel dashboardOutModel = new DashboardOutModel();
                dashboardOutModel.CertificatedCompany = sysSetting.CompanyName;
                dashboardOutModel.WebUrl = sysSetting.WebUrl;
                dashboardOutModel.Title = sysSetting.SoftName;
                dashboardOutModel.MachineName = Environment.MachineName;
                dashboardOutModel.OSName = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Linux" : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "OSX" : "Windows";
                dashboardOutModel.OSDescription = RuntimeInformation.OSDescription + " " + RuntimeInformation.OSArchitecture;
                dashboardOutModel.Directory = AppContext.BaseDirectory;
                dashboardOutModel.SystemVersion = Environment.Version;
                dashboardOutModel.Version = AppVersionHelper.Version;
                dashboardOutModel.Manufacturer = AppVersionHelper.Manufacturer;
                dashboardOutModel.WebSite = AppVersionHelper.WebSite;
                dashboardOutModel.UpdateUrl = AppVersionHelper.UpdateUrl;
                dashboardOutModel.IPAdress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                dashboardOutModel.Port = Request.HttpContext.Connection.LocalPort.ToString();
                dashboardOutModel.TotalUser = await userService.GetCountByWhereAsync("1=1");
                dashboardOutModel.TotalModule = await menuService.GetCountByWhereAsync("1=1");
                dashboardOutModel.TotalRole = await roleService.GetCountByWhereAsync("1=1");
                dashboardOutModel.TotalLog = await logService.GetCountByWhereAsync("1=1");
                result.ResData = dashboardOutModel;
                result.ErrCode = ErrCode.successCode;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取系统信息异常", ex);
                result.ErrMsg = ErrCode.err60001;
                result.ErrCode = "60001";
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 获取系统基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInfo")]
        [YuebonAuthorize("")]
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
                result.ErrCode = ErrCode.successCode;
            }
            else
            {
                sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
                if (sysSetting != null)
                {
                    result.ResData = sysSetting;
                    result.Success = true;
                    result.ErrCode = ErrCode.successCode;
                }
                else
                {
                    result.ErrMsg = ErrCode.err60001;
                    result.ErrCode = "60001";
                }
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 保存系统设置信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("Save")]
        [YuebonAuthorize("Save")]
        [NoPermissionRequired]
        public IActionResult Save(SysSetting info)
        {
            CommonResult result = new CommonResult();
            info.LocalPath = _hostingEnvironment.WebRootPath;
            SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
            sysSetting = info;
            string uploadPath = _hostingEnvironment.WebRootPath + "/" + sysSetting.Filepath;
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("SysSetting"))
            {
                yuebonCacheHelper.Replace("SysSetting", sysSetting);
            }
            else
            {
                //写入缓存
                yuebonCacheHelper.Add("SysSetting", sysSetting);
            }
            XmlConverter.Serialize<SysSetting>(sysSetting, "xmlconfig/sys.config");
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
    }
}