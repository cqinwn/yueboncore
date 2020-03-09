using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : ApiController
    {
        private IUserService userService;
        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="_iService"></param>
        public LoginController(IUserService _iService)
        {
            userService = _iService;
        }

        /// <summary>
        /// 登录验证用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="appId">AppId</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetCheckUser")]
        public IActionResult GetCheckUser(string username, string password,string appId)
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
            else
            {
                Tuple<User, string> userLogin = this.userService.Validate(username, password);
                if (userLogin != null)
                {
                    if (userLogin.Item1 != null)
                    {
                        result.Success = true;

                        User user = userLogin.Item1;
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        var currentSession = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + user.Id).ToJson());
                        if (currentSession == null || string.IsNullOrWhiteSpace(currentSession.AccessToken))
                        {
                            JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                            TokenProvider tokenProvider = new TokenProvider(jwtModel);
                            TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
                            currentSession = new UserAuthSession
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
                            TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                            yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                        }
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
            return ToJsonContent(result);
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            CommonResult result = new CommonResult();
            result =  CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                yuebonCacheHelper.Remove("login_user_" + CurrentUser.UserId);
                yuebonCacheHelper.Remove("User_Function_" + CurrentUser.UserId);
                yuebonCacheHelper.Remove("User_Menu_" + CurrentUser.UserId);
                CurrentUser = null;
                result.Success = true;
                result.ErrMsg = "成功登出";
            }
            return ToJsonContent(result);
        }

    }
}