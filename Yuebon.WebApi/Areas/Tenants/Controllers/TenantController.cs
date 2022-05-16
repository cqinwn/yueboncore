using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.IServices;
using Yuebon.Tenants.Models;
using Yuebon.WebApi.Areas.Security.Models;

namespace Yuebon.SecurityApi.Areas.Tenants.Controllers
{
    /// <summary>
    /// 租户接口
    /// </summary>
    [ApiController]
    [Route("api/Tenants/[controller]")]
    public class TenantController : AreaApiController<Tenant, TenantOutputDto,TenantInputDto,ITenantService>
    {

        private IFilterIPService _filterIPService;
        private IMenuService _menuService;
        private IAPPService _appService;
        private ISystemTypeService _systemTypeService;
        private ILogService _logService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="filterIPService"></param>
        /// <param name="menuService"></param>
        /// <param name="appService"></param>
        /// <param name="systemTypeService"></param>
        /// <param name="logService"></param>
        public TenantController(ITenantService _iService, IFilterIPService filterIPService, IMenuService menuService, IAPPService appService, ISystemTypeService systemTypeService, ILogService logService) : base(_iService)
        {
            iService = _iService;
            _filterIPService = filterIPService;
            _menuService = menuService;
            _appService = appService;
            _systemTypeService = systemTypeService;
            _logService = logService;
        }

        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Tenant info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DeptId;
            info.DeleteMark = false;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Tenant info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Tenant info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public override async Task<IActionResult> InsertAsync(TenantInputDto tinfo)
        {
            CommonResult result = new CommonResult();

            if (!tinfo.TenantName.ToLower().IsAlphanumeric())
            {
                result.ErrMsg = "名称只能是字母和数字";
                result.ErrCode = "43002";
                return ToJsonContent(result);
            }
            Tenant info = tinfo.MapTo<Tenant>();

            info.TenantName = tinfo.TenantName.ToLower();
            OnBeforeInsert(info);

            TenantLogon tenantLogon = new TenantLogon();
            tenantLogon.TenantPassword = "12345678";
            tenantLogon.AllowStartTime = tenantLogon.LockEndDate = tenantLogon.LockStartDate = tenantLogon.ChangePasswordDate = DateTime.Now;
            tenantLogon.AllowEndTime = DateTime.Now.AddYears(100);
            tenantLogon.MultiUserLogin = tenantLogon.CheckIPAddress = false;
            tenantLogon.LogOnCount = 0;
            result.Success = await iService.InsertAsync(info, tenantLogon);
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
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(TenantInputDto tinfo)
        {
            CommonResult result = new CommonResult();
            if (!tinfo.TenantName.ToLower().IsAlphanumeric())
            {
                result.ErrMsg = "名称只能是字母和数字";
                result.ErrCode = "43002";
                return ToJsonContent(result);
            }
            Tenant info = iService.Get(tinfo.Id);
            info.TenantName = tinfo.TenantName.ToLower();
            info.CompanyName = tinfo.CompanyName;
            info.HostDomain = tinfo.HostDomain;
            info.DataSource = tinfo.DataSource;
            info.LinkMan = tinfo.LinkMan;
            info.Telphone = tinfo.Telphone;
            info.EnabledMark = tinfo.EnabledMark;
            info.Description = tinfo.Description;
            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info);
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
        /// 初始化租户数据
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        [HttpGet("InitTenantData")]
        [YuebonAuthorize("InitTenantData")]
        public async Task<IActionResult> InitTenantData(long tenantId)
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            Tenant info = iService.Get(tenantId);
            if (info.Schema == Commons.Enums.TenantSchemaEnum.Alone)
            {
                bl = await iService.InitTenantDataAsync(info);
            }
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
        /// 租户注册
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        [NoPermissionRequired]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel info)
        {
            CommonResult result = new CommonResult();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            var vCode = yuebonCacheHelper.Get("ValidateCode" + info.VerifyCodeKey);
            string code = vCode != null ? vCode.ToString() : "11";
            if (code != info.VerificationCode.ToUpper())
            {
                result.ErrMsg = "验证码错误";
                return ToJsonContent(result);
            }
            if (!string.IsNullOrEmpty(info.Account))
            {
                if (string.IsNullOrEmpty(info.Password) || info.Password.Length < 6)
                {
                    result.ErrMsg = "密码不能为空或小于6位";
                    return ToJsonContent(result);
                }
                Tenant user = await iService.GetByUserName(info.Account);
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
            Tenant tenant = new Tenant();
            tenant.Id = IdGeneratorHelper.IdSnowflake();
            tenant.TenantName = info.Account;
            tenant.Email = info.Email;
            tenant.CreatorTime = DateTime.Now;
            tenant.EnabledMark = true;
            tenant.DeleteMark = false;

            TenantLogon tenantLogon = new TenantLogon();
            tenantLogon.TenantPassword = info.Password;
            tenantLogon.AllowStartTime = tenantLogon.LockEndDate = tenantLogon.LockStartDate = tenantLogon.ChangePasswordDate = DateTime.Now;
            tenantLogon.AllowEndTime = DateTime.Now.AddYears(100);
            tenantLogon.MultiUserLogin = tenantLogon.CheckIPAddress = false;
            tenantLogon.LogOnCount = 0;
            result.Success = await iService.InsertAsync(tenant, tenantLogon);
            if (result.Success)
            {
                yuebonCacheHelper.Remove("ValidateCode");
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
        /// 租户登录，必须要有验证码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="vcode">验证码</param>
        /// <param name="vkey">验证码key</param>
        /// <param name="appId">AppId</param>
        /// <param name="systemCode">系统编码</param>
        /// <returns>返回用户User对象</returns>
        [HttpGet("GetCheckUser")]
        [NoPermissionRequired]
        public async Task<IActionResult> GetCheckUser(string username, string password, string vcode, string vkey, string appId, string systemCode)
        {

            CommonResult result = new CommonResult();
            //RemoteIpParser remoteIpParser = new RemoteIpParser();
            //string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
            //YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            //var vCode = yuebonCacheHelper.Get("ValidateCode" + vkey);
            //string code = vCode != null ? vCode.ToString() : "11";
            //if (vcode.ToUpper() != code)
            //{
            //    result.ErrMsg = "验证码错误";
            //    return ToJsonContent(result);
            //}
            //Log logEntity = new Log();
            //bool blIp = _filterIPService.ValidateIP(strIp);
            //if (blIp)
            //{
            //    result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
            //}
            //else
            //{

            //    if (string.IsNullOrEmpty(username))
            //    {
            //        result.ErrMsg = "用户名不能为空！";
            //    }
            //    else if (string.IsNullOrEmpty(password))
            //    {
            //        result.ErrMsg = "密码不能为空！";
            //    }
            //    if (string.IsNullOrEmpty(systemCode))
            //    {

            //        result.ErrMsg = ErrCode.err40006;
            //    }
            //    else
            //    {
            //        string strHost = Request.Host.ToString();
            //        APP app = _appService.GetAPP(appId);
            //        if (app == null)
            //        {
            //            result.ErrCode = "40001";
            //            result.ErrMsg = ErrCode.err40001;
            //        }
            //        else
            //        {
            //            if (!app.RequestUrl.Contains(strHost, StringComparison.Ordinal) && !strHost.Contains("localhost", StringComparison.Ordinal))
            //            {
            //                result.ErrCode = "40002";
            //                result.ErrMsg = ErrCode.err40002 + "，你当前请求主机：" + strHost;
            //            }
            //            else
            //            {
            //                SystemType systemType = _systemTypeService.GetByCode(systemCode);
            //                if (systemType == null)
            //                {
            //                    result.ErrMsg = ErrCode.err40006;
            //                }
            //                else
            //                {
            //                    Tuple<Tenant> userLogin = await this.iService.Validate(username, password);
            //                    if (userLogin != null)
            //                    {
            //                        string ipAddressName = IpAddressUtil.GetCityByIp(strIp);
            //                        if (userLogin.Item1 != null)
            //                        {
            //                            result.Success = true;
            //                            Tenant tenant = userLogin.Item1;
            //                            JwtOption jwtModel = App.GetService<JwtOption>();
            //                            TokenProvider tokenProvider = new TokenProvider(jwtModel);
            //                            TokenResult tokenResult = tokenProvider.LoginToken(tenant, appId);
            //                            YuebonCurrentUser currentSession = new YuebonCurrentUser
            //                            {
            //                                UserId = tenant.Id,
            //                                Name = tenant.TenantName,
            //                                AccessToken = tokenResult.AccessToken,
            //                                AppKey = appId,
            //                                CreateTime = DateTime.Now,
            //                                ActiveSystemId = systemType.Id,
            //                                CurrentLoginIP = strIp,
            //                                IPAddressName = ipAddressName
            //                            };
            //                            TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
            //                            yuebonCacheHelper.Add("login_tenant_user_" + tenant.Id, currentSession, expiresSliding, true);
            //                            CurrentUser = currentSession;
            //                            result.ResData = currentSession;
            //                            result.ErrCode = ErrCode.successCode;
            //                            result.Success = true;

            //                            logEntity.Account = tenant.TenantName;
            //                            logEntity.NickName = tenant.CompanyName;
            //                            logEntity.Date = logEntity.CreatorTime = DateTime.Now;
            //                            logEntity.IPAddress = CurrentUser.CurrentLoginIP;
            //                            logEntity.IPAddressName = CurrentUser.IPAddressName;
            //                            logEntity.Result = true;
            //                            logEntity.ModuleName = "登录";
            //                            logEntity.Description = "登录成功";
            //                            logEntity.Type = "Login";
            //                            _logService.Insert(logEntity);
            //                        }
            //                        else
            //                        {
            //                            result.ErrCode = ErrCode.failCode;
            //                            result.ErrMsg = userLogin.Item2;
            //                            logEntity.Account = username;
            //                            logEntity.Date = logEntity.CreatorTime = DateTime.Now;
            //                            logEntity.IPAddress = strIp;
            //                            logEntity.IPAddressName = ipAddressName;
            //                            logEntity.Result = false;
            //                            logEntity.ModuleName = "登录";
            //                            logEntity.Type = "Login";
            //                            logEntity.Description = "登录失败，" + userLogin.Item2;
            //                            _logService.Insert(logEntity);
            //                        }
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}
            //yuebonCacheHelper.Remove("LoginValidateCode");
            return ToJsonContent(result, true);
        }
    }
}