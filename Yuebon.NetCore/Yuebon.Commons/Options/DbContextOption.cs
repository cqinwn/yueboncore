using Yuebon.Commons.Enums;

namespace Yuebon.Commons.Options
{
    /// <summary>
    /// 数据库上下文配置
    /// </summary>
    public class DbContextOption
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string dbConfigName { get; set; }
        /// <summary>
        /// 实体程序集名称
        /// </summary>
        public string ModelAssemblyName { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DatabaseType DbType { get; set; } = DatabaseType.SqlServer;
        /// <summary>
        /// 是否输出Sql日志
        /// </summary>
        public bool IsOutputSql;
    }

}
