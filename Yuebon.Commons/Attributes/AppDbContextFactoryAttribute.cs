using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.Attributes
{
    /// <summary>
    /// 数据库上下文配置
    /// </summary>
    public class AppDbContextFactoryAttribute : Attribute
    {
        /// <summary>
        /// 数据库配置名称
        /// </summary>
        public string DbConfigName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConfigName">数据库配置名称</param>
        public AppDbContextFactoryAttribute(string dbConfigName)
        {
            DbConfigName = dbConfigName;
        }
    }

}
