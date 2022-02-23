using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Yuebon.Commons.Enums;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService:IService<User, UserOutputDto>
    {
        /// <summary>
        /// 用户登陆验证。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（第一次md5加密后）</param>
        /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
        Task<Tuple<User,string>> Validate(string userName, string password);

        /// <summary>
        /// 用户登陆验证。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（第一次md5加密后）</param>
        /// <param name="userType">用户类型</param>
        /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
        Task<Tuple<User, string>> Validate(string userName, string password, UserType userType);

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
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        bool Insert(User entity, UserLogOn userLogOnEntity, IDbTransaction trans = null);
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        Task<bool> InsertAsync(User entity, UserLogOn userLogOnEntity, IDbTransaction trans = null);
        /// <summary>
        /// 注册用户,第三方平台
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="userOpenIds"></param>
        /// <param name="trans"></param>
        bool Insert(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds,IDbTransaction trans = null);
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
        UserOpenIds GetUserOpenIdByuserId(string openIdType, string userId);
        /// <summary>
        /// 更新用户信息,第三方平台
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        bool UpdateUserByOpenId(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds, IDbTransaction trans = null);

        


        /// <summary>
        /// 微信注册普通会员用户
        /// </summary>
        /// <param name="userInPut">第三方类型</param>
        /// <returns></returns>
       bool CreateUserByWxOpenId(UserInputDto userInPut);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInPut"></param>
        /// <returns></returns>
        bool UpdateUserByOpenId(UserInputDto userInPut);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        Task<PageResult<UserOutputDto>> FindWithPagerSearchAsync(SearchUserModel search);
    }
}
