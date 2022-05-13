using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Enums
{

    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MySql数据库
        /// </summary>
        MySql = 0,
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        SqlServer=1,
        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle=2,
        /// <summary>
        /// Access数据库
        /// </summary>
        Access=3,
        /// <summary>
        /// SQLite数据库
        /// </summary>
        SQLite=4,
        /// <summary>
        /// PostgreSQL数据库
        /// </summary>
        PostgreSQL=5,
        /// <summary>
        /// Npgsql数据库
        /// </summary>
        Npgsql=6,
        /// <summary>
        /// 
        /// </summary>
        Dm=7,
        /// <summary>
        /// 
        /// </summary>
        Kdbndp=8
    }
}
