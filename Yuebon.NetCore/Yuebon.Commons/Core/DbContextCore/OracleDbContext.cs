using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;

namespace Yuebon.Commons.DbContextCore
{
    public class OracleDbContext:BaseDbContext, IOracleDbContext
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
            string dbType = dbConfigName.ToUpper();
            if (dbType.Contains("ORACLE"))
            {
                optionsBuilder.UseOracle(defaultSqlConnectionString,d=>d.UseOracleSQLCompatibility("11.2"));
            }
            base.OnConfiguring(optionsBuilder);
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

            using (var cmd = new OracleCommand(sql, (OracleConnection) connection))
            {
                cmd.CommandTimeout = cmdTimeout;
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                
                using (var da = new OracleDataAdapter(cmd))
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
