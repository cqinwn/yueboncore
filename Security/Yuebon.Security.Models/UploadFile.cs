using System.ComponentModel.DataAnnotations.Schema;

namespace Yuebon.Security.Models;

/// <summary>
/// 用户上传附件管理，文件、图片等
/// </summary>
[SugarTable("Sys_UploadFile", "用户上传附件管理")]
public class UploadFile : TenantEntity, ICreationAudited
{
    /// <summary>
    /// 
    /// </summary>
    public UploadFile()
    {
    }

    /// <summary>
	    /// 文件名称
	    /// </summary>
    [MaxLength(200)]
    [SugarColumn(ColumnDescription= "文件名称")]
    [Required]
    [Column(TypeName = "NVARCHAR(200)")]
    public string FileName { get; set; }
    /// <summary>
	    /// 文件路径
	    /// </summary>
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "文件路径")]
    [Required]
    [Column(TypeName = "NVARCHAR(500)")]
    public string FilePath { get; set; }
    /// <summary>
	    /// 描述
	    /// </summary>
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "描述")]
    public string Description { get; set; }
    /// <summary>
	    /// 文件类型
	    /// </summary>
    [MaxLength(20)]
    [SugarColumn(ColumnDescription= "文件类型")]
    [Column(TypeName = "NVARCHAR(20)")]
    public string FileType { get; set; }
    /// <summary>
	    /// 文件大小
	    /// </summary>
    [SugarColumn(ColumnDescription= "文件大小")]
    public int FileSize { get; set; }
    /// <summary>
	    /// 扩展名称
	    /// </summary>
    [MaxLength(20)]
    [SugarColumn(ColumnDescription= "扩展名称")]
    [Column(TypeName = "NVARCHAR(20)")]
    public string Extension { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription= "排序")]
    public int SortCode { get; set; }
    /// <summary>
    /// 删除标志
    /// </summary>
    [SugarColumn(ColumnDescription= "删除标志")]
    public virtual bool? DeleteMark { get; set; }

    /// <summary>
    /// 有效标志
    /// </summary>
    [SugarColumn(ColumnDescription= "有效标志")]
    public virtual bool? EnabledMark { get; set; }
    /// <summary>
    /// 创建用户主键
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "创建用户主键")]
    public virtual long? CreatorUserId { get; set; }
    /// <summary>
	    /// 上传时间
	    /// </summary>
    [SugarColumn(ColumnDescription= "上传时间")]
    public DateTime? CreatorTime { get; set; }
    /// <summary>
	    /// 缩略图
	    /// </summary>
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "缩略图")]
    [Column(TypeName =("NVARCHAR(500)"))]
    public string Thumbnail { get; set; }
    /// <summary>
	    /// 所属应用
	    /// </summary>
    [MaxLength(200)]
    [SugarColumn(ColumnDescription= "所属应用")]
    public string BelongApp { get; set; }
    /// <summary>
	    /// 所属应用ID
	    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "所属应用ID")]
    public string BelongAppId { get; set; }
}
