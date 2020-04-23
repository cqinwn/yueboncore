using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService:IService<User, UserOutputDto, string>
    {
        /// <summary>
        /// 用户登陆验证。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（第一次md5加密后）</param>
        /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
        Tuple<User,string> Validate(string userName, string password);

        /// <summary>
        /// 根据用户账号查询用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetByUserName(string userName);
        /// <summary>
        /// 根据用户手机号码查询用户信息
        /// </summary>
        /// <param name="mobilePhone">手机号码</param>
        /// <returns></returns>
        User GetUserByMobilePhone(string mobilePhone);


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
        /// 根据用户ID得到名片信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        //UserNameCardOutPutDto GetUserNameCardInfo(string userid);

        /// <summary>
        /// 保存名片
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="headicon"></param>
        /// <param name="nickName"></param>
        /// <param name="name"></param>
        /// <param name="company"></param>
        /// <param name="position"></param>
        /// <param name="weburl"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="wx"></param>
        /// <param name="wximg"></param>
        /// <param name="industry"></param>
        /// <param name="area"></param>
        /// <param name="address"></param>
        /// <param name="openflag"></param>
        /// <returns></returns>
        //bool SaveNameCard(string userid, string headicon, string nickName, string name, string company, string position,
        //    string weburl, string mobile, string email, string wx, string wximg,
        //    string industry, string area, string address, int openflag);


        /// <summary>
        /// 所有用户信息用于关注
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        IEnumerable<UserAllListFocusOutPutDto> GetUserAllListFocusByPage(string currentpage,
            string pagesize, string userid);


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
    }
}
