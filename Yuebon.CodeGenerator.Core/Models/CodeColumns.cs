using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Models;

namespace Yuebon.CodeGenerator.Models
{
    [SugarTable("Sys_CodeColumns", "表字段")]
    [Serializable]
    public class CodeColumns : BaseEntity
    {
        /// <summary>
        /// 实体属性名称
        /// </summary>
        public string ClassProperName { get; set; }
        /// <summary>
        /// 表字段名称
        /// </summary>
        public string DbColumnName { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 是否自增长
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string CodeType { get; set; }
        /// <summary>
        /// 所属表
        /// </summary>
        public long CodeTableId { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string DefaultValue { get; set; }
    }
}
