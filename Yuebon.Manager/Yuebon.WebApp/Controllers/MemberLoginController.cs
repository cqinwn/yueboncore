using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Net;
using Yuebon.Security.Application.SSO;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Shop.Application;
using Yuebon.Shop.Dtos;
using Yuebon.Shop.IServices;
using Yuebon.Shop.Models;
using Yuebon.WebApp.Models;

namespace Yuebon.WebApp.Controllers
{
    public class MemberLoginController : BaseController
    {
        private IMembersService membersService;
        private IRoleService roleService;
        private ILogService logService;
        private ICacheService redisCacheService;
        private ICacheService memoryCacheService;
        private string _appKey = "openauth";
        private string appSecret = "";
        private AuthHelper authHelper;
        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="_iService"></param>
        public MemberLoginController(IMembersService _iService, IRoleService _roleService, ILogService _logService, ICacheService _cacheService, AuthHelper _authHelper)
        {
            membersService = _iService;
            roleService = _roleService;
            logService = _logService;
            redisCacheService = _cacheService;
            memoryCacheService = _cacheService;
            authHelper = _authHelper;
        }

        public IActionResult Index()
        {
            ViewData["SoftName"] = Configs.GetConfigurationValue("AppSetting", "SoftName");
            ViewData["CertificatedCompany"] = Configs.GetConfigurationValue("AppSetting", "CertificatedCompany");
            ViewData["Title"] = ViewData["SoftName"];
            ViewData["Copyriht"] = string.Format("<strong>Copyright &copy; 2017-{0} <a href=\"http://www.yuebon.com\" target=\"_blank\">Yuebon Tech</a>.</strong>", DateTime.Now.Year);

            return View();
        }

        /// <summary>
        /// 登录验证用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回用户User对象</returns>
        public IActionResult GetCheckUser(string username, string password)
        {
            CommonResult result = new CommonResult();
            Log logEntity = new Log();
            RemoteIpParser remoteIpParser = new RemoteIpParser();
            logEntity.ModuleName = "系统登录";
            logEntity.Type = DbLogType.Login.ToString();
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
                MembersApp membersApp = new MembersApp();
                Tuple<Members, string> user = membersApp.Validate(username, password);
                if (user != null)
                {
                    if (user.Item1 != null)
                    {
                        result.Success = true;
                        MembersDto model = new MembersDto();
                        model.UserName = user.Item1.UserName;
                        model.BirthDate = user.Item1.BirthDate;
                        model.Email = user.Item1.Email;
                        model.Gender = user.Item1.Gender;
                        model.Picture = user.Item1.Picture;
                        model.Id = user.Item1.Id;
                        model.NickName = user.Item1.NickName;
                        model.RealName = user.Item1.RealName;
                        model.WeChat = user.Item1.WeChat;
                        model.CurrentLoginIP = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                        result.ResData = model;
                        CurrentMembers = model;
                        //记录Session

                        HttpContext.Session.SetString("CurrentUserId", "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba");
                        HttpContext.Session.SetString("CurrentMemberId", user.Item1.Id.ToString());
                        HttpContext.Session.Set("CurrentMember", ByteConvertHelper.Object2Bytes(model));
                        var currentSession = new UserAuthSession
                        {
                            UserId = user.Item1.Id,
                            Account = model.UserName,
                            Name = model.RealName,
                            Token = Guid.NewGuid().ToString().GetHashCode().ToString("x"),
                            AppKey = "openauth",
                            CreateTime = DateTime.Now
                            //,IpAddress = HttpContext.Current.Request.UserHostAddress
                        };
                        //创建Session
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        yuebonCacheHelper.Add(currentSession.Token, currentSession);
                        HttpContext.Response.Cookies.Append("Token", currentSession.Token, new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(30)
                        });
                        //取得用户可使用的授权功能信息，并存储在缓存中
                       
                        #region 取得可访问数据权限
                       
                        #endregion

                        logEntity.Account = user.Item1.UserName;
                        logEntity.NickName = user.Item1.RealName;
                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                        logEntity.IPAddress = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                        logEntity.Result = true;
                        logEntity.Description = "会员登录成功";
                        //logService.Insert(logEntity);
                    }
                    else
                    {
                        logEntity.Account = username;
                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                        logEntity.IPAddress = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                        logEntity.Result = false;
                        logEntity.Description = "会员登录失败，" + user.Item2;
                        //logService.Insert(logEntity);
                        result.ErrCode = ErrCode.failCode;
                        result.ErrMsg = user.Item2;
                    }
                }
            }
            return ToJsonContent(result);
        }
    }
}