using Microsoft.AspNetCore.Mvc;
using System;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController :ApiController
    {
        private IUserService _userService;
        private ISystemTypeService _systemTypeService;
        private IAPPService _appService;
        private ILogService _logService;
        private IRoleService _roleService;
        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="iService"></param>
        /// <param name="systemTypeService"></param>
        /// <param name="roleService"></param>
        /// <param name="logService"></param>
        /// <param name="appService"></param>
        public DashboardController(IUserService iService, ISystemTypeService systemTypeService, IRoleService roleService ,ILogService logService, IAPPService appService)
        {
            _userService = iService;
            _systemTypeService = systemTypeService;
            _logService = logService;
            _roleService = roleService;
            _appService = appService;
        }

        /// <summary>
        /// 子系统初始化
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="appId">应用Id</param>
        /// <param name="systemCode">子系统代码</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("InitSystem")]
        [NoPermissionRequired]
        public IActionResult InitSystem(long userId,string appId, string systemCode)
        {
            CommonResult result = new CommonResult();
            if (string.IsNullOrEmpty(userId.ToString()))
            {
                result.ErrMsg = ErrCode.err40007;
            }
            if (string.IsNullOrEmpty(systemCode))
            {
                result.ErrMsg = ErrCode.err40007;
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
                            result.ErrMsg = ErrCode.err40007;
                        }
                        else
                        {
                            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                            User user = _userService.Get(userId);
                            if (user != null)
                            {
                                result.Success = true;
                                JwtOption jwtModel = Appsettings.GetService<JwtOption>();
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
                                    //CurrentLoginIP = strIp,
                                    //IPAddressName = ipAddressName,
                                    TenantId = null
                                };
                                currentSession.SubSystemList = _systemTypeService.GetSubSystemList(user.RoleId);
                                currentSession.ActiveSystem = systemType.FullName;
                                currentSession.ActiveSystemUrl = systemType.Url;
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
            return ToJsonContent(result);
        }
    }
}