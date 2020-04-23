using System;
using System.Data.Common;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Repositories;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using System.Data;
using Yuebon.Security.Dtos;
using System.Collections.Generic;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using System.Threading.Tasks;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : BaseService<User, UserOutputDto, string>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserLogOnRepository _userSigninRepository;
        private readonly ILogService _logService;
        private readonly IRoleService _roleService;
        public UserService(IUserRepository repository, IUserLogOnRepository userLogOnRepository, ILogService logService, IRoleService roleService) : base(repository)
        {
            _userRepository = repository;
            _userSigninRepository = userLogOnRepository;
            _logService = logService;
            _roleService = roleService;
            _userRepository.OnOperationLog += _logService.OnOperationLog;
        }



        /// <summary>
        /// 用户登陆验证。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（第一次md5加密后）</param>
        /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
        public Tuple<User, string> Validate(string userName, string password)
        {
            var userEntity = _userRepository.GetByUserName(userName);

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
                return new Tuple<User, string>(userEntity, "");
            }
        }
        /// <summary>
        /// 根据用户账号查询用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }
        /// <summary>
        /// 根据用户手机号码查询用户信息
        /// </summary>
        /// <param name="mobilephone">手机号码</param>
        /// <returns></returns>
        public User GetUserByMobilePhone(string mobilephone)
        {
            return _userRepository.GetUserByMobilePhone(mobilephone);
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public bool Insert(User entity, UserLogOn userLogOnEntity, IDbTransaction trans = null)
        {
            return _userRepository.Insert(entity, userLogOnEntity, trans);
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public async Task<bool> InsertAsync(User entity, UserLogOn userLogOnEntity, IDbTransaction trans = null)
        {
            return await _userRepository.InsertAsync(entity, userLogOnEntity, trans);
        }
        /// <summary>
        /// 注册用户,第三方平台
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public bool Insert(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds, IDbTransaction trans = null)
        {
            return _userRepository.Insert(entity, userLogOnEntity, userOpenIds, trans);
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
        public UserOpenIds GetUserOpenIdByuserId(string openIdType, string userId)
        {
            return _userRepository.GetUserOpenIdByuserId(openIdType, userId);
        }
        /// <summary>
        /// 更新用户信息,第三方平台
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="trans"></param>
        public bool UpdateUserByOpenId(User entity, UserLogOn userLogOnEntity, UserOpenIds userOpenIds, IDbTransaction trans = null)
        {
            return _userRepository.UpdateUserByOpenId(entity, userLogOnEntity, userOpenIds, trans);
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
        /// 根据用户ID得到名片信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        //public UserNameCardOutPutDto GetUserNameCardInfo(string userid)
        //{
        //    return _userRepository.GetUserNameCardInfo(userid);
        //}

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
        //public bool SaveNameCard(string userid, string headicon, string nickName, string name, string company, string position,
        //    string weburl, string mobile, string email, string wx, string wximg,
        //    string industry, string area, string address, int openflag)
        //{
        //    return _userRepository.SaveNameCard(userid, headicon, nickName, name, company, position, weburl,
        //        mobile, email, wx, wximg, industry, area, address, openflag);
        //}


        /// <summary>
        /// 分页得到所有用户用于关注
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<UserAllListFocusOutPutDto> GetUserAllListFocusByPage(string currentpage,
            string pagesize, string userid)
        {
            return _userRepository.GetUserAllListFocusByPage(currentpage, pagesize, userid);
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

            user.Id = user.CreatorUserId = GuidUtils.CreateNo();
            user.Account = "Wx" + GuidUtils.CreateNo();
            user.CreatorTime = userLogOnEntity.FirstVisitTime = DateTime.Now;
            user.IsAdministrator = false;
            user.EnabledMark = true;
            user.Description = "第三方注册";
            user.IsMember = true;
            user.UnionId = userInPut.UnionId;
            user.ReferralUserId = userInPut.ReferralUserId;
            if (userInPut.NickName == "游客")
            {
                user.RoleId = _roleService.GetRole("guest").Id;
            }
            else
            {
                user.RoleId = _roleService.GetRole("usermember").Id;
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
            return _userRepository.Update(user, user.Id);
        }

    }
}