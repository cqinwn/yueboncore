namespace Yuebon.AspNetCore.ViewModel;

/// <summary>
/// 查询条件公共实体类
/// </summary>
[Serializable]
[DataContract]
public class SearchModel: PagerInfo
{
    /// <summary>
    /// 关键词
    /// </summary>
    public string Keywords
    {
        get; set;
    }
    /// <summary>
    /// 编码/代码
    /// </summary>
    public string EnCode
    {
        get; set;
    }
    /// <summary>
    /// 排序方式 默认asc 
    /// </summary>
    public string Order
    {
        get; set;
    }
    /// <summary>
    /// 排序字段 默认Id
    /// </summary>
    public string Sort
    {
        get; set;
    }
}
