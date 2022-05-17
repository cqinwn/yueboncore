using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.Enums
{
    /// <summary>
    /// 租户数据架构
    /// </summary>
    public enum TenantSchemaEnum
    {
        /// <summary>
        /// 共享数据库，独立Schema(基于 Schema 的方式)
        /// </summary>
        [Description("共享数据库，独立Schema")]
        AloneSchema = 0,
        /// <summary>
        /// 独立数据库(基于 Database 的方式)
        /// </summary>
        [Description("独立数据库")]
        AloneDatabase = 1,

        /// <summary>
        /// 共享数据库，共享Schema（基于 TenantId 的方式）
        /// </summary>
        [Description("共享数据库，共享Schema")]
        ShareSchema = 2
    }
}
