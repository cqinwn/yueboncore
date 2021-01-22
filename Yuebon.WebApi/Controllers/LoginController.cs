using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Net;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Controllers
{
    /// <summary>
    /// 用户登录接口控制器
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
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
        public LoginController(IUserService iService, IUserLogOnService userLogOnService, ISystemTypeService systemTypeService,ILogService logService, IAPPService appService, IRoleService roleService, IFilterIPService filterIPService, IRoleDataService roleDataService, IMenuService menuService)
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
        }
        /// <summary>
        /// 用户登录，必须要有验证码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="vcode">验证码</param>
        /// <param name="vkey">验证码key</param>
        /// <param name="appId">AppId</param>
        /// <param name="systemCode">系统编码</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetCheckUser")]
        [NoPermissionRequired]
        [AllowAnonymous]
        public async Task<IActionResult> GetCheckUser(string username, string password, string vcode,string vkey, string appId,string systemCode)
        {

            CommonResult result = new CommonResult();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            var vCode = yuebonCacheHelper.Get("ValidateCode"+ vkey);
            string code = vCode != null ? vCode.ToString() : "11";
            if (vcode.ToUpper() != code)
            {
                result.ErrMsg = "验证码错误";
                return ToJsonContent(result);
            }
            Log logEntity = new Log();
            bool blIp=_filterIPService.ValidateIP(strIp);
            if (blIp)
            {
                result.ErrMsg = strIp+"该IP已被管理员禁止登录！";
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

                    result.ErrMsg = ErrCode.err40009;
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
                                result.ErrMsg = ErrCode.err40009;
                            }
                            else
                            {
                                Tuple<User, string> userLogin = await this._userService.Validate(username, password);
                                if (userLogin != null)
                                {
                                    string ipAddressName = IpAddressUtil.GetCityByIp(strIp);
                                    if (userLogin.Item1 != null)
                                    {
                                        result.Success = true;
                                        User user = userLogin.Item1;
                                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
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
            yuebonCacheHelper.Remove("LoginValidateCode");
            return ToJsonContent(result,true);
        }

        /// <summary>
        /// 获取登录用户权限信息
        /// </summary>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetUserInfo")]
        [YuebonAuthorize("List")]
        public IActionResult GetUserInfo()
        {
            CommonResult result = new CommonResult();
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
                ActiveSystemId = systemType.Id,
                TenantId = ""
            };

            currentSession.ActiveSystem = systemType.FullName;
            currentSession.ActiveSystemUrl = systemType.Url;

            List<MenuOutputDto> listFunction = new List<MenuOutputDto>();
            MenuApp menuApp = new MenuApp();
            if (Permission.IsAdmin(currentSession))
            {
                currentSession.SubSystemList = _systemTypeService.GetAllByIsNotDeleteAndEnabledMark().MapTo<SystemTypeOutputDto>();
                //取得用户可使用的授权功能信息，并存储在缓存中
                listFunction = menuApp.GetFunctionsBySystem(currentSession.ActiveSystemId);
            }
            else
            {
                currentSession.SubSystemList = _systemTypeService.GetSubSystemList(user.RoleId);
                //取得用户可使用的授权功能信息，并存储在缓存中
                listFunction = menuApp.GetFunctionsByUser(user.Id, currentSession.ActiveSystemId);
            }

            currentSession.MenusRouter = menuApp.GetVueRouter(user.RoleId, systemType.EnCode);
            TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
            yuebonCacheHelper.Add("User_Function_" + user.Id, listFunction, expiresSliding, true);
            List<string> listModules = new List<string>();
            foreach (MenuOutputDto item in listFunction)
            {
                listModules.Add(item.EnCode);
            }
            currentSession.Modules = listModules;
            yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
            //该用户的数据权限
            List<String> roleDateList = _roleDataService.GetListDeptByRole(user.RoleId);
            yuebonCacheHelper.Add("User_RoleData_" + user.Id, roleDateList, expiresSliding, true);
            result.ResData = currentSession;
            result.ErrCode = ErrCode.successCode;
            result.Success = true;
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
        [ApiVersion("2.0")]
        [NoPermissionRequired]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(string username, string password,  string appId, string systemCode)
        {
            CommonResult result = new CommonResult();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
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

                    result.ErrMsg = ErrCode.err40009;
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
                                result.ErrMsg = ErrCode.err40009;
                            }
                            else
                            {
                                Tuple<User, string> userLogin = await this._userService.Validate(username, password);
                                if (userLogin != null)
                                {

                                    string ipAddressName = IpAddressUtil.GetCityByIp(strIp);
                                    if (userLogin.Item1 != null)
                                    {
                                        result.Success = true;

                                        User user = userLogin.Item1;

                                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
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
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Remove("login_user_" + CurrentUser.UserId);
            yuebonCacheHelper.Remove("User_Function_" + CurrentUser.UserId);
            UserLogOn userLogOn = _userLogOnService.GetWhere("UserId='"+ CurrentUser.UserId + "'");
            userLogOn.UserOnLine = false;
            _userLogOnService.Update(userLogOn,userLogOn.Id);
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
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            if (string.IsNullOrEmpty(openmf))
            {
                result.ErrMsg = "切换参数错误！";
            }

            bool blIp = _filterIPService.ValidateIP(strIp);
            if (blIp)
            {
                result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
            }
            else
            {
                string ipAddressName = IpAddressUtil.GetCityByIp(strIp);
                if (string.IsNullOrEmpty(systemCode))
                {
                    result.ErrMsg = ErrCode.err40009;
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
                                result.ErrMsg = ErrCode.err40009;
                            }
                            else
                            {
                                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                                object cacheOpenmf = yuebonCacheHelper.Get("openmf" + openmf);
                                yuebonCacheHelper.Remove("openmf" + openmf);
                                if (cacheOpenmf == null)
                                {
                                    result.ErrCode = "40007";
                                    result.ErrMsg = ErrCode.err40007;
                                }
                                else
                                {
                                    User user = _userService.Get(cacheOpenmf.ToString());
                                    if (user != null)
                                    {
                                        result.Success = true;
                                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
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
    }
}