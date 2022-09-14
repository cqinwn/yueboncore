namespace Yuebon.Core.Dtos;

/// <summary>
/// 批量物理删除操作传参
/// </summary>
[Serializable]
public class DeletesInputDto
{
    /// <summary>
    /// 主键Id集合
    /// </summary>
    public long[] Ids { get; set; }
}
