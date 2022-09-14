using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Core.DataManager
{
    /// <summary>
    /// 数据库连接配置特性
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class |System.AttributeTargets.Struct, AllowMultiple = true)]
    public class AppDBContextAttribute : Attribute
    {
        /// <summary>
        /// 数据库配置名称
        /// </summary>
        public string DbConfigName { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbConfigName"></param>
        public AppDBContextAttribute(string dbConfigName)
        {
            DbConfigName = dbConfigName;
        }
    }
}
