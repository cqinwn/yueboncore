using SqlSugar;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.SeedData;

namespace Yuebon.Security.Services;

/// <summary>
/// 租户服务接口实现
/// </summary>
public class TenantService: BaseService<Tenant,TenantOutputDto>, ITenantService
{
    private ITenantRepository trepository;
    private readonly ITenantLogonRepository _repositoryLogon;
    private readonly IUserRepository _userRepository;
    private readonly IUserLogOnRepository _userLogon;
    private readonly IRoleService _roleService;
    private readonly ISystemTypeRepository _systemTypeRepository;
    private readonly IMenuService _menuService;
    private readonly IOrganizeRepository _organizeRepository;

    public TenantService(ITenantRepository _repository, ITenantLogonRepository repositoryLogon, IUserRepository userRepository, 
        IUserLogOnRepository userLogon, IRoleService roleService, ISystemTypeRepository systemTypeRepository, IMenuService menuService, IOrganizeRepository organizeRepository)
    {
        trepository = _repository;
        repository = _repository;
        _repositoryLogon = repositoryLogon;
        _userRepository = userRepository;
        _userLogon = userLogon;
        _roleService = roleService;
        _systemTypeRepository = systemTypeRepository;
        _menuService = menuService;
        _organizeRepository = organizeRepository;
    }

    /// <summary>
    /// 根据租户账号查询租户信息
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public async Task<Tenant> GetByUserName(string userName)
    {
        return await trepository.GetByUserName(userName);
    }


    /// <summary>
    /// 注册租户
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="tenantLogOnEntity"></param>
    public async Task<bool> InsertAsync(Tenant entity, TenantLogon tenantLogOnEntity)
    {
        return await trepository.InsertAsync(entity, tenantLogOnEntity);
    }

    /// <summary>
    /// 初始化租户数据
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> InitTenantDataAsync(Tenant entity)
    {
        bool res = false;
        if (entity.Schema == Commons.Enums.TenantSchemaEnum.AloneDatabase)
        {
            ConnectionConfig config = new ConnectionConfig();
            List<DbConnections> listdatabase = entity.DataSource.ToList<DbConnections>();
            listdatabase.ForEach(c =>
            {
                config.ConfigId = c.ConnId;
                config.DbType = (SqlSugar.DbType)c.MasterDB.DatabaseType;
                config.ConnectionString = c.MasterDB.ConnectionString;
            });

            await DBSeedService.SeedTenantAsync(new List<string> { "Yuebon.Security.Models.dll", "Yuebon.Security.SeedData.dll" }, config);
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            IEnumerable<Tenant> templist = trepository.GetAllByIsEnabledMark();
            yuebonCacheHelper.Add("cacheTenants", templist);
        }
        else if(entity.Schema==Commons.Enums.TenantSchemaEnum.ShareSchema)
        {

        }
        return res; 
    }


    /// <summary>
    /// 注册租户
    /// </summary>
    /// <param name="registerTenant"></param>
    public async Task<bool> RegisterAsync(RegisterTenant registerTenant)
    {
        Tenant tenant = new Tenant()
        {
            Id = IdGeneratorHelper.IdSnowflake(),
            TenantName = registerTenant.Account.ToLower(),
            TenantType = TenantTypeEnum.COMMON,
            Schema = TenantSchemaEnum.ShareSchema,
            HostDomain = registerTenant.Account.ToLower() + "." + Appsettings.app(new string[] { "AppSetting", "TenantHostDomain" }).ObjToString(),
            EnabledMark = true,
            DeleteMark = false
        };
        TenantLogon tenantLogon = new TenantLogon();
        tenantLogon.TenantPassword = "12345678";
        tenantLogon.AllowStartTime = tenantLogon.LockStartDate = tenantLogon.LockEndDate = tenantLogon.ChangePasswordDate = DateTime.Now;
        tenantLogon.AllowEndTime = DateTime.Now.AddYears(100);
        tenantLogon.MultiUserLogin = tenantLogon.CheckIPAddress = false;
        tenantLogon.LogOnCount = 0;
        tenantLogon.TenantId = tenant.Id;
        await InsertAsync(tenant, tenantLogon);      

        User usereInfo = new User();
        usereInfo.Id = IdGeneratorHelper.IdSnowflake();
        usereInfo.Account = registerTenant.Account;
        usereInfo.RealName = registerTenant.Account;
        usereInfo.Email = registerTenant.Email;
        usereInfo.CreatorTime = DateTime.Now;
        usereInfo.CreatorUserId = usereInfo.Id;
        usereInfo.OrganizeId = 0;
        usereInfo.EnabledMark = true;
        usereInfo.IsAdministrator = true;
        usereInfo.IsMember = false;
        usereInfo.DeleteMark = false;
        usereInfo.SortCode = 99;
        usereInfo.TenantId = tenant.Id;

        UserLogOn userLogOn = new UserLogOn();
        userLogOn.UserPassword = registerTenant.Password;
        userLogOn.AllowStartTime = userLogOn.LockStartDate = userLogOn.LockEndDate = userLogOn.ChangePasswordDate = DateTime.Now;
        userLogOn.AllowEndTime = DateTime.Now.AddMonths(1);
        userLogOn.MultiUserLogin = userLogOn.CheckIPAddress = false;
        userLogOn.LogOnCount = 0;

        Organize organize= new Organize
        {
            Id = IdGeneratorHelper.IdSnowflake(),
            ParentId = 0,
            Layers = 1,
            EnCode = "Company",
            FullName = usereInfo.Account +"的公司",
            ShortName = usereInfo.Account + "的公司",
            CategoryId = "Company",
            ManagerId = "",
            TelePhone = "",
            MobilePhone = "",
            WeChat = "",
            Fax = "",
            Email =usereInfo.Email,
            AreaId = "",
            Address = "",
            AllowEdit = false,
            AllowDelete = false,
            SortCode = 1,
            DeleteMark = false,
            EnabledMark = true,
            Description = "",
            CreatorTime = DateTime.Now,
            CreatorUserId = usereInfo.Id,
            LastModifyTime = null,
            LastModifyUserId = null,
            DeleteTime = null,
            DeleteUserId = null,
            TenantId = tenant.Id
        };
        usereInfo.OrganizeId = organize.Id;
        usereInfo.DepartmentId = organize.Id;
        Role role = new Role
        {
            Id = IdGeneratorHelper.IdSnowflake(),
            Category = 1,
            EnCode = "administrators",
            FullName = "超级管理员",
            Type = "1",
            AllowEdit = false,
            AllowDelete = false,
            SortCode = 1,
            DeleteMark = false,
            EnabledMark = true,
            Description = "",
            CreatorTime = DateTime.Now,
            CreatorUserId = usereInfo.Id,
            LastModifyTime = null,
            LastModifyUserId = null,
            DeleteTime = null,
            DeleteUserId = null,
            OrganizeId = organize.Id,
            TenantId = tenant.Id
        };
        usereInfo.RoleId = role.Id.ToString();
        await _organizeRepository.InsertAsync(organize);
        await _userRepository.InsertAsync(usereInfo, userLogOn);
        await _roleService.InsertAsync(role);

        SystemType systemType = new SystemType
        {
            Id = IdGeneratorHelper.IdSnowflake(),
            EnCode = "openauth",
            FullName = "权限系统",
            Url = "http://localhost:9528",
            AllowEdit = null,
            AllowDelete = null,
            SortCode = 1,
            DeleteMark = false,
            EnabledMark = true,
            Description = "权限系统是基础系统，包含机构、岗位、角色、用户等功能",
            CreatorTime = DateTime.Now,
            CreatorUserId = usereInfo.Id,
            LastModifyTime = null,
            LastModifyUserId = null,
            DeleteTime = null,
            DeleteUserId = null,
            TenantId = tenant.Id
        };

        await _systemTypeRepository.InsertAsync(systemType);

        List<Menu> list = new MenuTenantSeedData().HasData().ToList();
        var topList = list.FindAll(x => x.ParentId == 0).ToList();
        List<Menu> inserList = new List<Menu>();
        long tempId = 0;
        foreach (Menu item in topList)
        {
            tempId=item.Id;
            Menu menu = item;
            menu.Id = IdGeneratorHelper.IdSnowflake();
            menu.CreatorTime = DateTime.Now;
            menu.CreatorUserId = usereInfo.Id;
            menu.SystemTypeId = systemType.Id;
            menu.TenantId = tenant.Id;
            inserList.Add(menu);
            List<Menu> submenus= InserMenuList(tempId, menu.Id, tenant.Id, usereInfo.Id, systemType.Id,list);
            foreach(Menu menu1 in submenus)
            {
                inserList.Add((Menu)menu1);
            }
        }
        await _menuService.InsertAsync(inserList);       
        return true;
    }
    private List<Menu> InserMenuList(long oldParentId,long newParentId,long newTenantId, long newUserId, long newSystemTypeId, List<Menu> menus)
    {
        List<Menu> inserList = new List<Menu>();
        var tempList = Menus(oldParentId, menus);
        long tempId = 0;
        foreach (Menu item in tempList)
        {
            tempId = item.Id;
            Menu menu=item;
            menu.Id = IdGeneratorHelper.IdSnowflake();
            menu.SystemTypeId = newSystemTypeId;
            menu.ParentId = newParentId;
            menu.TenantId = newTenantId;
            menu.CreatorTime = DateTime.Now;
            menu.CreatorUserId = newUserId;
            inserList.Add(menu);
            
            List<Menu> submenus = InserMenuList(tempId, menu.Id, newTenantId, newUserId, newSystemTypeId, menus);
            foreach (Menu menu1 in submenus)
            {
                inserList.Add((Menu)menu1);
            }
        }  
        return inserList;
    }
    private List<Menu> Menus(long parentId,List<Menu> menus)
    {
        var list = new List<Menu>();
        list= menus.FindAll(x => x.ParentId == parentId);
        return list;

    }
    /// <summary>
    /// 租户登陆验证。
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码（第一次md5加密后）</param>
    /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
    public async Task<Tuple<Tenant, string>> Validate(string userName, string password)
    {
        var userEntity = await trepository.GetByUserName(userName);

        if (userEntity == null)
        {
            return new Tuple<Tenant, string>(null, "系统不存在该用户，请重新确认。");
        }

        if (!userEntity.EnabledMark)
        {
            return new Tuple<Tenant, string>(null, "该用户已被禁用，请联系管理员。");
        }

        var userSinginEntity = _repositoryLogon.GetByTenantId(userEntity.Id);

        string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userSinginEntity.TenantSecretkey).ToLower()).ToLower();

        if (inputPassword != userSinginEntity.TenantPassword)
        {
            return new Tuple<Tenant, string>(null, "密码错误，请重新输入。");
        }
        else
        {
            TenantLogon userLogOn = _repositoryLogon.GetWhere("UserId='" + userEntity.Id + "'");
            if (userLogOn.AllowEndTime < DateTime.Now)
            {
                return new Tuple<Tenant, string>(null, "您的账号已过期，请联系系统管理员！");
            }
            if (userLogOn.LockEndDate > DateTime.Now)
            {
                string dateStr = userLogOn.LockEndDate.ToEasyStringDQ();
                return new Tuple<Tenant, string>(null, "当前被锁定，请" + dateStr + "登录");
            }
            if (userLogOn.FirstVisitTime == null)
            {
                userLogOn.FirstVisitTime = userLogOn.PreviousVisitTime = DateTime.Now;
            }
            else
            {
                userLogOn.PreviousVisitTime = DateTime.Now;
            }
            userLogOn.LogOnCount++;
            userLogOn.LastVisitTime = DateTime.Now;
            userLogOn.TenantOnLine = true;
            await _repositoryLogon.UpdateAsync(userLogOn);
            return new Tuple<Tenant, string>(userEntity, "");
        }
    }

    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public override async Task<PageResult<TenantOutputDto>> FindWithPagerAsync(SearchInputDto<Tenant> search)
    {
        bool order = search.Order == "asc" ? false : true;
        string where = GetDataPrivilege(false);
        if (!string.IsNullOrEmpty(search.Keywords))
        {
            where += " and (TenantName like '%" + search.Keywords + "%' or CompanyName like '%" + search.Keywords + "%')";
        };
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<Tenant> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
        PageResult<TenantOutputDto> pageResult = new PageResult<TenantOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<TenantOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}