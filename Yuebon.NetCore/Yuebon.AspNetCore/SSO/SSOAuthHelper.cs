using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Net;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.SSO
{
    /// <summary>
    /// SSO单点登录
    /// </summary>
    public class SSOAuthHelper
    {
        private ISystemTypeService systemTypeService;
        private IAPPService aPPService;
        private IUserService userService;
        private IUserLogOnService userLogOnService;
        private readonly JwtOption jwtModel;
        private ILogService logService;
        private IRoleService roleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_systemTypeService"></param>
        /// <param name="_aPPService"></param>
        /// <param name="_userService"></param>
        /// <param name="_userLogOnService"></param>
        /// <param name="_jwtModel"></param>
        /// <param name="_logService"></param>
        /// <param name="_roleService"></param>
        public SSOAuthHelper(ISystemTypeService _systemTypeService, IAPPService _aPPService, IUserService _userService, IUserLogOnService _userLogOnService, JwtOption _jwtModel, ILogService _logService, IRoleService _roleService)
        {
            systemTypeService = _systemTypeService;
            aPPService = _aPPService;
            userService = _userService;
            userLogOnService = _userLogOnService;
            jwtModel = _jwtModel;
            logService = _logService;
            roleService = _roleService;
        }
        /// <summary>
        /// 用户登录验证，主要用管理后台、H5和App应用用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<LoginResult> Validate(PassportLoginRequest model)
        {
            var result = new LoginResult();
            try
            {
                model.Trim();

                RemoteIpParser remoteIpParser = new RemoteIpParser();
                //获取应用信息

                var systemType = systemTypeService.GetByCode(model.SystemCode);
                if (systemType == null)
                {
                    throw new Exception("应用不存在");
                }
                //获取用户信息
                User userInfo = new User();
                userInfo = await userService.GetByUserName(model.Account);

                if (userInfo == null)
                {
                    userInfo = await userService.GetUserByMobilePhone(model.Account);
                    if (userInfo == null)
                    {
                        throw new Exception("用户不存在");
                    }
                }
                UserLogOn userLogOn = userLogOnService.GetByUserId(userInfo.Id);
                string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(model.Password).ToLower(), userLogOn.UserSecretkey).ToLower()).ToLower();

                if (userLogOn.UserPassword != inputPassword)
                {
                    throw new Exception("密码错误");
                }
                TokenProvider tokenProvider = new TokenProvider(jwtModel);
                TokenResult tokenResult = tokenProvider.LoginToken(userInfo, model.SystemCode);
                var currentSession = new YuebonCurrentUser
                {
                    UserId = userInfo.Id,
                    Account = userInfo.Account,
                    Name = userInfo.RealName,
                    NickName = userInfo.NickName,
                    AccessToken = tokenResult.AccessToken,
                    AppKey = model.SystemCode,
                    CreateTime = DateTime.Now,
                    HeadIcon = userInfo.HeadIcon,
                    Gender = userInfo.Gender,
                    ReferralUserId = userInfo.ReferralUserId,
                    MemberGradeId = userInfo.MemberGradeId,
                    Role = roleService.GetRoleEnCode(userInfo.RoleId)
                };

                currentSession.ActiveSystem = systemType.FullName;
                currentSession.ActiveSystemUrl = systemType.Url;
                List<FunctionOutputDto> listFunction = new List<FunctionOutputDto>();
                FunctionApp functionApp = new FunctionApp();
                if (Permission.IsAdmin(currentSession))
                {
                    currentSession.SubSystemList = systemTypeService.GetAllByIsNotDeleteAndEnabledMark().MapTo<SystemTypeOutputDto>();
                    currentSession.MenusList = new MenuApp().GetMenuFuntionJson(model.SystemCode);
                    //取得用户可使用的授权功能信息，并存储在缓存中
                    listFunction = functionApp.GetFunctionsBySystem(systemType.Id);
                }
                else
                {
                    currentSession.SubSystemList = systemTypeService.GetSubSystemList(userInfo.RoleId);
                    currentSession.MenusList = new MenuApp().GetMenuFuntionJson(userInfo.RoleId, model.SystemCode);

                    //取得用户可使用的授权功能信息，并存储在缓存中
                    listFunction = functionApp.GetFunctionsByUser(userInfo.Id, systemType.Id);
                }


                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();

                yuebonCacheHelper.Add("User_Function_" + userInfo.Id, listFunction);
                currentSession.Modules = listFunction;
                TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                yuebonCacheHelper.Add("login_user_" + userInfo.Id, currentSession, expiresSliding, true);
                result.AccessToken = tokenResult.AccessToken;
                result.ErrCode =ErrCode.successCode;
                result.ReturnUrl = systemType.Url;

                Log logEntity = new Log();
                logEntity.Account = currentSession.Account;
                logEntity.NickName = currentSession.RealName;
                logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                //logEntity.IPAddress = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                //logEntity.IPAddressName = IpAddressUtil.GetCityByIp(logEntity.IPAddress);
                logEntity.Result = true;
                logEntity.ModuleName = "登录";
                logEntity.Description = "登录成功";
                logEntity.Type = "Login";
                logService.Insert(logEntity);
            }
            catch (Exception ex)
            {
                result.ErrCode = "500";
                result.ErrMsg = ex.Message;
            }

            return result;
        }
    }
}
