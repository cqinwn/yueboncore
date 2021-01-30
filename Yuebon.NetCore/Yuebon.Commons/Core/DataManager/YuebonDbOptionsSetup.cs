
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.Core.DataManager
{
    public class YuebonDbOptionsSetup : IConfigureOptions<YuebonDbOptions>
    {
        private readonly IConfiguration _configuration;

        public YuebonDbOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 配置options各属性信息
        /// </summary>
        /// <param name="options"></param>
        public void Configure(YuebonDbOptions options)
        {
            SetDbConnectionsOptions(options);
        }

        private void SetDbConnectionsOptions(YuebonDbOptions options)
        {
            var dbConnectionMap = new Dictionary<string, DbConnectionOptions>();
            options.DbConnections = dbConnectionMap;

            string dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            IConfiguration section = _configuration.GetSection("DbConnections:"+ dbConfigName);
            Dictionary<string, DbConnectionOptions> dict = section.Get<Dictionary<string, DbConnectionOptions>>();
            if (dict == null || dict.Count == 0)
            {
                string connectionString = _configuration["ConnectionStrings:DefaultDbContext"];
                if (connectionString == null)
                {
                    return;
                }
                    
                dbConnectionMap.Add("DefaultDb", new DbConnectionOptions
                {
                    ConnectionString = connectionString,
                    DatabaseType = options.DefaultDatabaseType
                });

                return;
            }

            var ambiguous = dict.Keys.GroupBy(d => d).FirstOrDefault(d => d.Count() > 1);
            if (ambiguous != null)
            {
                throw new Exception($"数据上下文配置中存在多个配置节点拥有同一个数据库连接名称，存在二义性：{ambiguous.First()}");
            }
            foreach (var db in dict)
            {
                dbConnectionMap.Add(db.Key, db.Value);
            }
        }

    }
}
