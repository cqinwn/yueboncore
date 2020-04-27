using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;
using Yuebon.AspNetCore.UI;
using Yuebon.AspNetCore.Mvc;
using Yuebon.WebApi.Areas.Security.Models;
using Yuebon.Commons.Encrypt;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class UserController : AreaApiController<User, UserOutputDto, UserInputDto, IUserService,string>
    {
        private IOrganizeService organizeService;
        private IRoleService roleService;
        private IUserLogOnService userLogOnService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_organizeService"></param>
        /// <param name="_roleService"></param>
        /// <param name="_userLogOnService"></param>
        public UserController(IUserService _iService, IOrganizeService _organizeService, IRoleService _roleService, IUserLogOnService _userLogOnService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;
            roleService = _roleService;
            userLogOnService = _userLogOnService;
            AuthorizeKey.ListKey = "User/List";
            AuthorizeKey.InsertKey = "User/Add";
            AuthorizeKey.UpdateKey = "User/Edit";
            AuthorizeKey.UpdateEnableKey = "User/Enable";
            AuthorizeKey.DeleteKey = "User/Delete";
            AuthorizeKey.DeleteSoftKey = "User/DeleteSoft";
            AuthorizeKey.ViewKey = "User/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(User info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
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
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(User info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }


        /// <summary>
        /// 异步新增数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public override async Task<IActionResult> InsertAsync(UserInputDto tinfo)
        {
            CommonResult result = new CommonResult();

            if (!string.IsNullOrEmpty(tinfo.Account))
            {
                string where = string.Format("Account='{0}'", tinfo.Account);
                User user = iService.GetWhere(where);
                if (user != null)
                {
                    result.ErrMsg = "登录账号不能重复";
                    return ToJsonContent(result);
                }
            }
            else
            {
                result.ErrMsg = "登录账号不能为空";
                return ToJsonContent(result);
            }
            User info = tinfo.MapTo<User>();
            OnBeforeInsert(info);
            UserLogOn userLogOn = new UserLogOn();
            userLogOn.UserPassword = "12345678";
            result.Success = await iService.InsertAsync(info, userLogOn);
            if (result.Success)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43001;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(UserInputDto tinfo, string id)
        {
            CommonResult result = new CommonResult();
            if (!string.IsNullOrEmpty(tinfo.Account))
            {
                string where = string.Format(" Account='{0}'  and id!='{1}' ", tinfo.Account, id);
                User user = iService.GetWhere(where);
                if (user != null)
                {
                    result.ErrMsg = "登录账号不能重复";
                    return ToJsonContent(result);
                }
            }
            else
            {
                result.ErrMsg = "登录账号不能为空";
                return ToJsonContent(result);
            }
            User info = iService.Get(id);
            info.Account = tinfo.Account;
            info.HeadIcon = tinfo.HeadIcon;
            info.RealName = tinfo.RealName;
            info.NickName = tinfo.NickName;
            info.Gender = tinfo.Gender;
            info.Birthday = tinfo.Birthday;
            info.MobilePhone = tinfo.MobilePhone;
            info.WeChat = tinfo.WeChat;
            info.OrganizeId = tinfo.OrganizeId;
            info.RoleId = tinfo.RoleId;
            info.IsAdministrator = tinfo.IsAdministrator;
            info.Email = tinfo.Email;
            info.EnabledMark = tinfo.EnabledMark;
            info.Description = tinfo.Description;

            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info, id).ConfigureAwait(false);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据用户登录账号获取详细信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        [HttpGet("GetByUserName")]
        [YuebonAuthorize("Edit")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            CommonResult result = new CommonResult();
            try
            {
                User user = await iService.GetByUserName(userName);
                result.ResData = user.MapTo<UserOutputDto>();
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取用户异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerSearchAsync")]
        [YuebonAuthorize("List")]
        public  async Task<IActionResult> FindWithPagerSearchAsync([FromQuery]SearchUserModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();

            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (NickName like '%{0}%' or Account like '%{0}%' or RealName  like '%{0}%' or MobilePhone like '%{0}%')", search.Keywords);
            }

            if (!string.IsNullOrEmpty(search.RoleId))
            {
                where += string.Format(" and RoleId like '%{0}%'", search.RoleId);
            }
            if (!string.IsNullOrEmpty(search.CreatorTime1))
            {
                where += " and CreatorTime >='" + search.CreatorTime1 + " 00:00:00'";
            }
            if (!string.IsNullOrEmpty(search.CreatorTime2))
            {
                where += " and CreatorTime <'" + search.CreatorTime2 + " 23:59:59'";
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<User> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<UserOutputDto> resultList = list.MapTo<UserOutputDto>();
            List<UserOutputDto> listResult = new List<UserOutputDto>();
            foreach (UserOutputDto item in resultList)
            {
                if (!string.IsNullOrEmpty(item.OrganizeId))
                {
                    item.OrganizeName = organizeService.Get(item.OrganizeId).FullName;
                }
                if (!string.IsNullOrEmpty(item.RoleId))
                {
                    item.RoleName = roleService.GetRoleNameStr(item.RoleId);
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
            PageResult<UserOutputDto> pageResult = new PageResult<UserOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = listResult,
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            result.ResData = pageResult;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }


        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        [YuebonAuthorize("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string userId)
        {
            CommonResult result = new CommonResult();
            try
            {
                string where = string.Format("UserId='{0}'", userId);
                UserLogOn userLogOn = userLogOnService.GetWhere(where);
                Random random = new Random();
                string strRandom = random.Next(100000, 999999).ToString(); //生成编号 
                userLogOn.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
                userLogOn.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(strRandom).ToLower(), userLogOn.UserSecretkey).ToLower()).ToLower();
                bool bl = await userLogOnService.UpdateAsync(userLogOn, userLogOn.Id);
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
            }catch(Exception ex)
            {
                Log4NetHelper.Error("重置密码异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldpassword">原密码</param>
        /// <param name="password">新密码</param>
        /// <param name="password2">重复新密码</param>
        /// <returns></returns>

        [HttpPost("ModifyPassword")]
        [YuebonAuthorize("ModifyPassword")]
        public async Task<IActionResult> ModifyPassword(string oldpassword,string password, string password2)
        {
            CommonResult result = new CommonResult();
            try
            {
                if (string.IsNullOrEmpty(oldpassword))
                {
                    result.ErrMsg = "原密码不能为空！";
                }
                else if (!string.IsNullOrEmpty(oldpassword))
                {
                    var userSinginEntity = userLogOnService.GetByUserId(CurrentUser.UserId);
                    string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(oldpassword).ToLower(), userSinginEntity.UserSecretkey).ToLower()).ToLower();
                    if (inputPassword != userSinginEntity.UserPassword)
                    {
                        result.ErrMsg = "原密码错误！";
                    }
                }
                else if (string.IsNullOrEmpty(password))
                {
                    result.ErrMsg = "密码不能为空！";
                }
                else if (string.IsNullOrEmpty(password2))
                {
                    result.ErrMsg = "重复输入密码不能为空！";
                }
                else if (password == password2)
                {
                    string where = string.Format("UserId='{0}'", CurrentUser.UserId);
                    UserLogOn userLogOn = userLogOnService.GetWhere(where);

                    userLogOn.UserSecretkey = MD5Util.GetMD5_16(GuidUtils.NewGuidFormatN()).ToLower();
                    userLogOn.UserPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userLogOn.UserSecretkey).ToLower()).ToLower();
                    bool bl = await userLogOnService.UpdateAsync(userLogOn, userLogOn.Id);
                    if (bl)
                    {
                        result.ErrCode = ErrCode.successCode;
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
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("重置密码异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }
    }
}