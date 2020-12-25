using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;

namespace Yuebon.Commons.DbContextCore
{
    /// <summary>
    /// 
    /// </summary>
    public class MySqlDbContext: BaseDbContext, IMySqlDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            this.isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }
            string defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
            if (conStringEncrypt == "true")
            {
                defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
            }
            optionsBuilder.UseMySql(defaultSqlConnectionString, new MySqlServerVersion(new Version(8, 0, 21)), // use MariaDbServerVersion for MariaDB
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend));
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">数据实体集合</param>
        /// <param name="destinationTableName">数据库表名称</param>
        public override void BulkInsert<T>(IList<T> entities, string destinationTableName = null)
        {
            if (entities == null || !entities.Any()) return;
            if (string.IsNullOrEmpty(destinationTableName))
            {
                var mappingTableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name;
                destinationTableName = string.IsNullOrEmpty(mappingTableName) ? typeof(T).Name : mappingTableName;
            }
            MySqlBulkInsert(entities, destinationTableName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="destinationTableName"></param>
        private void MySqlBulkInsert<T>(IList<T> entities, string destinationTableName) where T : class
        {
            var tmpDir = Path.Combine(AppContext.BaseDirectory, "Temp");
            if (!Directory.Exists(tmpDir))
                Directory.CreateDirectory(tmpDir);
            var csvFileName = Path.Combine(tmpDir, $"{DateTime.Now:yyyyMMddHHmmssfff}.csv");
            if (!File.Exists(csvFileName))
                File.Create(csvFileName);
            var separator = ",";
            entities.SaveToCsv(csvFileName, separator);
            var conn = (MySqlConnection) Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var bulk = new MySqlBulkLoader(conn)
            {
                NumberOfLinesToSkip = 0,
                TableName = destinationTableName,
                FieldTerminator = separator,
                FieldQuotationCharacter = '"',
                EscapeCharacter = '"',
                LineTerminator = "\r\n"
            };
            bulk.LoadAsync();
            conn.Close();
            File.Delete(csvFileName);
        }
        public override DataTable GetDataTable(string sql, int cmdTimeout = 30, params DbParameter[] parameters)
        {
            return GetDataTables(sql, cmdTimeout, parameters).FirstOrDefault();
        }

        public override List<DataTable> GetDataTables(string sql, int cmdTimeout = 30, params DbParameter[] parameters)
        {
            var dts = new List<DataTable>();
            //TODO： connection 不能dispose 或者 用using，否则下次获取connection会报错提示“the connectionstring property has not been initialized。”
            var connection = Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (var cmd = new MySqlCommand(sql, (MySqlConnection) connection))
            {
                cmd.CommandTimeout = cmdTimeout;
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                
                using (var da = new MySqlDataAdapter(cmd))
                {
                    using (var ds = new DataSet())
                    {
                        da.Fill(ds);
                        foreach (DataTable table in ds.Tables)
                        {
                            dts.Add(table);
                        }
                    }
                }
            }
            connection.Close();

            return dts;
        }

    }
}
