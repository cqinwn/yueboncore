using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Core.DataManager
{
    /// <summary>
    /// 数据库连接配置特性
    /// </summary>
    public class AppDBContextAttribute : Attribute
    {
        /// <summary>
        /// 数据库配置名称
        /// </summary>
        public string DbConfigName { get; set; }

        public AppDBContextAttribute(string dbConfigName)
        {
            DbConfigName = dbConfigName;
        }
    }
}
