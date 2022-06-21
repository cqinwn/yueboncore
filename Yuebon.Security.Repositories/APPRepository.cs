namespace Yuebon.Security.Repositories;

/// <summary>
/// Ӧ�òִ�ʵ��
/// </summary>
public class APPRepository : BaseRepository<APP>, IAPPRepository
{
    public APPRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <param name="secret">Ӧ����ԿAppSecret</param>
    /// <returns></returns>
    public APP GetAPP(string appid, string secret)
    {
        return Db.Queryable<APP>().First(t=>t.AppId==appid&&t.AppSecret==secret && t.EnabledMark==true);
    }

    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <returns></returns>
    public APP GetAPP(string appid)
    {
        return Db.Queryable<APP>().First(t => t.AppId == appid);

    }
}