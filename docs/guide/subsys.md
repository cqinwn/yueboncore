# 多系统切换

目前支持多个子系统切换，无需二次登陆。

## 应用场景

1、每个子系统独立部署，有自己独立访问域名(地址)

2、基于本框架实现

## 当前访问系统处理

1、前端页面

子系统切换在Navbar.vue页面中，代码如下：
``` vue
<el-dropdown class="el-dropdown-link right-menu-item" trigger="click" @command="handlerSysType">
    <div class="avatar-wrapper">
        您处在：{{ activeSystemName }}(切换)
        <i class="el-icon-arrow-down el-icon--right" />
    </div>
    <el-dropdown-menu slot="dropdown">
        <a v-for="item in subSystem" :key="item.Id" href="#">
        <el-dropdown-item :command="item.EnCode">{{ item.FullName }}</el-dropdown-item>
        </a>
    </el-dropdown-menu>
</el-dropdown>
```

系统切换调用方法handlerSysType，如下：
``` js
handlerSysType (command) {
    var data = {
    systype: command
    }
    yuebonConnecSys(data).then(res => {
    if (res.Success) {
        window.location.href = res.ResData
    }
    })
}
```

2、后端接口处理

系统切换时会调用`SystemType/YuebonConnecSys`接口方法获取切换到子系统的访问地址，访问地址会带有`openmf`凭证，该方法主要实现当前登录用户缓存,缓存键为`openmf`值，为子系统获取用户信息提供键值。代码实现如下：

``` cs
/// <summary>
/// 系统切换时获取凭据
/// 适用于不同子系统分别独立部署站点场景
/// </summary>
/// <param name="systype">子系统编码</param>
/// <returns></returns>
[HttpGet("YuebonConnecSys")]
[YuebonAuthorize("")]
public async Task<IActionResult> YuebonConnecSys(string systype)
{
    CommonResult result = new CommonResult();
    try
    {
        if (!string.IsNullOrEmpty(systype))
        {
            SystemType systemType = iService.GetByCode(systype);
            string openmf = MD5Util.GetMD5_32(DEncrypt.Encrypt(CurrentUser.UserId + systemType.Id, GuidUtils.NewGuidFormatN())).ToLower();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            TimeSpan expiresSliding = DateTime.Now.AddSeconds(10) - DateTime.Now;
            yuebonCacheHelper.Add("openmf" + openmf, CurrentUser.UserId,expiresSliding, false);
            result.ErrCode = ErrCode.successCode;
            result.ResData = systemType.Url + "?openmf=" + openmf;
        }
        else
        {
            result.ErrCode = ErrCode.failCode;
            result.ErrMsg = "切换子系统参数错误";
        }
    }
    catch (Exception ex)
    {
        Log4NetHelper.Error("切换子系统异常", ex);
        result.ErrMsg = ErrCode.err40110;
        result.ErrCode = "40110";
    }
    return ToJsonContent(result);
}
```

## 切换后的系统

1、前端处理

在子系统默认访问的第一个页面做子系统切换处理。主要是根据`openmf`、当前系统调用接口的应用Id、当前系统编码来获取用户访问子系统的权限，参考前端`dashboard/index.vue`页面中代码，如下：

``` js
export default {
  name: 'Dashboard',
  components: { countto },
  data () {
    return {
      SysSetting: [],
      syskey: ''
    }
  },
  created () {
    this.syskey = getUrlKey('openmf')
    if (this.syskey !== '' && this.syskey !== null && this.syskey !== 'null' && this.syskey !== undefined) {
      this.loadsysType()
    }
    this.InitDictItem()
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem () {
      getSysInfo().then(res => {
        this.SysSetting = res.ResData
      })
    },
    /**
    *子系统登录，获取子系统相关信息
    */
    loadsysType () {
      var data = {
        openmf: this.syskey,
        appId: defaultSettings.appId,//应用Id
        systemCode: defaultSettings.activeSystemCode//系统编码
      }
      this.loading = true
      this.$store
        .dispatch('user/sysConnetLogin', data)
        .then(res => {
          window.location.href = res.ResData.ActiveSystemUrl
          this.loading = false
        })
        .catch(res => {
          this.loading = false
        })
    }
  }
}
```

2、后端处理

子系统的后台处理实际是用户登录一样，根据`openmf`来获取用户实现与用户登录一样的功能，即获取用户可以访问的菜单、功能权限等。

``` cs
/// <summary>
/// 子系统切换登录
/// </summary>
/// <param name="openmf">凭据</param>
/// <param name="appId">应用Id</param>
/// <param name="systemCode">子系统编码</param>
/// <returns></returns>
[HttpGet("SysConnect")]
[AllowAnonymous]
[NoPermissionRequired]
public async Task<IActionResult> SysConnect(string openmf, string appId, string systemCode)
{
    CommonResult result = new CommonResult();
    RemoteIpParser remoteIpParser = new RemoteIpParser();
    string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
    if (string.IsNullOrEmpty(openmf))
    {
        result.ErrMsg = "切换参数错误！";
    }

    bool blIp = _filterIPService.ValidateIP(strIp);
    if (blIp)
    {
        result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
    }
    else
    {
        string ipAddressName = IpAddressUtil.GetCityByIp(strIp);
        if (string.IsNullOrEmpty(systemCode))
        {
            result.ErrMsg = ErrCode.err40009;
        }
        else
        {
            string strHost = Request.Host.ToString();
            APP app = _appService.GetAPP(appId);
            if (app == null)
            {
                result.ErrCode = "40001";
                result.ErrMsg = ErrCode.err40001;
            }
            else
            {
                if (!app.RequestUrl.Contains(strHost, StringComparison.Ordinal) && !strHost.Contains("localhost", StringComparison.Ordinal))
                {
                    result.ErrCode = "40002";
                    result.ErrMsg = ErrCode.err40002 + "，你当前请求主机：" + strHost;
                }
                else
                {
                    SystemType systemType = _systemTypeService.GetByCode(systemCode);
                    if (systemType == null)
                    {
                        result.ErrMsg = ErrCode.err40009;
                    }
                    else
                    {
                        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                        object cacheOpenmf = yuebonCacheHelper.Get("openmf" + openmf);
                        yuebonCacheHelper.Remove("openmf" + openmf);
                        if (cacheOpenmf == null)
                        {
                            result.ErrCode = "40007";
                            result.ErrMsg = ErrCode.err40007;
                        }
                        else
                        {
                            User user = _userService.Get(cacheOpenmf.ToString());
                            if (user != null)
                            {
                                result.Success = true;
                                JwtOption jwtModel = IoCContainer.Resolve<JwtOption>();
                                TokenProvider tokenProvider = new TokenProvider(jwtModel);
                                TokenResult tokenResult = tokenProvider.LoginToken(user, appId);
                                YuebonCurrentUser currentSession = new YuebonCurrentUser
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
                                    Role = _roleService.GetRoleEnCode(user.RoleId),
                                    MobilePhone = user.MobilePhone,
                                    OrganizeId = user.OrganizeId,
                                    DeptId = user.DepartmentId,
                                    CurrentLoginIP = strIp,
                                    IPAddressName = ipAddressName,
                                    TenantId = ""
                                };
                                currentSession.ActiveSystem = systemType.FullName;
                                currentSession.ActiveSystemUrl = systemType.Url;
                                List<MenuOutputDto> listFunction = new List<MenuOutputDto>();
                                MenuApp menuApp = new MenuApp();
                                if (Permission.IsAdmin(currentSession))
                                {
                                    currentSession.SubSystemList = _systemTypeService.GetAllByIsNotDeleteAndEnabledMark().MapTo<SystemTypeOutputDto>();
                                    //取得用户可使用的授权功能信息，并存储在缓存中
                                    listFunction = menuApp.GetFunctionsBySystem(systemType.Id);
                                }
                                else
                                {
                                    currentSession.SubSystemList = _systemTypeService.GetSubSystemList(user.RoleId);
                                    //取得用户可使用的授权功能信息，并存储在缓存中
                                    listFunction = menuApp.GetFunctionsByUser(user.Id, systemType.Id);
                                }

                                currentSession.MenusRouter = menuApp.GetVueRouter(user.RoleId, systemCode);
                                TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
                                yuebonCacheHelper.Add("User_Function_" + user.Id, listFunction, expiresSliding, true);
                                currentSession.Modules = listFunction;
                                yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
                                //该用户的数据权限
                                List<String> roleDateList = _roleDataService.GetListDeptByRole(user.RoleId);
                                yuebonCacheHelper.Add("User_RoleData_" + user.Id, roleDateList, expiresSliding, true);

                                CurrentUser = currentSession;
                                result.ResData = currentSession;
                                result.ErrCode = ErrCode.successCode;
                                result.Success = true;
                            }
                            else
                            {
                                result.ErrCode = ErrCode.failCode;

                            }
                        }
                    }
                }
            }
        }
    }
    return ToJsonContent(result);
}
```

如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈