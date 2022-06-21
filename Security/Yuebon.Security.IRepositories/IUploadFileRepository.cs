
namespace Yuebon.Security.IRepositories;

public interface IUploadFileRepository : IRepository<UploadFile> {


    /// <summary>
    /// 根据应用Id和应用标识批量更新数据
    /// </summary>
    /// <param name="beLongAppId">应用Id</param>
    /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
    /// <param name="belongApp">应用标识</param>
    /// <returns></returns>
    bool UpdateByBeLongAppId(string beLongAppId, string oldBeLongAppId, string belongApp = "");
}
