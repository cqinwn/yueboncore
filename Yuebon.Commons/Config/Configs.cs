using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Yuebon.Commons.Core.App;

namespace Yuebon.Commons
{
    /// <summary>
    /// 配置文件读取操作
    /// </summary>
    public class Configs
    {
        /// <summary>
        /// 
        /// </summary>
        public static IConfiguration configuration;
        static Configs()
        {
            configuration = Appsettings.Configuration;
        }
        /// <summary>
        /// 根据Key获取数配置内容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IConfigurationSection GetSection(string key)
        {
            return configuration.GetSection(key);
        }
        /// <summary>
        /// 根据section和key获取配置内容
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigurationValue(string section, string key)
        {
            return GetSection(section)?[key];
        }

        /// <summary>
        /// 根据Key获取数据库连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return configuration.GetConnectionString(key);
        }
    }
}
