using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class UserApp
    {
        IUserService service = IoCContainer.Resolve<IUserService>();
        IUserLogOnService userLogOnService = IoCContainer.Resolve<IUserLogOnService>();
        IRoleService roleService = IoCContainer.Resolve<IRoleService>();
        /// <summary>
        /// 获取所有用户信息
        /// </summary>        
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return service.GetAll();
        }

        /// <summary>
        /// 根据用户账号查询用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetByUserName(string userName)
        {
            return service.GetByUserName(userName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateCredentials(string userName, string password)
        {
            //获取用户信息
            User userInfo = new User();
            userInfo = service.GetByUserName(userName);

            if (userInfo == null)
            {
                throw new Exception("用户不存在");
            }
            var userSinginEntity = userLogOnService.GetByUserId(userInfo.Id);
            string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userSinginEntity.UserSecretkey).ToLower()).ToLower();

            if (userSinginEntity.UserPassword != inputPassword)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 根据第三方OpenId查询用户信息
        /// </summary>
        /// <param name="openIdType">第三方类型</param>
        /// <param name="openId">OpenId值</param>
        /// <returns></returns>
        public UserOutPutDto GetUserOutDtoByOpenId(string openIdType, string openId)
        {
            return service.GetUserByOpenId(openIdType, openId).MapTo<UserOutPutDto>();
        }
        /// <summary>
        /// 根据第三方OpenId查询用户信息
        /// </summary>
        /// <param name="openIdType">第三方类型</param>
        /// <param name="openId">OpenId值</param>
        /// <returns></returns>
        public User GetUserByOpenId(string openIdType, string openId)
        {
            return service.GetUserByOpenId(openIdType, openId);
        }
        /// <summary>
        /// 微信注册普通会员用户
        /// </summary>
        /// <param name="userInPut">第三方类型</param>
        /// <returns></returns>
        public bool CreateUserByWxOpenId(UserInPutDto userInPut)
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
                user.RoleId = roleService.GetRole("guest").Id;
            }
            else
            {
                user.RoleId = roleService.GetRole("usermember").Id;
            }

            userLogOnEntity.UserId = user.Id;

            userLogOnEntity.UserPassword = GuidUtils.NewGuidFormatN() + new Random().Next(100000, 999999).ToString();
            userLogOnEntity.Language = userInPut.language;

            userOpenIds.OpenId = userInPut.OpenId;
            userOpenIds.OpenIdType = userInPut.OpenIdType;
            userOpenIds.UserId = user.Id;
            return service.Insert(user, userLogOnEntity, userOpenIds);
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInPut"></param>
        /// <returns></returns>
        public bool UpdateUserByOpenId(UserInPutDto userInPut)
        {
            User user = GetUserByOpenId(userInPut.OpenIdType, userInPut.OpenId);
            user.HeadIcon = userInPut.HeadIcon;
            user.Country = userInPut.Country;
            user.Province = userInPut.Province;
            user.City = userInPut.City;
            user.Gender = userInPut.Gender;
            user.NickName = userInPut.NickName;
            return service.Update(user, user.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetHeadIconById(string userid)
        {
            User user = service.Get(userid);

            if (user != null)
            {
                return user.HeadIcon;
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(string id)
        {
            return service.Get(id);
        }
        /// <summary>
        /// 根据用户id和第三方类型查询
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="openIdType"></param>
        /// <returns></returns>
        public UserOpenIds GetUserOpenIdById(string userId, string openIdType)
        {
            return service.GetUserOpenIdByuserId(openIdType,userId);
        }
        /// <summary>
        /// 根据用户ID得到名片信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UserNameCardOutPutDto GetUserNameCardInfo(string userid)
        {
            return service.GetUserNameCardInfo(userid);
        }

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
        public bool SaveNameCard(string userid, string headicon, string nickName, string name,  string company, string position,
            string weburl, string mobile, string email, string wx, string wximg,
            string industry, string area, string address, int openflag)
        {
            return service.SaveNameCard(userid, headicon, nickName, name, company, position, weburl,
                mobile, email, wx, wximg, industry, area, address, openflag);
        }


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
            return service.GetUserAllListFocusByPage(currentpage, pagesize, userid);
        }
    }
}
