

namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IAPPService:IService<APP, AppOutputDto>
{
    /// <summary>
    /// 获取app对象
    /// </summary>
    /// <param name="appid">应用ID</param>
    /// <param name="secret">应用密钥AppSecret</param>
    /// <returns></returns>
    Task<APP> GetAPP(string appid, string secret);

    /// <summary>
    /// 获取app对象
    /// </summary>
    /// <param name="appid">应用ID</param>
    /// <returns></returns>
    Task<APP> GetAPP(string appid);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //IList<AppOutputDto> SelectApp();
    /// <summary>
    /// 更新可用的应用到缓存
    /// </summary>
    void  UpdateCacheAllowApp();
}
