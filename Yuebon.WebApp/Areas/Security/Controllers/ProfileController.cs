using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.Security.Controllers
{

    /// <summary>
    /// 个人信息
    /// </summary>
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class ProfileController : BusinessController<User, IUserService>
    {
        public ProfileController(IUserService _iService) : base(_iService)
        {
            iService = _iService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IActionResult Index()
        {
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            ViewData["id"] = CurrentUser.UserId;
            return View();
        }
        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override  IActionResult GetById(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ViewKey);
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id).MapTo<UserOutPutDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type, "获取用户异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(UserOutPutDto info, string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.UpdateKey);
            User user = iService.Get(id);
            CommonResult result = new CommonResult();
            user.RealName = info.RealName;
            user.HeadIcon = info.HeadIcon;
            user.NickName = info.NickName;
            user.Gender = info.Gender;
            user.OrganizeId = info.OrganizeId;
            user.DepartmentId = info.DepartmentId;
            user.DutyId = info.DutyId;
            user.MobilePhone = info.MobilePhone;
            user.Birthday = info.Birthday;
            user.Email = info.Email;
            user.WeChat = info.WeChat;
            OnBeforeUpdate(user);
            bool bl = iService.Update(user, id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }
    }
}