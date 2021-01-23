using System;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IUserLogOnService:IService<UserLogOn, UserLogOnOutputDto, string>
    {

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        UserLogOn GetByUserId(string userId);

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="info">主题配置信息</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task<bool> SaveUserTheme(UserThemeInputDto info, string userId);
    }
}
