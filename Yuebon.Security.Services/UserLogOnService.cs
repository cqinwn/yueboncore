namespace Yuebon.Security.Services;

public class UserLogOnService: BaseService<UserLogOn, UserLogOnOutputDto>, IUserLogOnService
{
    private readonly IUserLogOnRepository _userLogOnRepository;
    public UserLogOnService(IUserLogOnRepository userLogOnRepository)
    {
        repository = userLogOnRepository;
        _userLogOnRepository = userLogOnRepository;
    }

    /// <summary>
    /// 根据会员ID获取用户登录信息实体
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
   public UserLogOn GetByUserId(long userId)
    {
       return _userLogOnRepository.GetByUserId(userId);
    }

    /// <summary>
    /// 根据会员ID获取用户登录信息实体
    /// </summary>
    /// <param name="info">主题配置信息</param>
    /// <param name="userId">用户Id</param>
    /// <returns></returns>
    public async Task<bool> SaveUserTheme(UserThemeInputDto info,long userId)
    {
        string themeJsonStr = info.ToJson();
        string where = $"UserId={userId}";
        return await _userLogOnRepository.UpdateTableFieldAsync("Theme",themeJsonStr, where);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(UserLogOn entity, long id)
    {
        return await repository.Db.Updateable<UserLogOn>(entity).Where(t=>t.Id==id).ExecuteCommandHasChangeAsync();
    }
}