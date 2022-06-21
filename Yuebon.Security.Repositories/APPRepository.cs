namespace Yuebon.Security.Repositories;

/// <summary>
/// 应用仓储实现
/// </summary>
public class APPRepository : BaseRepository<APP>, IAPPRepository
{
    public APPRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    /// <summary>
    /// 获取app对象
    /// </summary>
    /// <param name="appid">应用ID</param>
    /// <param name="secret">应用密钥AppSecret</param>
    /// <returns></returns>
    public APP GetAPP(string appid, string secret)
    {
        return Db.Queryable<APP>().First(t=>t.AppId==appid&&t.AppSecret==secret && t.EnabledMark==true);
    }

    /// <summary>
    /// 获取app对象
    /// </summary>
    /// <param name="appid">应用ID</param>
    /// <returns></returns>
    public APP GetAPP(string appid)
    {
        return Db.Queryable<APP>().First(t => t.AppId == appid);

    }
}