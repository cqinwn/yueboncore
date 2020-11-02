using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Options
{

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        SqlServer,
        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle,
        /// <summary>
        /// Access数据库
        /// </summary>
        Access,
        /// <summary>
        /// MySql数据库
        /// </summary>
        MySql,
        /// <summary>
        /// SQLite数据库
        /// </summary>
        SQLite,
        /// <summary>
        /// PostgreSQL数据库
        /// </summary>
        PostgreSQL
    }
}
