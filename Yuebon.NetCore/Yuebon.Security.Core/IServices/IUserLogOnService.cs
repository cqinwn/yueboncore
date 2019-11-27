using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IUserLogOnService:IService<UserLogOn, string>
    {

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserLogOn GetByUserId(string userId);
    }
}
