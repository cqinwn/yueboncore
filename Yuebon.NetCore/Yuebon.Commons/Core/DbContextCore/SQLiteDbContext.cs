﻿using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;

namespace Yuebon.Commons.DbContextCore
{
    /// <summary>
    /// SQLite数据库操作
    /// </summary>
    public class SQLiteDbContext:BaseDbContext, ISQLiteDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdTimeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataTable GetDataTable(string sql, int cmdTimeout = 30, params DbParameter[] parameters)
        {
            return GetDataTables(sql, cmdTimeout, parameters).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdTimeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override List<DataTable> GetDataTables(string sql, int cmdTimeout = 30, params DbParameter[] parameters)
        {
            var dts = new List<DataTable>();
            //TODO： connection 不能dispose 或者 用using，否则下次获取connection会报错提示“the connectionstring property has not been initialized。”
            var connection = Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (var cmd = new SqliteCommand(sql, (SqliteConnection) connection))
            {
                cmd.CommandTimeout = cmdTimeout;
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    dts.Add(reader.GetSchemaTable());
                }
            }
            connection.Close();

            return dts;
        }

    }
}
