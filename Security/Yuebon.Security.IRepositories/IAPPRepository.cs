

namespace Yuebon.Security.IRepositories;

/// <summary>
/// 
/// </summary>
public interface IAPPRepository:IRepository<APP>
{
    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <param name="secret">Ӧ����ԿAppSecret</param>
    /// <returns></returns>
    APP GetAPP(string appid, string secret);

    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <returns></returns>
    APP GetAPP(string appid);

}