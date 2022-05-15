using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// SqlSugar 启动服务
    /// </summary>
    public static class SqlsugarSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddSqlsugarSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            List<DbConnections> allDbs = DBServerProvider.GetAllDbConnections();
            // 把多个连接对象注入服务
            services.AddSingleton<ISqlSugarClient>(o =>
            {
                // 连接字符串
                var listConfig = new List<ConnectionConfig>();
                bool conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt").ToBool();
                allDbs.ForEach(m =>
                {
                    ConnectionConfig config = new ConnectionConfig()
                    {
                        ConfigId = m.ConnId.ToLower(),
                        ConnectionString =conStringEncrypt? DEncrypt.Decrypt(m.MasterDB.ConnectionString): m.MasterDB.ConnectionString,
                        DbType = (DbType)m.MasterDB.DatabaseType,
                        IsAutoCloseConnection = true
                    };
                    if (m.ReadDB!=null)
                    {
                        List<SlaveConnectionConfig> slaveConnectionConfigs= new List<SlaveConnectionConfig>();
                        m.ReadDB.ForEach(r =>
                        {
                            if (r.Enabled)
                            {
                                slaveConnectionConfigs.Add(new SlaveConnectionConfig()
                                {
                                    HitRate = r.HitRate,
                                    ConnectionString = conStringEncrypt ? DEncrypt.Decrypt(r.ConnectionString) : r.ConnectionString
                                });
                            }
                        });
                        config.SlaveConnectionConfigs = slaveConnectionConfigs;
                    }
                    listConfig.Add(config);
                });
                return new SqlSugarScope(listConfig);
            });
        }

    }
}