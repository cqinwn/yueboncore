﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UAParser;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Net;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Tenants.IServices;
using Yuebon.Tenants.Models;
using Yuebon.WebApi.Areas.Security.Models;

namespace Yuebon.WebApi.Controllers
{
    /// <summary>
    /// 用户登录接口控制器
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : ApiController
    {
        private IUserService _userService;
        private IUserLogOnService _userLogOnService;
        private ISystemTypeService _systemTypeService;
        private IAPPService _appService;
        private IRoleService _roleService;
        private IRoleDataService _roleDataService;
        private ILogService _logService;
        private IFilterIPService _filterIPService;
        private IMenuService _menuService;
        private ITenantService _tenantService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="iService"></param>
        /// <param name="userLogOnService"></param>
        /// <param name="systemTypeService"></param>
        /// <param name="logService"></param>
        /// <param name="appService"></param>
        /// <param name="roleService"></param>
        /// <param name="filterIPService"></param>
        /// <param name="roleDataService"></param>
        /// <param name="menuService"></param>
        /// <param name="tenantService"></param>
        /// <param name="httpContextAccessor"></param>
        public LoginController(IUserService iService, 
            IUserLogOnService userLogOnService, 
            ISystemTypeService systemTypeService,
            ILogService logService, 
            IAPPService appService, 
            IRoleService roleService, 
            IFilterIPService filterIPService, 
            IRoleDataService roleDataService, 
            IMenuService menuService, 
            ITenantService tenantService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = iService;
            _userLogOnService = userLogOnService;
            _systemTypeService = systemTypeService;
            _logService = logService;
            _appService = appService;
            _roleService = roleService;
            _filterIPService = filterIPService;
            _roleDataService = roleDataService;
            _menuService = menuService;
            _tenantService=tenantService;
            _httpContextAccessor= httpContextAccessor;
        }
        /// <summary>
        /// 用户登录，必须要有验证码
        /// </summary>
        /// <returns>返回用户User对象</returns>
        [HttpPost("GetCheckUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCheckUser(LoginInput input)
        {
            CommonResult result = new CommonResult();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            string strIp = _httpContextAccessor.HttpContext.GetClientUserIp();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            var vCode = yuebonCacheHelper.Get("ValidateCode" + input.Vkey);
            string code = vCode != null ? vCode.ToString() : "11";
            if (input.Vcode.ToUpper() != code)
            {
                result.ErrMsg = "验证码错误";
                return ToJsonContent(result);
            }
            if (string.IsNullOrEmpty(input.Username))
            {
                result.ErrMsg = "用户名不能为空！";
            }
            else if (string.IsNullOrEmpty(input.Password))
            {
                result.ErrMsg = "密码不能为空！";
            }
            bool isTenant = Appsettings.app(new string[] { "AppSetting", "IsTenant" }).ObjToBool();
            UserInfo userInfo = new UserInfo();
            if (isTenant)
            {
                List<Tenant> tenants =null;
                if (!yuebonCacheHelper.Exists("cacheTenants"))
                {
                   IEnumerable<Tenant> templist =  _tenantService.GetAllByIsEnabledMark();
                   yuebonCacheHelper.Add("cacheTenants", templist);
                }
                tenants = JsonHelper.ToObject<List<Tenant>>(yuebonCacheHelper.Get("cacheTenants").ToJson());
                if (tenants != null)
                {
                    string strHost = Request.Host.ToString();
                    string tenantName = input.Host.Split(".")[0];
                    Tenant tenant = tenants.FindLast(o => o.TenantName == tenantName);//通过租户名称
                    if (tenant == null&&tenantName!="default")
                    {
                        tenant = tenants.FindLast(o => o.HostDomain == input.Host);//通过客户绑定的独立域名
                        if (tenant == null)
                        {
                            result.ErrMsg = "非法访问";
                            return ToJsonContent(result);
                        }
                    }
                    else
                    {
                        userInfo.TenantId = 9242772129579077;
                        userInfo.TenantName = "default";
                    }
                    if (tenant != null)
                    {
                        userInfo.TenantId= tenant.Id;
                        userInfo.TenantSchema = tenant.Schema;
                        userInfo.TenantDataSource=tenant.DataSource;
                        userInfo.TenantName = tenant.TenantName;
                    }
                }
            }
            else
            {
                userInfo.TenantId = 9242772129579077;
                userInfo.TenantName = "default";
            }
            Log logEntity = new Log();
            bool blIp = _filterIPService.ValidateIP(strIp);
            if (blIp)
            {
                result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
            }
            else
            {                
                if (string.IsNullOrEmpty(input.SystemCode))
                {
                    result.ErrMsg = ErrCode.err40006;
                }
                else
                {
                    List<AllowCacheApp> list = MemoryCacheHelper.Get<object>("cacheAppList").ToJson().ToList<AllowCacheApp>();
                    if (list == null)
                    {
                        IEnumerable<APP> appList = _appService.GetAllByIsNotDeleteAndEnabledMark();
                        MemoryCacheHelper.Set("cacheAppList", appList);
                    }

                    string strHost = Request.Headers["Origin"].ToString();
                    APP app = _appService.GetAPP(input.AppId);
                    if (app == null)
                    {
                        result.ErrCode = "40001";
                        result.ErrMsg = ErrCode.err40001;
                    }
                    else
                    {
                        if (!app.RequestUrl.Contains(strHost, StringComparison.Ordinal) && !strHost.Contains("localhost", StringComparison.Ordinal))
                        {
                            result.ErrCode = "40002";
                            result.ErrMsg = ErrCode.err40002 + "，你当前请求主机：" + strHost;
                        }
                        else
                        {
                            Appsettings.User = userInfo;
                            SystemType systemType = _systemTypeService.GetByCode(input.SystemCode);
                            if (systemType == null)
                            {
                                result.ErrMsg = ErrCode.err40006;
                            }
                            else
                            {
                                Tuple<User, string> userLogin = await this._userService.Validate(input.Username, input.Password);
                                if (userLogin != null)
                                {
                                    string ipAddressName = await IpAddressUtil.GetCityByIp(strIp);

                                    var client = Parser.GetDefault().Parse(_httpContextAccessor.HttpContext.Request.Headers["User-Agent"]);
                                    string requestPath = _httpContextAccessor.HttpContext.Request.Path.ToString();
                                    string queryString = _httpContextAccessor.HttpContext.Request.QueryString.ToString();
                                    string requestUrl = requestPath + queryString;
                                    if (userLogin.Item1 != null)
                                    {
                                        result.Success = true;
                                        User user = userLogin.Item1;
                                        userInfo.UserId = user.Id;
                                        userInfo.UserName = user.Account;
                                        userInfo.Role = user.RoleId;

                                        JwtOption jwtModel = Appsettings.GetService<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(userInfo, input.AppId);
                                        YuebonCurrentUser currentSession = new YuebonCurrentUser
                                        {
                                            UserId = user.Id,
                                            Name = user.RealName,
                                            AccessToken = tokenResult.AccessToken,
                                            TokenExpiresIn = tokenResult.ExpiresIn,
                                            AppKey = input.AppId,
                                            CreateTime = DateTime.Now,
                                            Role = _roleService.GetRoleEnCode(user.RoleId),
                                            ActiveSystemId = systemType.Id,
                                            CurrentLoginIP = strIp,
                                            IPAddressName = ipAddressName
                                        };
                                        if (isTenant)
                                        {
                                            currentSession.TenantId = userInfo.TenantId;
                                        }
                                        SysSetting sysSetting = yuebonCacheHelper.Get("SysSetting").ToJson().ToObject<SysSetting>();
                                        if (sysSetting != null)
                                        {
                                            if (sysSetting.Webstatus == "1" && !currentSession.Role.Contains("administrators"))
                                            {
                                                result.ErrCode = "40900";
                                                result.ErrMsg = sysSetting.Webclosereason;
                                                return ToJsonContent(result);
                                            }
                                        }
                                        TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                                        yuebonCacheHelper.Add("login_user_" + user.Id.ToString(), currentSession, expiresSliding, true);
                                        yuebonCacheHelper.Add("login_userInfo_" + user.Id.ToString(), userInfo, expiresSliding, true);
                                       
                                        CurrentUser = currentSession;
                                        result.ResData = currentSession;
                                        result.ErrCode = ErrCode.successCode;
                                        result.Success = true;

                                        logEntity.Account = user.Account;
                                        logEntity.NickName = user.NickName;
                                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                                        logEntity.IPAddress = strIp;
                                        logEntity.IPAddressName = ipAddressName;
                                        logEntity.RequestUrl = requestUrl;
                                        logEntity.Browser = client.UA.Family + client.UA.Major;
                                        logEntity.OS = client.OS.Family + client.OS.Major;
                                        logEntity.Result = true;
                                        logEntity.ModuleName = "登录";
                                        logEntity.Description = "登录成功";
                                        logEntity.Type = "Login";
                                        _logService.Insert(logEntity);
                                    }
                                    else
                                    {
                                        result.ErrCode = ErrCode.failCode;
                                        result.ErrMsg = userLogin.Item2;
                                        logEntity.Account = input.Username;
                                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                                        logEntity.IPAddress = strIp;
                                        logEntity.IPAddressName = ipAddressName;
                                        logEntity.RequestUrl = requestUrl;
                                        logEntity.Browser = client.UA.Family + client.UA.Major;
                                        logEntity.OS = client.OS.Family + client.OS.Major;
                                        logEntity.Result = false;
                                        logEntity.ModuleName = "登录";
                                        logEntity.Type = "Login";
                                        logEntity.Description = "登录失败，" + userLogin.Item2;
                                        _logService.Insert(logEntity);
                                    }
                                }
                            }

                        }
                    }
                }
            }
            yuebonCacheHelper.Remove("LoginValidateCode");
            return ToJsonContent(result, true);
        }

        /// <summary>
        /// 获取登录用户权限信息
        /// </summary>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetUserInfo")]
        [YuebonAuthorize("")]
        public IActionResult GetUserInfo()
        {
            CommonResult result = new CommonResult();
            if (CurrentUser == null)
            {
                return Logout();
            }
            User user = _userService.Get(CurrentUser.UserId);
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            SystemType systemType = _systemTypeService.Get(CurrentUser.ActiveSystemId);
            YuebonCurrentUser currentSession = new YuebonCurrentUser
            {
                UserId = user.Id,
                Account = user.Account,
                Name = user.RealName,
                NickName = user.NickName,
                AccessToken = CurrentUser.AccessToken,
                AppKey = CurrentUser.AppKey,
                CreateTime = DateTime.Now,
                HeadIcon = user.HeadIcon,
                Gender = user.Gender,
                ReferralUserId = user.ReferralUserId,
                MemberGradeId = user.MemberGradeId,
                Role = _roleService.GetRoleEnCode(user.RoleId),
                MobilePhone = user.MobilePhone,
                OrganizeId = user.OrganizeId,
                DeptId = user.DepartmentId,
                CurrentLoginIP = CurrentUser.CurrentLoginIP,
                IPAddressName = CurrentUser.IPAddressName,
                TenantId = null
            };
			CurrentUser = currentSession;
            CurrentUser.HeadIcon = user.HeadIcon;

            CurrentUser.ActiveSystemId = systemType.Id;
            CurrentUser.ActiveSystem = systemType.FullName;
            CurrentUser.ActiveSystemUrl = systemType.Url;

            List<MenuOutputDto> listFunction = new List<MenuOutputDto>();
            MenuApp menuApp = new MenuApp();
            if (Permission.IsAdmin(CurrentUser))
            {
                CurrentUser.SubSystemList = _systemTypeService.GetAllByIsNotDeleteAndEnabledMark().MapTo<SystemTypeOutputDto>();
                //取得用户可使用的授权功能信息，并存储在缓存中
                listFunction = menuApp.GetFunctionsBySystem(CurrentUser.ActiveSystemId);
                CurrentUser.MenusRouter = menuApp.GetVueRouter("", systemType.EnCode);
            }
            else
            {
                CurrentUser.SubSystemList = _systemTypeService.GetSubSystemList(user.RoleId);
                //取得用户可使用的授权功能信息，并存储在缓存中
                listFunction = menuApp.GetFunctionsByUser(user.Id, CurrentUser.ActiveSystemId);
                CurrentUser.MenusRouter = menuApp.GetVueRouter(user.RoleId, systemType.EnCode);
            }
            UserLogOn userLogOn = _userLogOnService.GetByUserId(CurrentUser.UserId);
            CurrentUser.UserTheme = userLogOn.Theme == null ? "default" : userLogOn.Theme;
            TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
            yuebonCacheHelper.Add("User_Function_" + user.Id, listFunction, expiresSliding, true);
            List<string> listModules = new List<string>();
            foreach (MenuOutputDto item in listFunction)
            {
                listModules.Add(item.EnCode);
            }
            CurrentUser.Modules = listModules;
            yuebonCacheHelper.Add("login_user_" + user.Id, CurrentUser, expiresSliding, true);
            //该用户的数据权限
            List<String> roleDateList = _roleDataService.GetListDeptByRole(user.RoleId);
            yuebonCacheHelper.Add("User_RoleData_" + user.Id, roleDateList, expiresSliding, true);
            result.ResData = CurrentUser;
            result.ErrCode = ErrCode.successCode;
            result.Success = true;
            return ToJsonContent(result, true);
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProfile")]
        public IActionResult GetProfile()
        {
            CommonResult result = new CommonResult();
            if (CurrentUser == null)
            {
                return Logout();
            }
            User user = _userService.Get(CurrentUser.UserId);
            result.ResData = user.MapTo<UserOutputDto>();
            result.ErrCode = ErrCode.successCode;
            result.ErrMsg = ErrCode.err0;
            return ToJsonContent(result, true);
        }
        /// <summary>
        /// 用户登录，无验证码，主要用于app登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="appId">AppId</param>
        /// <param name="systemCode">系统编码</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("UserLogin")]
        [NoPermissionRequired]
        public async Task<IActionResult> UserLogin(string username, string password,  string appId, string systemCode)
        {
            CommonResult result = new CommonResult();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            bool isTenant = Appsettings.app(new string[] { "AppSetting", "IsTenant" }).ObjToBool();
            UserInfo userInfo = null;
            if (isTenant)
            {
                List<Tenant> tenants = null;
                if (!yuebonCacheHelper.Exists("cacheTenants"))
                {
                    IEnumerable<Tenant> templist = _tenantService.GetAllByIsEnabledMark();
                    yuebonCacheHelper.Add("cacheTenants", templist);
                }
                tenants = JsonHelper.ToObject<List<Tenant>>(yuebonCacheHelper.Get("cacheTenants").ToJson());
                if (tenants != null)
                {
                    string strHost = Request.Host.ToString();
                    Tenant tenant = tenants.FindLast(o => o.HostDomain == strHost);
                    if (tenant == null)
                    {
                        result.ErrMsg = "非法访问";
                        return ToJsonContent(result);
                    }
                    else
                    {
                        userInfo.TenantId = tenant.Id;
                        userInfo.TenantSchema = tenant.Schema;
                        userInfo.TenantDataSource = tenant.DataSource;
                    }
                }
            }
            Log logEntity = new Log();
            bool blIp = _filterIPService.ValidateIP(strIp);
            if (blIp)
            {
                result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
            }
            else
            {
                if (string.IsNullOrEmpty(username))
                {
                    result.ErrMsg = "用户名不能为空！";
                }
                else if (string.IsNullOrEmpty(password))
                {
                    result.ErrMsg = "密码不能为空！";
                }
                if (string.IsNullOrEmpty(systemCode))
                {

                    result.ErrMsg = ErrCode.err40006;
                }
                else
                {
                    string strHost = Request.Host.ToString();
                    APP app = _appService.GetAPP(appId);
                    if (app == null)
                    {
                        result.ErrCode = "40001";
                        result.ErrMsg = ErrCode.err40001;
                    }
                    else
                    {
                        if (!app.RequestUrl.Contains(strHost, StringComparison.Ordinal) && !strHost.Contains("localhost", StringComparison.Ordinal))
                        {
                            result.ErrCode = "40002";
                            result.ErrMsg = ErrCode.err40002 + "，你当前请求主机：" + strHost;
                        }
                        else
                        {
                            SystemType systemType = _systemTypeService.GetByCode(systemCode);
                            if (systemType == null)
                            {
                                result.ErrMsg = ErrCode.err40006;
                            }
                            else
                            {
                                Tuple<User,string> userLogin = await this._userService.Validate(username, password);
                                if (userLogin != null)
                                {

                                    string ipAddressName =await IpAddressUtil.GetCityByIp(strIp);
                                    if (userLogin.Item1 != null)
                                    {
                                        result.Success = true;

                                        User user = userLogin.Item1;

                                        userInfo.UserId = user.Id;
                                        userInfo.UserName = user.Account;
                                        userInfo.Role = user.RoleId;
                                        JwtOption jwtModel = Appsettings.GetService<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(userInfo, appId);
                                        YuebonCurrentUser currentSession = new YuebonCurrentUser
                                        {
                                            UserId = user.Id,
                                            Name = user.RealName,
                                            AccessToken = tokenResult.AccessToken,
                                            AppKey = appId,
                                            CreateTime = DateTime.Now,
                                            Role = _roleService.GetRoleEnCode(user.RoleId),
                                            ActiveSystemId = systemType.Id,
                                            CurrentLoginIP = strIp,
                                            IPAddressName = ipAddressName

                                        };
                                        TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                                        yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                                        CurrentUser = currentSession;
                                        result.ResData = currentSession;
                                        result.ErrCode = ErrCode.successCode;
                                        result.Success = true;

                                        logEntity.Account = user.Account;
                                        logEntity.NickName = user.NickName;
                                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                                        logEntity.IPAddress = CurrentUser.CurrentLoginIP;
                                        logEntity.IPAddressName = CurrentUser.IPAddressName;
                                        logEntity.Result = true;
                                        logEntity.ModuleName = "登录";
                                        logEntity.Description = "登录成功";
                                        logEntity.Type = "Login";
                                        _logService.Insert(logEntity);
                                    }
                                    else
                                    {
                                        result.ErrCode = ErrCode.failCode;
                                        result.ErrMsg = userLogin.Item2;
                                        logEntity.Account = username;
                                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                                        logEntity.IPAddress = strIp;
                                        logEntity.IPAddressName = ipAddressName;
                                        logEntity.Result = false;
                                        logEntity.ModuleName = "登录";
                                        logEntity.Type = "Login";
                                        logEntity.Description = "登录失败，" + userLogin.Item2;
                                        _logService.Insert(logEntity);
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return ToJsonContent(result, true);
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Logout")]
        [YuebonAuthorize("")]
        public IActionResult Logout()
        {
            CommonResult result = new CommonResult();
            if (CurrentUser != null)
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                yuebonCacheHelper.Remove("login_user_" + CurrentUser.UserId);
                yuebonCacheHelper.Remove("User_Function_" + CurrentUser.UserId);
                UserLogOn userLogOn = _userLogOnService.GetWhere("UserId='" + CurrentUser.UserId + "'");
                userLogOn.UserOnLine = false;
                _userLogOnService.Update(userLogOn);
            }
            CurrentUser = null;
            result.Success = true;
            result.ErrCode = ErrCode.successCode;
            result.ErrMsg = "成功退出";
            return ToJsonContent(result);
        }

        /// <summary>
        /// 子系统切换登录
        /// </summary>
        /// <param name="openmf">凭据</param>
        /// <param name="appId">应用Id</param>
        /// <param name="systemCode">子系统编码</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("SysConnect")]
        [AllowAnonymous]
        [NoPermissionRequired]
        public async Task<IActionResult> SysConnect(string openmf, string appId, string systemCode)
        {
            CommonResult result = new CommonResult();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            if (string.IsNullOrEmpty(openmf))
            {
                result.ErrMsg = "切换参数错误！";
            }
            bool isTenant = Appsettings.app(new string[] { "AppSetting", "IsTenant" }).ObjToBool();
            UserInfo userInfo = null;
            if (isTenant)
            {
                List<Tenant> tenants = null;
                if (!yuebonCacheHelper.Exists("cacheTenants"))
                {
                    IEnumerable<Tenant> templist = _tenantService.GetAllByIsEnabledMark();
                    yuebonCacheHelper.Add("cacheTenants", templist);
                }
                tenants = JsonHelper.ToObject<List<Tenant>>(yuebonCacheHelper.Get("cacheTenants").ToJson());
                if (tenants != null)
                {
                    string strHost = Request.Host.ToString();
                    Tenant tenant = tenants.FindLast(o => o.HostDomain == strHost);
                    if (tenant == null)
                    {
                        result.ErrMsg = "非法访问";
                        return ToJsonContent(result);
                    }
                    else
                    {
                        userInfo.TenantId = tenant.Id;
                        userInfo.TenantSchema = tenant.Schema;
                        userInfo.TenantDataSource = tenant.DataSource;
                    }
                }
            }
            bool blIp = _filterIPService.ValidateIP(strIp);
            if (blIp)
            {
                result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
            }
            else
            {
                string ipAddressName =await IpAddressUtil.GetCityByIp(strIp);
                if (string.IsNullOrEmpty(systemCode))
                {
                    result.ErrMsg = ErrCode.err40006;
                }
                else
                {
                    string strHost = Request.Host.ToString();
                    APP app = _appService.GetAPP(appId);
                    if (app == null)
                    {
                        result.ErrCode = "40001";
                        result.ErrMsg = ErrCode.err40001;
                    }
                    else
                    {
                        if (!app.RequestUrl.Contains(strHost, StringComparison.Ordinal) && !strHost.Contains("localhost", StringComparison.Ordinal))
                        {
                            result.ErrCode = "40002";
                            result.ErrMsg = ErrCode.err40002 + "，你当前请求主机：" + strHost;
                        }
                        else
                        {
                            SystemType systemType = _systemTypeService.GetByCode(systemCode);
                            if (systemType == null)
                            {
                                result.ErrMsg = ErrCode.err40006;
                            }
                            else
                            {
                                object cacheOpenmf = yuebonCacheHelper.Get("openmf" + openmf);
                                yuebonCacheHelper.Remove("openmf" + openmf);
                                if (cacheOpenmf == null)
                                {
                                    result.ErrCode = "40007";
                                    result.ErrMsg = ErrCode.err40007;
                                }
                                else
                                {
                                    User user = _userService.Get(cacheOpenmf.ToInt());
                                    if (user != null)
                                    {

                                        userInfo.UserId = user.Id;
                                        userInfo.UserName = user.Account;
                                        userInfo.Role = user.RoleId;
                                        result.Success = true;
                                        JwtOption jwtModel = Appsettings.GetService<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(userInfo, appId);
                                        YuebonCurrentUser currentSession = new YuebonCurrentUser
                                        {
                                            UserId = user.Id,
                                            Name = user.RealName,
                                            AccessToken = tokenResult.AccessToken,
                                            AppKey = appId,
                                            CreateTime = DateTime.Now,
                                            Role = _roleService.GetRoleEnCode(user.RoleId),
                                            ActiveSystemId = systemType.Id,
                                            CurrentLoginIP = strIp,
                                            IPAddressName = ipAddressName,
                                            ActiveSystemUrl= systemType.Url

                                        };
                                        TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                                        yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                                        CurrentUser = currentSession;
                                        result.ResData = currentSession;
                                        result.ErrCode = ErrCode.successCode;
                                        result.Success = true;
                                    }
                                    else
                                    {
                                        result.ErrCode = ErrCode.failCode;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 弃用接口演示
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestLogin")]
        [Obsolete]
        public IActionResult TestLogin()
        {
            CommonResult result = new CommonResult();
            result.Success = true;
            result.ErrCode = ErrCode.successCode;
            result.ResData = "弃用接口演示";
            result.ErrMsg = "成功退出";
            return ToJsonContent(result);
        }
    }
}