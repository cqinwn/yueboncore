using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Models;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_systemTypeService"></param>
        /// <param name="_aPPService"></param>
        /// <param name="_userService"></param>
        /// <param name="_userLogOnService"></param>
        /// <param name="_jwtModel"></param>
        public SSOAuthHelper(ISystemTypeService _systemTypeService, IAPPService _aPPService, IUserService _userService, IUserLogOnService _userLogOnService, JwtOption _jwtModel)
        {
            systemTypeService = _systemTypeService;
            aPPService = _aPPService;
            userService = _userService;
            userLogOnService = _userLogOnService;
            jwtModel = _jwtModel;
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
                    Role =new RoleApp().GetRoleEnCode(userInfo.RoleId)
                };

                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                yuebonCacheHelper.Add("login_user_" + userInfo.Id, currentSession, expiresSliding, true);
                result.AccessToken = tokenResult.AccessToken;
                result.ErrCode =ErrCode.successCode;
                result.ReturnUrl = systemType.Url;
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
