namespace Yuebon.CodeGenerator.Models
{
    /// <summary>
    /// 表信息
    /// </summary>
    [SugarTable("Sys_CodeTable", "表信息")]
    [Serializable]
    public class CodeTable : BaseEntity
    {
        /// <summary>
        /// 数据库Id
        /// </summary>
        [SugarColumn(ColumnDescription = "数据库Id")]
        public int? DbId { get; set; }

        /// <summary>
        /// 实体类名称
        /// </summary>
        [SugarColumn(ColumnDescription = "实体类名称")]
        public virtual string ClassName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [SugarColumn(ColumnDescription = "表名")]
        public virtual string TableName { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        [SugarColumn(IsNullable = true,ColumnDescription = "表描述")]
        public string? Description { get; set; }
        /// <summary>
        /// 创建事件
        /// </summary>
        [SugarColumn(ColumnDescription = "数据库Id")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [SugarColumn(ColumnDescription = "最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnDescription = "删除标志")]
        public virtual bool? DeleteMark { get; set; }
        /// <summary>
        /// 是否锁表
        /// </summary>
        [SugarColumn(ColumnDescription = "是否锁表")]
        public bool IsLock { get; set; }
    }


}
