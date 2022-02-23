using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface IUserLogOnRepository:IRepository<UserLogOn>
    {

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserLogOn GetByUserId(string userId);
    }
}