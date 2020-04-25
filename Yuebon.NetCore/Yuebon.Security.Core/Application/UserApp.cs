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
        public async Task<User> GetByUserName(string userName)
        {
            return await service.GetByUserName(userName);
        }

        /// <summary>
        /// 根据第三方OpenId查询用户信息
        /// </summary>
        /// <param name="openIdType">第三方类型</param>
        /// <param name="openId">OpenId值</param>
        /// <returns></returns>
        public UserOutputDto GetUserOutDtoByOpenId(string openIdType, string openId)
        {
            return service.GetUserByOpenId(openIdType, openId).MapTo<UserOutputDto>();
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
        /// 更新用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public bool UpdateUser(User user)
        {
            return service.Update(user, user.Id);
        }
        /// <summary>
        /// 根据用户ID获取头像
        /// </summary>
        /// <param name="userid">用户ID</param>
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
        /// <param name="id">用户Id</param>
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
        /// <summary>
        /// 根据微信统一ID（UnionID）查询用户
        /// </summary>
        /// <param name="unionId">UnionID</param>
        /// <returns></returns>
        public User GetUserByUnionId(string unionId)
        {
            return service.GetUserByUnionId(unionId);
        }

        /// <summary>
        /// 统计用户数
        /// </summary>
        /// <returns></returns>
        public int GetCountTotal()
        {
            return service.GetCountByWhere("1=1");
        }
    }
}
