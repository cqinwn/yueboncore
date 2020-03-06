using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Net;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Commons;
using Yuebon.WebApp.Models;

namespace Yuebon.WebApp.Controllers
{
    public class LoginController : BaseController
    {
        private IUserService userService;
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
        public LoginController(IUserService _iService, IRoleService _roleService, ILogService _logService, ICacheService _cacheService, AuthHelper _authHelper)
        {
            userService = _iService;
            roleService = _roleService;
            logService = _logService;
            redisCacheService = _cacheService;
            memoryCacheService = _cacheService;
            authHelper = _authHelper;
        }

        public IActionResult Index()
        {
            //CodeGenerator.Generate();//生成所有实体类对应的Repository和Service层代码文件
            //CodeGenerator.GenerateSingle<Advert, int>();//生成单个实体类对应的Repository和Service层代码文件
            //CodeGenerator.GenerateSingle<Banner, int>();//生成单个实体类对应的Repository和Service层代码文件
            //HttpContext.Session.Clear();
            SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Add("SysSetting", sysSetting);
            ViewData["SoftName"] = sysSetting.SoftName;
            ViewData["CertificatedCompany"] =sysSetting.CompanyName;
            ViewData["Logo"] = sysSetting.SysLogo;
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
                Tuple<User, string> user = this.userService.Validate(username, password);
                if (user != null)
                {
                    if (user.Item1 != null)
                    {
                        result.Success = true;
                        UserLoginDto model = new UserLoginDto();
                        model.Account = user.Item1.Account;
                        model.Birthday = user.Item1.Birthday;
                        model.Email = user.Item1.Email;
                        model.Gender = user.Item1.Gender;
                        model.HeadIcon = user.Item1.HeadIcon;
                        model.UserId = user.Item1.Id;
                        model.IsAdministrator = user.Item1.IsAdministrator;

                        model.MobilePhone = user.Item1.MobilePhone;
                        model.NickName = user.Item1.NickName;
                        model.OrganizeId = user.Item1.OrganizeId;
                        model.DepartmentId = user.Item1.DepartmentId;
                        model.RealName = user.Item1.RealName;
                        model.RoleId = user.Item1.RoleId;

                        model.SecurityLevel = user.Item1.SecurityLevel;
                        model.Signature = user.Item1.Signature;
                        model.WeChat = user.Item1.WeChat;
                        model.CurrentLoginIP = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                        result.ResData = model;
                        CurrentUser = model;

                        var currentSession = new UserAuthSession
                        {
                            UserId = user.Item1.Id,
                            Account = model.Account,
                            Name = model.RealName,
                            AccessToken = Guid.NewGuid().ToString().GetHashCode().ToString("x"),
                            AppKey = "openauth",
                            CreateTime = DateTime.Now
                            //,IpAddress = HttpContext.Current.Request.UserHostAddress
                        };

                        byte[] currentUserSession;
                        HttpContext.Session.TryGetValue("CurrentUser", out currentUserSession);

                        //创建Session
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        yuebonCacheHelper.Add(currentSession.AccessToken, currentSession);
                        //记录Session
                        HttpContext.Session.SetString("CurrentUserId", user.Item1.Id.ToString());
                        HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(model));
                        HttpContext.Response.Cookies.Append("Token", currentSession.AccessToken, new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(30)
                        });
                        //取得用户可使用的授权功能信息，并存储在缓存中 
                        FunctionApp functionApp = new FunctionApp();
                        List<FunctionOutputDto> list = new List<FunctionOutputDto>();
                        if (!new Permission().IsAdmin())
                        {
                            list = functionApp.GetFunctionsByUser(user.Item1.Id, "");
                        }
                        else
                        {
                            list = functionApp.GetFunctionsByAdmin(user.Item1.RoleId, "");
                        }
                        yuebonCacheHelper.Add("User_Function_" + user.Item1.Id, list);


                        //RoleData roleData = new RoleData();
                        //roleData = new RoleDataApp().GetId(user.Item1.RoleId);

                        #region 取得可访问数据权限
                        if (!new Permission().IsAdmin())
                        {
                            List<RoleData> roleDataList = new RoleDataApp().FindByUser(user.Item1.Id);
                            string DataFilterCondition = string.Empty;
                            string belongCompanys = string.Empty;
                            string belongDepts = string.Empty;
                            foreach (RoleData roleDataItem in roleDataList)
                            {
                                if (!string.IsNullOrEmpty(roleDataItem.BelongCompanys))
                                {
                                    belongCompanys += roleDataItem.BelongCompanys + ",";
                                }
                                if (!string.IsNullOrEmpty(roleDataItem.BelongDepts))
                                {
                                    belongDepts += roleDataItem.BelongDepts + ",";
                                }
                            }
                            if (!string.IsNullOrEmpty(belongCompanys))
                            {
                                belongCompanys = belongCompanys.Substring(0, belongCompanys.Length - 1).Replace(",", "','");
                                DataFilterCondition += string.Format(" AND (CompanyId is null or CompanyId in ('{0}')) ", belongCompanys);
                            }
                            if (!string.IsNullOrEmpty(belongDepts))
                            {
                                belongDepts = belongDepts.Substring(0, belongDepts.Length - 1).Replace(",", "','");
                                DataFilterCondition += string.Format(" AND (DeptId is null or DeptId in ('{0}'))  ", belongDepts);
                            }
                            yuebonCacheHelper.Add("DataFilterCondition_" + user.Item1.Id, DataFilterCondition);
                        }
                        else
                        {
                            yuebonCacheHelper.Add("DataFilterCondition_" + user.Item1.Id, "");
                        }
                        #endregion

                        logEntity.Account = user.Item1.Account;
                        logEntity.NickName = user.Item1.RealName;
                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                        logEntity.IPAddress= remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                        logEntity.IPAddressName = IpAddressUtil.GetCityByIp(logEntity.IPAddress);
                        logEntity.Result = true;
                        logEntity.Description = "登录成功";
                        logService.Insert(logEntity);
                    }
                    else
                    {
                        logEntity.Account = username;
                        logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                        logEntity.IPAddress = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
                        logEntity.IPAddressName = IpAddressUtil.GetCityByIp(logEntity.IPAddress);
                        logEntity.Result = false;
                        logEntity.Description = "登录失败，"+ user.Item2;
                        logService.Insert(logEntity);
                        result.ErrCode = ErrCode.failCode;
                        result.ErrMsg = user.Item2;
                    }
                }
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IActionResult GetLogin(string username, string password)
        {
            CommonResult resp = new CommonResult();
            try
            {
                //var dico = await DiscoveryClient.GetAsync("http://localhost:5000");

                //TokenClientOptions tokenClientOptions = new TokenClientOptions();
                //tokenClientOptions.ClientId = "mvcauth.netcoremvc";
                //tokenClientOptions.ClientSecret = "secret";
                ////token
                //var tokenClient = new TokenClient(dico.TokenEndpoint, tokenClientOptions);

                //var tokenresp = await tokenClient.RequestPasswordTokenAsync(username, password, "YuebonWebApi");

                //var userInfoClient = new UserInfoClient();

                //var response = await userInfoClient.GetAsync(tokenresp.AccessToken);
                //var claims = response.Claims;

                //var client = new HttpClient();
                //HttpContent httpContent = new StringContent("", Encoding.UTF8);
                //client.SetBearerToken(tokenresp.AccessToken);
                //httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //var resps = await client.PostAsync(dico.UserInfoEndpoint, httpContent);

                //var resps2 = await client.GetAsync("https://localhost:44363/api/Identity");


                //Byte[] resultBytes = resps2.Content.ReadAsByteArrayAsync().Result;
                //string ii = Encoding.UTF8.GetString(resultBytes);
                //Response.Cookies.Append("Token", tokenresp.AccessToken);

                //UserAuthInfo userAuthSession = await authHelper.GetCurrentUser2();

                LoginResult result = authHelper.Login(_appKey, appSecret, username, password);
                if (result.Success)
                {
                    Response.Cookies.Append("Token", result.AccessToken);
                    return ToJsonContent(result);
                }
                else
                {
                    resp.ErrCode = "500";
                    resp.ErrMsg = result.ErrMsg;
                }

            }
            catch (Exception e)
            {
                resp.ErrCode = "500";
                resp.ErrMsg = e.Message;
            }

            return ToJsonContent(resp);
        }

    }
}