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
        /// 共享数据库
        /// </summary>
        [Description("共享数据库")]
        Share = 0,
        /// <summary>
        /// 独立数据库
        /// </summary>
        [Description("独立数据库")]
        Alone = 1,
    }
}
