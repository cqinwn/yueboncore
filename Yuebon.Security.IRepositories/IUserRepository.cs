namespace Yuebon.Security.IRepositories;

/// <summary>
/// 
/// </summary>
public interface IUserRepository:IRepository<User>
{
    /// <summary>
    /// 根据用户账号查询用户信息
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<User> GetByUserName(string userName);
    /// <summary>
    /// 根据用户手机号码查询用户信息
    /// </summary>
    /// <param name="mobilePhone">手机号码</param>
    /// <returns></returns>
    Task<User> GetUserByMobilePhone(string mobilePhone);
    /// <summary>
    /// 根据Email、Account、手机号查询用户信息
    /// </summary>
    /// <param name="account">登录账号</param>
    /// <returns></returns>
    Task<User> GetUserByLogin(string account);
    /// <summary>
    /// 根据Email查询用户信息
    /// </summary>
    /// <param name="email">email</param>
    /// <returns></returns>
   Task<User> GetUserByEmail(string email);
    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    bool Insert(User entity, UserLogOn userLogOnEntity);
    /// <summary>
    /// 注册用户
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    Task<bool> InsertAsync(User entity, UserLogOn userLogOnEntity);
    /// <summary>
    /// 注册用户,第三方平台
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    bool Insert(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds);
    /// <summary>
    /// 根据第三方OpenId查询用户信息
    /// </summary>
    /// <param name="openIdType">第三方类型</param>
    /// <param name="openId">OpenId值</param>
    /// <returns></returns>
    User GetUserByOpenId(string openIdType, string openId);

    /// <summary>
    /// 根据微信UnionId查询用户信息
    /// </summary>
    /// <param name="unionId">UnionId值</param>
    /// <returns></returns>
    User GetUserByUnionId(string unionId);
    /// <summary>
    /// 根据userId查询用户信息
    /// </summary>
    /// <param name="openIdType">第三方类型</param>
    /// <param name="userId">userId</param>
    /// <returns></returns>
    UserOpenIds GetUserOpenIdByuserId(string openIdType, long userId);
    /// <summary>
    /// 更新用户信息,第三方平台
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userLogOnEntity"></param>
    bool UpdateUserByOpenId(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds);


}