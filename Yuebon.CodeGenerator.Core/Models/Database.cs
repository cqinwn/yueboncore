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
    /// 数据库信息
    /// </summary>
    [SugarTable("Sys_Database", "数据库信息")]
    [Serializable]
    public class Database : BaseEntity
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        [SugarColumn(ColumnDescription = "数据库连接",Length =600)]
        public string Connection { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }
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
    }
}
