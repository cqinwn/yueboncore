﻿using Microsoft.AspNetCore.Authorization;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SSOController : ApiController
    {
        private IUserService _userService;
        private ISystemTypeService _systemTypeService;
        private IAPPService _appService;
        private ILogService _logService;
        private IRoleService _roleService;
        private IFilterIPService _filterIPService;
        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="iService"></param>
        /// <param name="systemTypeService"></param>
        /// <param name="logService"></param>
        /// <param name="appService"></param>
        /// <param name="roleService"></param>
        /// <param name="filterIPService"></param>
        public SSOController(IUserService iService, ISystemTypeService systemTypeService,ILogService logService, IAPPService appService, IRoleService roleService, IFilterIPService filterIPService)
        {
            _userService = iService;
            _systemTypeService = systemTypeService;
            _logService = logService;
            _appService = appService;
            _roleService = roleService;
            _filterIPService = filterIPService;
        }

        /// <summary>
        /// 子系统切换登录
        /// </summary>
        /// <param name="openmf">凭据</param>
        /// <param name="appId">应用Id</param>
        /// <param name="systemCode">子系统代码</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("SysConnect")]
        [AllowAnonymous]
        [NoPermissionRequired]
        public async Task<IActionResult> SysConnect(string openmf, string appId,string systemCode)
        {
            CommonResult result = new CommonResult();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            bool blIp = _filterIPService.ValidateIP(strIp);
            if (blIp)
            {
                result.ErrMsg = strIp + "，IP已被管理员禁止登录！";
            }
            else
            {
                string ipAddressName = IpAddressUtil.GetCityByIp(strIp);
                if (string.IsNullOrEmpty(openmf))
                {
                    result.ErrMsg = "切换参数错误！";
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
                        if (!app.RequestUrl.Contains(strHost) && !strHost.Contains("localhost"))
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
                                object dd = yuebonCacheHelper.Get("openmf" + openmf);
                                yuebonCacheHelper.Remove("openmf" + openmf);
                                if (dd == null)
                                {
                                    result.ErrCode = "40007";
                                    result.ErrMsg = ErrCode.err40007;
                                }
                                else
                                {
                                    User user = _userService.Get(dd.ToString());
                                    if (user != null)
                                    {
                                        result.Success = true;
                                        JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                                        TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                        TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
                                        YuebonCurrentUser currentSession = new YuebonCurrentUser
                                        {
                                            UserId = user.Id,
                                            Account = user.Account,
                                            Name = user.RealName,
                                            NickName = user.NickName,
                                            AccessToken = tokenResult.AccessToken,
                                            AppKey = appId,
                                            CreateTime = DateTime.Now,
                                            HeadIcon = user.HeadIcon,
                                            Gender = user.Gender,
                                            ReferralUserId = user.ReferralUserId,
                                            MemberGradeId = user.MemberGradeId,
                                            Role = _roleService.GetRoleEnCode(user.RoleId),
                                            MobilePhone = user.MobilePhone,
                                            OrganizeId = user.OrganizeId,
                                            DeptId = user.DepartmentId,
                                            CurrentLoginIP = strIp,
                                            IPAddressName = ipAddressName
                                        };
                                        currentSession.ActiveSystem = systemType.FullName;
                                        currentSession.ActiveSystemUrl = systemType.Url;
                                        List<FunctionOutputDto> listFunction = new List<FunctionOutputDto>();
                                        FunctionApp functionApp = new FunctionApp();
                                        if (Permission.IsAdmin(currentSession))
                                        {
                                            currentSession.SubSystemList = _systemTypeService.GetAllByIsNotDeleteAndEnabledMark().MapTo<SystemTypeOutputDto>();
                                            currentSession.MenusList = new MenuApp().GetMenuFuntionJson(systemCode);
                                            //取得用户可使用的授权功能信息，并存储在缓存中
                                            listFunction = functionApp.GetFunctionsBySystem(systemType.Id);
                                        }
                                        else
                                        {
                                            currentSession.SubSystemList = _systemTypeService.GetSubSystemList(user.RoleId);
                                            currentSession.MenusList = new MenuApp().GetMenuFuntionJson(user.RoleId, systemCode);

                                            //取得用户可使用的授权功能信息，并存储在缓存中
                                            listFunction = functionApp.GetFunctionsByUser(user.Id, systemType.Id);
                                        }

                                        yuebonCacheHelper.Add("User_Function_" + user.Id, listFunction);
                                        currentSession.Modules = listFunction;
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