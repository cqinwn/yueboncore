using Microsoft.AspNetCore.Mvc;
using System;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Models;
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
        /// <param name="url">返回Url</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetCheckUser")]
        public IActionResult GetCheckUser(string username, string password, string url)
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
                Tuple<User, string> user = this.userService.Validate(username, password);
                if (user != null)
                {
                    if (user.Item1 != null)
                    {
                        result.Success = true;

                        UserOutPutDto model = new UserOutPutDto();
                        model.Account = user.Item1.Account;
                        model.Birthday = user.Item1.Birthday;
                        model.Email = user.Item1.Email;
                        model.Gender = user.Item1.Gender;
                        model.HeadIcon = user.Item1.HeadIcon;
                        model.Id = user.Item1.Id;
                        model.IsAdministrator = user.Item1.IsAdministrator;
                        model.ManagerId = user.Item1.ManagerId;
                        model.MobilePhone = user.Item1.MobilePhone;
                        model.NickName = user.Item1.NickName;
                        model.OrganizeId = user.Item1.OrganizeId;
                        model.RealName = user.Item1.RealName;
                        model.RoleId = user.Item1.RoleId;
                        model.SecurityLevel = user.Item1.SecurityLevel;
                        model.Signature = user.Item1.Signature;
                        model.WeChat = user.Item1.WeChat;
                        result.ResData = model;
                        var currentSession = new UserAuthSession
                        {
                            UserId = user.Item1.Id,
                            Account = user.Item1.Account,
                            Name = user.Item1.RealName,
                            NickName = user.Item1.NickName,
                            CreateTime = DateTime.Now,
                            HeadIcon = user.Item1.HeadIcon,
                            Gender = user.Item1.Gender,
                            ReferralUserId = user.Item1.ReferralUserId,
                            MemberGradeId = user.Item1.MemberGradeId
                        };
                        CurrentUser = currentSession;
                    }
                    else
                    {
                        result.ErrCode = ErrCode.failCode;
                        result.ErrMsg = user.Item2;
                    }
                }

            }
            return ToJsonContent(result);
        }

    }
}