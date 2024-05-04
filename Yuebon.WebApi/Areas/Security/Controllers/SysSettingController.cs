﻿using System.Runtime.InteropServices;
using Yuebon.Commons;
using Yuebon.Commons.Encrypt;

namespace Yuebon.WebApi.Areas.Security;

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
    //private readonly IRoleService roleService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hostingEnvironment"></param>
    /// <param name="_userService"></param>
    /// <param name="_menuService"></param>
    public SysSettingController(IWebHostEnvironment hostingEnvironment, IUserService _userService, IMenuService _menuService)
    {
        _hostingEnvironment = hostingEnvironment;
        userService = _userService;
        menuService = _menuService;
    }

    /// <summary>
    /// 获取系统信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetSysInfo")]
    [YuebonAuthorize("GetSysInfo")]
    public async Task<IActionResult> GetSysInfo()
    {
        CommonResult result = new CommonResult();
        try
        {
            SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Add(CacheConst.KeySysSetting, sysSetting);
            DashboardOutModel dashboardOutModel = new DashboardOutModel();
            dashboardOutModel.CertificatedCompany = sysSetting.CompanyName;
            dashboardOutModel.WebUrl = sysSetting.WebUrl;
            dashboardOutModel.Title = sysSetting.SoftName;
            dashboardOutModel.MachineName = Environment.MachineName;
            dashboardOutModel.ProcessorCount= Environment.ProcessorCount;
            dashboardOutModel.SystemPageSize = Environment.SystemPageSize;
            dashboardOutModel.WorkingSet = Environment.WorkingSet;
            dashboardOutModel.TickCount = Environment.TickCount;
            dashboardOutModel.RunTimeLength = (Environment.TickCount/1000).ToBrowseTime();
            dashboardOutModel.FrameworkDescription = RuntimeInformation.FrameworkDescription;
            dashboardOutModel.OSName = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "Linux" : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "OSX" : "Windows";
            dashboardOutModel.OSDescription = RuntimeInformation.OSDescription + " " + RuntimeInformation.OSArchitecture;
            dashboardOutModel.OSArchitecture = RuntimeInformation.OSArchitecture.ToString();
            dashboardOutModel.ProcessArchitecture = RuntimeInformation.ProcessArchitecture.ToString();
            
            dashboardOutModel.Directory = AppContext.BaseDirectory;
            Version version = Environment.Version;
            dashboardOutModel.SystemVersion = version.Major+"."+version.Minor+"."+version.Build;
            dashboardOutModel.Version = AppVersionHelper.Version;
            dashboardOutModel.Manufacturer = AppVersionHelper.Manufacturer;
            dashboardOutModel.WebSite = AppVersionHelper.WebSite;
            dashboardOutModel.UpdateUrl = AppVersionHelper.UpdateUrl;
            dashboardOutModel.IPAdress = Request.HttpContext.Connection.LocalIpAddress.ToString();
            dashboardOutModel.Port = Request.HttpContext.Connection.LocalPort.ToString();
            dashboardOutModel.TotalUser = await userService.GetCountByWhereAsync("1=1");
            dashboardOutModel.TotalModule = await menuService.GetCountByWhereAsync("1=1");
            //dashboardOutModel.TotalRole = await roleService.GetCountByWhereAsync("1=1");
            //dashboardOutModel.TotalTask = await taskManagerService.GetCountByWhereAsync("1=1");
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
    /// 获取系统基本信息不完整信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetInfo")]
    [AllowAnonymous]
    public IActionResult GetInfo()
    {
        CommonResult result = new CommonResult();
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        SysSetting sysSetting = yuebonCacheHelper.Get(CacheConst.KeySysSetting).ToJson().ToObject<SysSetting>();
        SysSettingOutputDto sysSettingOutputDto = new SysSettingOutputDto();
        if (sysSetting == null)
        {
            sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
        } 
        sysSetting.Email = "";
        sysSetting.Emailsmtp = "";
        sysSetting.Emailpassword = "";
        sysSetting.Smspassword = "";
        sysSetting.SmsSignName = "";
        sysSetting.Smsusername = "";
       
        sysSettingOutputDto = sysSetting.MapTo<SysSettingOutputDto>();
        if (sysSettingOutputDto != null)
        {
            sysSettingOutputDto.CopyRight= UIConstants.CopyRight;
            result.ResData = sysSettingOutputDto;
            result.Success = true;
            result.ErrCode = ErrCode.successCode;
        }
        else
        {
            result.ErrMsg = ErrCode.err60001;
            result.ErrCode = "60001";
        }

        
        return ToJsonContent(result);
    }

    /// <summary>
    /// 获取系统基本信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllInfo")]
    [YuebonAuthorize("GetSysInfo")]
    public IActionResult GetAllInfo()
    {
        CommonResult result = new CommonResult();
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        SysSetting sysSetting = yuebonCacheHelper.Get(CacheConst.KeySysSetting).ToJson().ToObject<SysSetting>();
        SysSettingOutputDto sysSettingOutputDto = new SysSettingOutputDto();
        if (sysSetting == null)
        {
            sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
        }

        //对关键信息解密
        if (!string.IsNullOrEmpty(sysSetting.Email))
            sysSetting.Email = DEncrypt.Decrypt(sysSetting.Email);
        if (!string.IsNullOrEmpty(sysSetting.Emailsmtp))
            sysSetting.Emailsmtp = DEncrypt.Decrypt(sysSetting.Emailsmtp);
        if (!string.IsNullOrEmpty(sysSetting.Emailpassword))
            sysSetting.Emailpassword = DEncrypt.Decrypt(sysSetting.Emailpassword);
        if (!string.IsNullOrEmpty(sysSetting.Smspassword))
            sysSetting.Smspassword = DEncrypt.Decrypt(sysSetting.Smspassword);
        if (!string.IsNullOrEmpty(sysSetting.Smsusername))
            sysSetting.Smsusername = DEncrypt.Decrypt(sysSetting.Smsusername);
        sysSettingOutputDto = sysSetting.MapTo<SysSettingOutputDto>();
        if (sysSettingOutputDto != null)
        {
            sysSettingOutputDto.CopyRight = UIConstants.CopyRight;
            result.ResData = sysSettingOutputDto;
            result.Success = true;
            result.ErrCode = ErrCode.successCode;
        }
        else
        {
            result.ErrMsg = ErrCode.err60001;
            result.ErrCode = "60001";
        }
        return ToJsonContent(result);
    }

    /// <summary>
    /// 保存系统设置信息
    /// </summary>
    /// <returns></returns>
    [HttpPost("Save")]
    [YuebonAuthorize("Edit")]
    public IActionResult Save(SysSetting info)
    {
        CommonResult result = new CommonResult();
        info.LocalPath = _hostingEnvironment.WebRootPath;
        SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
        sysSetting = info;
        //对关键信息加密
        if(!string.IsNullOrEmpty(info.Email))
        sysSetting.Email = DEncrypt.Encrypt(info.Email);
        if (!string.IsNullOrEmpty(info.Emailsmtp))
            sysSetting.Emailsmtp = DEncrypt.Encrypt(info.Emailsmtp);
        if (!string.IsNullOrEmpty(info.Emailpassword))
            sysSetting.Emailpassword = DEncrypt.Encrypt(info.Emailpassword);
        if (!string.IsNullOrEmpty(info.Smspassword))
            sysSetting.Smspassword = DEncrypt.Encrypt(info.Smspassword);
        if (!string.IsNullOrEmpty(info.Smsusername))
            sysSetting.Smsusername = DEncrypt.Encrypt(info.Smsusername);
        string uploadPath = _hostingEnvironment.WebRootPath + "/" + sysSetting.Filepath;
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        if (yuebonCacheHelper.Exists(CacheConst.KeySysSetting))
        {
            yuebonCacheHelper.Replace(CacheConst.KeySysSetting, sysSetting);
        }
        else
        {
            //写入缓存
            yuebonCacheHelper.Add(CacheConst.KeySysSetting, sysSetting);
        }
        XmlConverter.Serialize<SysSetting>(sysSetting, "xmlconfig/sys.config");
        result.ErrCode = ErrCode.successCode;
        return ToJsonContent(result);
    }
}