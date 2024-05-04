namespace Yuebon.Security.Models;

[SugarTable("Sys_Sql_Log", "SQL日志")]
[Serializable]
public class SqlLog : LongEntity, ICreationAudited
{
    public SqlLog()
    {
    }

    #region Property Members


    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "用户名")]
    public virtual string? Account { get; set; }

    /// <summary>
    /// sql语句
    /// </summary>
    [SugarColumn(ColumnDescription = "sql语句", ColumnDataType = "varchar(max)")]
    public virtual string? Description { get; set; }
    /// <summary>
    /// 耗时
    /// </summary>
    [SugarColumn(ColumnDescription = "耗时")]
    public virtual decimal? ElapsedTime { get; set; }
    /// <summary>
    /// 结果
    /// </summary>
    public virtual bool? Result { get; set; }


    /// <summary>
    /// 创建日期
    /// </summary>
    [SugarColumn(ColumnDescription = "创建日期")]
    public virtual DateTime? CreatorTime { get; set; }
    /// <summary>
    /// 设置或获取 创建者部门Id
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者部门Id", IsOnlyIgnoreUpdate = true)]
    public long? CreateOrgId { get; set; }
    /// <summary>
    /// 创建用户主键
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "创建用户主键")]
    public virtual long? CreatorUserId { get; set; }

    #endregion
}
