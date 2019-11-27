using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Yuebon.Commons;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Shop.IServices;
using Yuebon.Shop.Models;
using Yuebon.WebApp.Models;

namespace Yuebon.WebApp.Controllers
{
    public class MemberHomeController : BusinessMemberController<Members, IMembersService>
    {
        public MemberHomeController(IMembersService _iService) : base(_iService)
        {
            iService = _iService;
        }

        public override IActionResult Index()
        {
            if (CurrentMembers==null)
            {
                return Redirect("/");
            }
            ViewData["Account"] = CurrentMembers.UserName;
            ViewData["RealName"] = CurrentMembers.RealName;
            ViewData["UserName"] = string.Format("{0}({1})", CurrentMembers.RealName, CurrentMembers.UserName);
            ViewData["SoftName"] = Configs.GetConfigurationValue("AppSetting", "SoftName");
            ViewData["Title"] = ViewData["SoftName"];
            ViewData["Copyriht"] = string.Format("<strong>Copyright &copy; 2017-{0} <a href=\"http://www.yuebon.com\" target=\"_blank\">Yuebon Tech</a>.</strong> All rights reserved.", DateTime.Now.Year);
            return View(CurrentMembers);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="password2"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ModifyPassword(string password, string password2)
        {
            CommonResult result = new CommonResult();
            if (string.IsNullOrEmpty(password))
            {
                result.ErrMsg = "密码不能为空！";
            }
            else if (string.IsNullOrEmpty(password2))
            {
                result.ErrMsg = "重复输入密码不能为空！";
            }
            else if (password == password2)
            {
                string where = string.Format("UserId='{0}'", CurrentMembers.Id);
                Members members = iService.Get(CurrentMembers.Id);
                members.PasswordSalt = MD5Util.GetMD5_32(members.UserName + password).Substring(0, 16).ToLower();
                members.Password = QQEncryptUtil.EncodePasswordWithVerifyCode(password, members.PasswordSalt);

                bool bl = iService.Update(members, members.Id);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            else
            {
                result.ErrMsg = "两次输入的密码不一样";
            }
            return ToJsonContent(result);
        }
    }
}
