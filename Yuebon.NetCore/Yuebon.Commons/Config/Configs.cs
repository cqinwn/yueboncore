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
        public static  IConfiguration configuration;
        static Configs()
        {
            configuration =App.GetService<IConfiguration>();
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

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {

                if (sections.Any())
                {
                    return configuration[string.Join(":", sections)];
                }
            }
            catch (Exception) { }

            return "";
        }

        /// <summary>
        /// 递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> app<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            // 引用 Microsoft.Extensions.Configuration.Binder 包
            configuration.Bind(string.Join(":", sections), list);
            return list;
        }


        /// <summary>
        /// 根据路径  configuration["App:Name"];
        /// </summary>
        /// <param name="sectionsPath"></param>
        /// <returns></returns>
        public static string GetValue(string sectionsPath)
        {
            try
            {
                return configuration[sectionsPath];
            }
            catch (Exception) { }

            return "";

        }
    }
}
