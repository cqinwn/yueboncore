namespace Yuebon.CodeGenerator.Models
{
    [SugarTable("Sys_CodeColumns", "表字段")]
    [Serializable]
    public class CodeColumns : BaseEntity
    {
        /// <summary>
        /// 实体属性名称
        /// </summary>
        [SugarColumn(ColumnDescription = "实体属性名称")]
        public string ClassProperName { get; set; }
        /// <summary>
        /// 表字段名称
        /// </summary>
        [SugarColumn(ColumnDescription = "表字段名称")]
        public string DbColumnName { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        [SugarColumn(ColumnDescription = "是否必填")]
        public bool Required { get; set; }
        /// <summary>
        /// 是否自增长
        /// </summary>
        [SugarColumn(ColumnDescription = "是否自增长")]
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        [SugarColumn(ColumnDescription = "是否是主键")]
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(IsNullable = true,ColumnDescription = "描述")]
        public string Description { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        [SugarColumn(ColumnDescription = "数据类型")]
        public string CodeType { get; set; }
        /// <summary>
        /// 所属表
        /// </summary>
        [SugarColumn(ColumnDescription = "所属表")]
        public long CodeTableId { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        [SugarColumn(IsNullable = true,ColumnDescription = "默认值")]
        public string DefaultValue { get; set; }
    }
}
