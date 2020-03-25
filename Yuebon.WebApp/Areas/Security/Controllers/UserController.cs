using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Security.Dtos;
using Yuebon.WebApp.Models;
using System.Data.Common;
using System.Data;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Mapping;
using System.Reflection;
using Yuebon.Commons.Log;
using Yuebon.Security.Application;
using Yuebon.Commons.Extensions;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class UserController : BusinessController<User, UserOutputDto, IUserService, string>
    {
        private IOrganizeService organizeService;
        private IRoleService roleService;
        private IUserLogOnService userLogOnService;
        public UserController(IUserService _iService,IOrganizeService _organizeService, IRoleService _roleService, IUserLogOnService _userLogOnService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;
            roleService = _roleService;
            userLogOnService = _userLogOnService;

            AuthorizeKey.InsertKey = "User/Add";
            AuthorizeKey.UpdateKey = "User/Edit";
            AuthorizeKey.DeleteKey = "User/Delete";
            AuthorizeKey.UpdateEnableKey = "User/Enable";
            AuthorizeKey.ListKey = "User/List";
            AuthorizeKey.ViewKey = "User/View";
            AuthorizeKey.ExtendKey = "User/ResetPassword";
            AuthorizeKey.DeleteSoftKey = "SystemType/DeleteSoft";
        }

        protected override void OnBeforeInsert(User info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(User info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["nickName"].ToString() == null ? "" : Request.Query["nickName"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SortCode" : Request.Query["sort"].ToString();
            string roleId = Request.Query["roleId"].ToString() == null ? "" : Request.Query["roleId"].ToString();
            string addstartTime = Request.Query["addstartTime"].ToString() == null ? "" : Request.Query["addstartTime"].ToString();
            string addendTime = Request.Query["addendTime"].ToString() == null ? "" : Request.Query["addendTime"].ToString();
            string where = GetPagerCondition();
            bool order = orderByDir == "asc" ? false : true;

            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (NickName like '%{0}%' or Account like '%{0}%' or RealName  like '%{0}%' or MobilePhone like '%{0}%')", keywords);
            }

            if (!string.IsNullOrEmpty(roleId))
            {
                where += string.Format(" and RoleId like '%{0}%'", roleId);
            }
            if (!string.IsNullOrEmpty(addstartTime))
            {
                where += string.Format(" and CreatorTime>='{0}'", addstartTime.ToDateTime());
            }
            if (!string.IsNullOrEmpty(addendTime))
            {
                where += string.Format(" and CreatorTime<='{0}'", addendTime.ToDateTime());
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<UserOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<UserOutputDto>();
            List<UserOutputDto> listResult = new List<UserOutputDto>();
            foreach (UserOutputDto item in list)
            {
                if (!string.IsNullOrEmpty(item.OrganizeId))
                {
                    item.OrganizeName = organizeService.Get(item.OrganizeId).FullName;
                }
                if (!string.IsNullOrEmpty(item.RoleId))
                {
                    item.RoleName = new RoleApp().GetRoleNameStr(item.RoleId);
                }
                if (!string.IsNullOrEmpty(item.DepartmentId))
                {
                    item.DepartmentName = organizeService.Get(item.DepartmentId).FullName;
                }
                if (!string.IsNullOrEmpty(item.DutyId))
                {
                    item.DutyName = roleService.Get(item.DutyId).FullName;
                }
                listResult.Add(item);
            }
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = listResult
            };
            return ToJsonContent(result);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult Add(UserOutputDto info)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.InsertKey);
            CommonResult result = new CommonResult();
            try
            {
                User user = new User();
                user.Account = info.Account;
                user.RealName = info.RealName;
                user.NickName = info.NickName;
                user.Gender = info.Gender;
                user.OrganizeId = info.OrganizeId;
                user.DepartmentId = info.DepartmentId;
                user.RoleId = info.RoleId;
                user.DutyId = info.DutyId;
                user.MobilePhone = info.MobilePhone;
                user.IsAdministrator = info.IsAdministrator;
                user.Birthday = info.Birthday;
                user.Email = info.Email;
                user.WeChat = info.WeChat;
                user.EnabledMark = info.EnabledMark;
                user.Description = info.Description;
                OnBeforeInsert(user);
                UserLogOn userLogOn = new UserLogOn();
                userLogOn.UserPassword = "12345678";
                iService.Insert(user, userLogOn);
                result.Success = true;
            }catch(Exception ex)
            {
                result.ErrMsg = ErrCode.err43001+ex.Message;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }
        /// <summary>
         /// 修改数据
         /// </summary>
         /// <param name="info"></param>
         /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(UserOutputDto info, string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.UpdateKey);
            User user = iService.Get(id);
            CommonResult result = new CommonResult();
            user.Account = info.Account;
            user.RealName = info.RealName;
            user.NickName = info.NickName;
            user.Gender = info.Gender;
            user.OrganizeId = info.OrganizeId;
            user.DepartmentId = info.DepartmentId;
            user.RoleId = info.RoleId;
            user.DutyId = info.DutyId;
            user.MobilePhone = info.MobilePhone;
            user.IsAdministrator = info.IsAdministrator;
            user.Birthday = info.Birthday;
            user.Email = info.Email;
            user.WeChat = info.WeChat;
            user.EnabledMark = info.EnabledMark;
            user.Description = info.Description;
            user.DeleteMark = info.DeleteMark;
            OnBeforeUpdate(user);
            bool bl = iService.Update(user,id);
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

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ResetPassword(string userId)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ExtendKey);
            string where = string.Format("UserId='{0}'", userId);
            CommonResult result = new CommonResult();
            UserLogOn userLogOn = userLogOnService.GetWhere(where);
            Random random = new Random();
            string strRandom = random.Next(100000, 999999).ToString(); //生成编号 
            userLogOn.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
            userLogOn.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(strRandom).ToLower(), userLogOn.UserSecretkey).ToLower()).ToLower();
            bool bl = userLogOnService.Update(userLogOn, userLogOn.Id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = strRandom;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="password2"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ModifyPassword(string password,string password2)
        {
            CommonResult result = new CommonResult();
            if (string.IsNullOrEmpty(password))
            {
                result.ErrMsg = "密码不能为空！";
            }
            else if(string.IsNullOrEmpty(password2))
            {
                result.ErrMsg = "重复输入密码不能为空！";
            }else if (password == password2)
            {
                string where = string.Format("UserId='{0}'",CurrentUser.UserId);
                UserLogOn userLogOn = userLogOnService.GetWhere(where);
               
                userLogOn.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
                userLogOn.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userLogOn.UserSecretkey).ToLower()).ToLower();
                bool bl = userLogOnService.Update(userLogOn, userLogOn.Id);
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

        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IActionResult GetById(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ViewKey);
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id).MapTo<UserOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type,"获取用户异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }
    }
}