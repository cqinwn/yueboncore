

namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IAPPService:IService<APP, AppOutputDto>
{
    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <param name="secret">Ӧ����ԿAppSecret</param>
    /// <returns></returns>
    Task<APP> GetAPP(string appid, string secret);

    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <returns></returns>
    Task<APP> GetAPP(string appid);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //IList<AppOutputDto> SelectApp();
    /// <summary>
    /// ���¿��õ�Ӧ�õ�����
    /// </summary>
    void  UpdateCacheAllowApp();
}
