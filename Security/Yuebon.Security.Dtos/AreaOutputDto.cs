namespace Yuebon.Security.Dtos;

/// <summary>
/// 输出对象模型
/// </summary>
[Serializable]
public class AreaOutputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long ParentId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? Layers { get; set; }

    /// <summary>
    /// 行政区划级别
    /// country:国家
    /// province:省份（直辖市会在province显示）
    /// city:市（直辖市会在province显示）
    /// district:区县
    /// street:街道
    /// </summary>
    public virtual string Level { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    [MaxLength(50)]
    public virtual string EnCode { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public virtual string FullName { get; set; }
    /// <summary>
    /// 拼音
    /// </summary>
    [MaxLength(200)]
    public virtual string Pinyin { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    [MaxLength(200)]
    public virtual string SimpleSpelling { get; set; }

    /// <summary>
    /// 父级路径
    /// </summary>
    [MaxLength(600)]
    public virtual string FullIdPath { get; set; }

    /// <summary>
    /// 区号
    /// </summary>
    [MaxLength(50)]
    public virtual string AreaCode { get; set; }

    /// <summary>
    /// 邮编
    /// </summary>
    [MaxLength(50)]
    public virtual string ZipCode { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    [MaxLength(100)]
    public virtual string Province { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    [MaxLength(100)]
    public virtual string City { get; set; }

    /// <summary>
    /// 县区
    /// </summary>
    [MaxLength(100)]
    public virtual string District { get; set; }

    /// <summary>
    /// 乡镇
    /// </summary>
    [MaxLength(100)]
    public virtual string Town { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? SortCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? DeleteMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? EnabledMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(500)]
    public string Description { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long CreatorUserId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long LastModifyUserId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long DeleteUserId { get; set; }


    public List<Area> Child { get; set; }


}
