using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Enums;

namespace Yuebon.Commons.Core.DataManager
{
    /// <summary>
    /// 定义主数据和从数据库配置选项
    /// </summary>
    public class DbConnections
    {
        /// <summary>
        /// 主数据库
        /// </summary>
        public DbConnectionOptions MassterDB {get;set; }

        /// <summary>
        /// 从数据库
        /// </summary>
        public List<DbConnectionOptions> ReadDB { get; set; }
    }


    /// <summary>
    /// 数据库配置选项,定义数据库连接字符串、数据库类型和访问权重
    /// </summary>
    public class DbConnectionOptions
    {
        /// <summary>
        /// 数据库连接字符
        /// </summary>
        public string ConnectionString { get;set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// 访问权重，值越大权重越低
        /// </summary>
        public int DbLevel { get; set; }
    }
}
