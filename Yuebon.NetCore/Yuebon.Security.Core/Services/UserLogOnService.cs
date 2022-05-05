using System;
using System.Threading.Tasks;
using Yuebon.Commons.Json;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class UserLogOnService: BaseService<UserLogOn, UserLogOnOutputDto>, IUserLogOnService
    {
        private readonly IUserLogOnRepository _userLogOnRepository;
        private readonly ILogService _logService;
        public UserLogOnService(IUserLogOnRepository userLogOnRepository, ILogService logService)
        {
            repository = userLogOnRepository;
            _userLogOnRepository = userLogOnRepository;
            _logService = logService;
        }

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
       public UserLogOn GetByUserId(string userId)
        {
           return _userLogOnRepository.GetByUserId(userId);
        }

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="info">主题配置信息</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<bool> SaveUserTheme(UserThemeInputDto info,string userId)
        {
            string themeJsonStr = info.ToJson();
            string where = $"UserId='{userId}'";
            return await _userLogOnRepository.UpdateTableFieldAsync("Theme",themeJsonStr, where);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<bool> UpdateAsync(UserLogOn entity, string id)
        {
            return repository.Db.Updateable<UserLogOn>(entity).Where(t=>t.Id==id).ExecuteCommandHasChangeAsync();
        }
    }
}