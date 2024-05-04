using NPOI.SS.Formula.Functions;
using SqlSugar;
using StackExchange.Redis;
using System.Linq.Expressions;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Helpers;
using Yuebon.Core.Repositories;
using Yuebon.Core.UnitOfWork;

namespace Yuebon.Security.Services;

/// <summary>
/// 
/// </summary>
public class UserService : BaseService<User, UserOutputDto>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserLogOnRepository _userSigninRepository;
    private readonly IRoleService _roleService;
    private IOrganizeService _organizeService;
    private IUserRoleService _userRoleService;

    public UserService(IUserRepository userRepository, IUserLogOnRepository userLogOnRepository, IRoleService roleService, IOrganizeService organizeService, IUserRoleService userRoleService)
    {
        repository = userRepository;
        _userRepository = userRepository;
        _userSigninRepository = userLogOnRepository;
        _roleService = roleService;
        _organizeService = organizeService;
        _userRoleService = userRoleService;
    }



    /// <summary>
    /// 用户登陆验证。
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码（第一次md5加密后）</param>
    /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
    public async Task<Tuple<User,string>> Validate(string userName, string password)
    {
        var userEntity = await _userRepository.GetUserByLogin(userName);

        if (userEntity == null)
        {
            return new Tuple<User, string>(null, "系统不存在该用户，请重新确认。");
        }

        if (!userEntity.EnabledMark)
        {
            return new Tuple<User, string>(null, "该用户已被禁用，请联系管理员。");
        }

        var userSinginEntity = _userSigninRepository.GetByUserId(userEntity.Id);

        string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userSinginEntity.UserSecretkey).ToLower()).ToLower();

        if (inputPassword != userSinginEntity.UserPassword)
        {
            return new Tuple<User, string>(null, "密码错误，请重新输入。");
        }
        else
        {
            UserLogOn userLogOn = _userSigninRepository.GetWhere("UserId='"+ userEntity.Id+ "'");
            if (userLogOn.AllowEndTime < DateTime.Now)
            {
                return new Tuple<User, string>(null, "您的账号已过期，请联系系统管理员！");
            }
            if (userLogOn.LockEndDate >DateTime.Now)
            {
                string dateStr=userLogOn.LockEndDate.ToEasyStringDQ();
                return new Tuple<User, string>(null, "当前被锁定，请"+ dateStr + "登录");
            }
            if (userLogOn.FirstVisitTime == null)
            {
                userLogOn.FirstVisitTime =userLogOn.PreviousVisitTime= DateTime.Now;
            }
            else
            {
                userLogOn.PreviousVisitTime = DateTime.Now;
            }
            userLogOn.LogOnCount++;
            userLogOn.LastVisitTime = DateTime.Now;
            userLogOn.UserOnLine = true;
             _userSigninRepository.Update(userLogOn);
            return new Tuple<User, string>(userEntity, "");
        }
    }

    /// <summary>
    /// 用户登陆验证。
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">密码（第一次md5加密后）</param>
    /// <param name="userType">用户类型</param>
    /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
    public async Task<Tuple<User, string>> Validate(string userName, string password, UserTypeEnum userType)
    {
        var userEntity = await _userRepository.GetUserByLogin(userName);

        if (userEntity == null)
        {
            return new Tuple<User, string>(null, "系统不存在该用户，请重新确认。");
        }

        if (!userEntity.EnabledMark)
        {
            return new Tuple<User, string>(null, "该用户已被禁用，请联系管理员。");
        }

        var userSinginEntity = _userSigninRepository.GetByUserId(userEntity.Id);

        string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userSinginEntity.UserSecretkey).ToLower()).ToLower();

        if (inputPassword != userSinginEntity.UserPassword)
        {
            return new Tuple<User, string>(null, "密码错误，请重新输入。");
        }
        else
        {
            UserLogOn userLogOn = _userSigninRepository.GetWhere("UserId='" + userEntity.Id + "'");
            if (userLogOn.AllowEndTime < DateTime.Now)
            {
                return new Tuple<User, string>(null, "您的账号已过期，请联系系统管理员！");
            }
            if (userLogOn.LockEndDate > DateTime.Now)
            {
                string dateStr = userLogOn.LockEndDate.ToEasyStringDQ();
                return new Tuple<User, string>(null, "当前被锁定，请" + dateStr + "登录");
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
            userLogOn.UserOnLine = true;
            await _userSigninRepository.UpdateAsync(userLogOn);
            return new Tuple<User, string>(userEntity, "");
        }
    }

    /// <summary>
    /// 根据用户账号查询用户信息
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public async Task<User> GetByUserName(string userName)
    {
        return await _userRepository.GetByUserName(userName);
    }
    /// <summary>
    /// 根据用户手机号码查询用户信息
    /// </summary>
    /// <param name="mobilephone">手机号码</param>
    /// <returns></returns>
    public async Task<User> GetUserByMobilePhone(string mobilephone)
    {
        return await _userRepository.GetUserByMobilePhone(mobilephone);
    }
    /// <summary>
    /// 根据Email、Account、手机号查询用户信息
    /// </summary>
    /// <param name="account">登录账号</param>
    /// <returns></returns>
    public async Task<User> GetUserByLogin(string account)
    {
        return await _userRepository.GetUserByLogin(account);
    }
    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    public bool Insert(User entity, UserLogOn userLogOnEntity)
    {
        return _userRepository.Insert(entity, userLogOnEntity);
    }

    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    public  async Task<bool> InsertAsync(User entity, UserLogOn userLogOnEntity)
    {
        List<UserRole> userRoles = new List<UserRole>();
        foreach (string item in entity.RoleId.Split(","))
        {
            UserRole userRole = new UserRole();
            userRole.UserId = entity.Id;
            userRole.RoleId = item.ToLong();
            userRoles.Add(userRole);
        }
        await _userRoleService.InsertAsync(userRoles);
        return await _userRepository.InsertAsync(entity, userLogOnEntity);
    }

    public override async Task<bool> UpdateAsync(User entity)
    {
        List<UserRole> userRoles = new List<UserRole>();
        foreach (string item in entity.RoleId.Split(","))
        {
            UserRole userRole = new UserRole();
            userRole.UserId = entity.Id;
            userRole.RoleId = item.ToLong();
            userRoles.Add(userRole);
        }
        await _userRoleService.InsertAsync(userRoles);
        return await _userRepository.UpdateAsync(entity);
    }
    /// <summary>
    /// 注册用户,第三方平台
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    public bool Insert(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds)
    {
        return _userRepository.Insert(entity, userLogOnEntity, userOpenIds);
    }

    /// <summary>
    /// 根据第三方OpenId查询用户信息
    /// </summary>
    /// <param name="openIdType">第三方类型</param>
    /// <param name="openId">OpenId值</param>
    /// <returns></returns>
    public User GetUserByOpenId(string openIdType, string openId)
    {
        return _userRepository.GetUserByOpenId(openIdType, openId);
    }
    /// <summary>
    /// 根据userId查询用户信息
    /// </summary>
    /// <param name="openIdType">第三方类型</param>
    /// <param name="userId">userId</param>
    /// <returns></returns>
    public UserOpenIds GetUserOpenIdByuserId(string openIdType, long userId)
    {
        return _userRepository.GetUserOpenIdByuserId(openIdType, userId);
    }
    /// <summary>
    /// 更新用户信息,第三方平台
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    /// <param name="userOpenIds"></param>
    public bool UpdateUserByOpenId(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds)
    {
        return _userRepository.UpdateUserByOpenId(entity, userLogOnEntity, userOpenIds);
    }

    /// <summary>
    /// 根据微信UnionId查询用户信息
    /// </summary>
    /// <param name="unionId">UnionId值</param>
    /// <returns></returns>
    public User GetUserByUnionId(string unionId)
    {
        return _userRepository.GetUserByUnionId(unionId);
    }


    /// <summary>
    /// 微信注册普通会员用户
    /// </summary>
    /// <param name="userInPut">第三方类型</param>
    /// <returns></returns>
    public bool CreateUserByWxOpenId(UserInputDto userInPut)
    {

        User user = userInPut.MapTo<User>();
        UserLogOn userLogOnEntity = new UserLogOn();
        UserOpenIds userOpenIds = new UserOpenIds();

        user.Id =IdGeneratorHelper.IdSnowflake();
        user.CreatorUserId = user.Id;
        user.Account = "Wx" + GuidUtils.CreateNo();
        user.CreatorTime = userLogOnEntity.FirstVisitTime = DateTime.Now;
        user.UserType = UserTypeEnum.Member;
        user.EnabledMark = true;
        user.Description = "第三方注册";
        user.UnionId = userInPut.UnionId;
        user.ReferralUserId = userInPut.ReferralUserId;
        if (userInPut.NickName == "游客")
        {
            user.RoleId = _roleService.GetRole("guest").Id.ToString();
        }
        else
        {
            user.RoleId = _roleService.GetRole("usermember").Id.ToString();
        }

        userLogOnEntity.UserId = user.Id;

        userLogOnEntity.UserPassword = GuidUtils.NewGuidFormatN() + new Random().Next(100000, 999999).ToString();
        userLogOnEntity.Language = userInPut.language;

        userOpenIds.OpenId = userInPut.OpenId;
        userOpenIds.OpenIdType = userInPut.OpenIdType;
        userOpenIds.UserId = user.Id;
        return _userRepository.Insert(user, userLogOnEntity, userOpenIds);
    }
    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="userInPut"></param>
    /// <returns></returns>
    public bool UpdateUserByOpenId(UserInputDto userInPut)
    {
        User user = GetUserByOpenId(userInPut.OpenIdType, userInPut.OpenId);
        user.HeadIcon = userInPut.HeadIcon;
        user.Country = userInPut.Country;
        user.Province = userInPut.Province;
        user.City = userInPut.City;
        user.Gender = userInPut.Gender;
        user.NickName = userInPut.NickName;
        user.UnionId = userInPut.UnionId;
        return _userRepository.Update(user);
    }


    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public  async Task<PageResult<UserOutputDto>> FindWithPagerSearchAsync(SearchUserModel search)
    {
        bool order = search.Order == "asc" ? false : true;       
        List<long> orgIds=new List<long>();
        if (search.CreateOrgId != 0)
        {
           orgIds =await _organizeService.GetChildIdListWithSelfById((long)search.CreateOrgId);
        }
        var exp = Expressionable.Create<User>();
        exp.AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.Account.Contains(search.Keywords)|| it.MobilePhone.Contains(search.Keywords)||it.NickName.Contains(search.Keywords)||it.RealName.Contains(search.Keywords));
        exp.AndIF(!string.IsNullOrEmpty(search.CreatorTime1), it => it.CreatorTime >= search.CreatorTime1.AsDateTime());
        exp.AndIF(!string.IsNullOrEmpty(search.CreatorTime2), it => it.CreatorTime <= search.CreatorTime2.AsDateTime());
        exp.AndIF(orgIds.Count!= 0, it =>orgIds.Contains((long)it.CreateOrgId));
        Expression<Func<User, bool>> expressionWhere = exp.ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };

        List<User> list =  await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        List<UserOutputDto> resultList = list.MapTo<UserOutputDto>();
        List<UserOutputDto> listResult = new List<UserOutputDto>();
        foreach (UserOutputDto item in resultList)
        {
            if (item.CreateOrgId >0)
            {
                item.OrganizeName = _organizeService.GetById(item.CreateOrgId).FullName;
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
        return pageResult;
    }

}