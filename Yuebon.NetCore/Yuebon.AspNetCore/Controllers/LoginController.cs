using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.CodeGenerator;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 用户登录接口控制器
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : ApiController
    {
        private IUserService userService;
        private ISystemTypeService systemTypeService;
        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_systemTypeService"></param>
        public LoginController(IUserService _iService, ISystemTypeService _systemTypeService)
        {
            userService = _iService;
            systemTypeService = _systemTypeService;
        }

        /// <summary>
        /// 登录验证用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="appId">AppId</param>
        /// <param name="systemCode">systemCode</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetCheckUser")]
        [NoPermissionRequired]
        public IActionResult GetCheckUser(string username, string password,string appId,string systemCode)
        {

            CommonResult result = new CommonResult();
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
                SystemType systemType = systemTypeService.GetByCode(systemCode);
                if (systemType == null)
                {
                    result.ErrMsg = ErrCode.err40009;
                }
                else { 
                    Tuple<User, string> userLogin = this.userService.Validate(username, password);
                    if (userLogin != null)
                    {
                        if (userLogin.Item1 != null)
                        {
                            result.Success = true;

                            User user = userLogin.Item1;
                            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                           
                            JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                            TokenProvider tokenProvider = new TokenProvider(jwtModel);
                            TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
                            UserAuthSession currentSession = new UserAuthSession
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
                                Role = new RoleApp().GetRoleEnCode(user.RoleId),
                                MobilePhone = user.MobilePhone
                            };
                            currentSession.SubSystemList = systemTypeService.GetSubSystemList(user.RoleId);
                            currentSession.ActiveSystem = systemType.FullName;
                            currentSession.MenusList = new MenuApp().GetMenuFuntionJson(user.RoleId, systemCode);

                            //取得用户可使用的授权功能信息，并存储在缓存中
                            FunctionApp functionApp = new FunctionApp();
                            List<FunctionOutputDto> listFunction = functionApp.GetFunctionsByUser(user.Id, systemType.Id);
                            yuebonCacheHelper.Add("User_Function_" + user.Id, listFunction);
                            currentSession.Modules = listFunction;
                            TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                            yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                                //CookiesHelper.WriteCookie(HttpContext,"loginuser", DEncrypt.Encrypt(user.Id, "qingwen"), 1);
                           
                            CurrentUser = currentSession;
                            result.ResData = currentSession;
                            result.ErrCode = ErrCode.successCode;
                            result.Success = true;
                        }
                        else
                        {
                            result.ErrCode = ErrCode.failCode;
                            result.ErrMsg = userLogin.Item2;
                        }
                    }
                }

            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Logout")]
        [NoPermissionRequired]
        public IActionResult Logout()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                yuebonCacheHelper.Remove("login_user_" + CurrentUser.UserId);
                yuebonCacheHelper.Remove("User_Function_" + CurrentUser.UserId);
                yuebonCacheHelper.Remove("User_Menu_" + CurrentUser.UserId);
                CurrentUser = null;
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = "成功退出";
            }
            return ToJsonContent(result);
        }

    }
}