using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Models;

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
        public int? DbId { get; set; }

        /// <summary>
        /// 实体类名称
        /// </summary>
        public virtual string ClassName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public virtual string TableName { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? Description { get; set; }
        /// <summary>
        /// 创建事件
        /// </summary>
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
        public bool IsLock { get; set; }
    }


}
