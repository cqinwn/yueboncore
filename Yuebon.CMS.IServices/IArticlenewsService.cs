namespace Yuebon.CMS.IServices;

/// <summary>
/// 定义文章服务接口
/// </summary>
public interface IArticlenewsService:IService<Articlenews,ArticlenewsOutputDto>
{
    /// <summary>
    /// 根据用户角色获取分类及该分类的文章
    /// </summary>
    /// <returns></returns>
    Task<List<CategoryArticleOutputDto>> GetCategoryArticleList();
}
