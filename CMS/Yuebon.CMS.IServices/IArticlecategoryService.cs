namespace Yuebon.CMS.IServices
{
    /// <summary>
    /// 定义文章分类服务接口
    /// </summary>
    public interface IArticlecategoryService:IService<Articlecategory,ArticlecategoryOutputDto>
    {

        /// <summary>
        /// 获取章分类适用于Vue 树形列表，关键词为空时获取所有
        /// <param name="keyword">名称关键词</param>
        /// </summary>
        /// <returns></returns>
        Task<List<ArticlecategoryOutputDto>> GetAllArticlecategoryTreeTable(string keyword);


        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        CommonResult DeleteBatchWhere(DeletesInputDto ids);
        /// <summary>
        /// 异步按条件批量删除
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids);
    }
}
