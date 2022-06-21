namespace Yuebon.Security.IServices;

/// <summary>
/// 定义访问/操作日志服务接口
/// </summary>
public interface IVisitlogService : IService<VisitLog,VisitlogOutputDto>
{

    // <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    Task<PageResult<VisitlogOutputDto>> FindWithPagerSearchAsync(SearchVisitLogModel search);
}
