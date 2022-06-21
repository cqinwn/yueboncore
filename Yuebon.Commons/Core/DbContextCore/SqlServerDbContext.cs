using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.DbContextCore
{
    /// <summary>
    /// Sql Server数据库上下文
    /// </summary>
    public class SqlServerDbContext:BaseDbContext, ISqlServerDbContext
    {

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">数据实体集合</param>
        /// <param name="destinationTableName">如果为 null，则使用 TModel 名称作为 destinationTableName</param>
        /// <returns></returns>
        public override void BulkInsert<T>(IList<T> entities, string destinationTableName = null)
        {
            if (entities == null || !entities.Any()) return;
            if (string.IsNullOrEmpty(destinationTableName))
            {
                var mappingTableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name;
                destinationTableName = string.IsNullOrEmpty(mappingTableName) ? typeof(T).Name : mappingTableName;
            }
            SqlBulkInsert<T>(entities, destinationTableName);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">数据实体集合</param>
        /// <param name="destinationTableName">如果为 null，则使用 TModel 名称作为 destinationTableName</param>
        /// <returns></returns>
        private void SqlBulkInsert<T>(IList<T> entities, string destinationTableName = null) where T : class 
        {
            using (var dt = entities.ToDataTable())
            {
                dt.TableName = destinationTableName;
                var conn = (SqlConnection)Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var bulk = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)
                        {
                            BatchSize = entities.Count,
                            DestinationTableName = dt.TableName,
                        };
                        GenerateColumnMappings<T>(bulk.ColumnMappings);
                        bulk.WriteToServer(dt);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }                        
                }
                conn.Close();
            }
        }
        /// <summary>
        /// 字段与实体关系映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mappings"></param>
        private void GenerateColumnMappings<T>(SqlBulkCopyColumnMappingCollection mappings)
            where T : class 
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes<NotMappedAttribute>().Any()) continue;
                if (property.GetCustomAttributes<KeyAttribute>().Any())
                {
                    mappings.Add(new SqlBulkCopyColumnMapping(property.Name, typeof(T).Name + property.Name));
                }
                else
                {
                    mappings.Add(new SqlBulkCopyColumnMapping(property.Name, property.Name));                    
                }
            }
        }
        /// <summary>
        /// 分页查询，SQL语句查询，返回指定输出对象集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="orderBys">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="eachAction"></param>
        /// <returns></returns>
        public override PageResult<T> SqlQueryByPagination<T, TView>(string sql, string[] orderBys, int pageIndex, int pageSize,
            Action<TView> eachAction = null)
        {
            var total = SqlQuery<T, int>($"select count(1) from ({sql}) as s").FirstOrDefault();
            var jsonResults = SqlQuery<T, TView>(
                    $"select * from (select *,row_number() over (order by {string.Join(",", orderBys)}) as RowId from ({sql}) as s) as t where RowId between {pageSize * (pageIndex - 1) + 1} and {pageSize * pageIndex} order by {string.Join(",", orderBys)}")
                .ToList();
            if (eachAction != null)
            {
                jsonResults = jsonResults.Each(eachAction).ToList();
            }

            return new PageResult<T>()
            {
                CurrentPage = pageIndex,
                ItemsPerPage = pageSize,
                TotalItems = total
            };
        }

        /// <summary>
        /// 分页查询，SQL语句查询，返回数据实体集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="orderBys">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="parameters">查询SQL参数</param>
        /// <returns></returns>
        public override PageResult<T> SqlQueryByPagination<T>(string sql, string[] orderBys, int pageIndex, int pageSize,
            params DbParameter[] parameters)
        {
            var total = (int)this.ExecuteScalar($"select count(1) from ({sql}) as s");
            var jsonResults = GetDataTable(
                    $"select * from (select *,row_number() over (order by {string.Join(",", orderBys)}) as RowId from ({sql}) as s) as t where RowId between {pageSize * (pageIndex - 1) + 1} and {pageSize * pageIndex} order by {string.Join(",", orderBys)}")
                .ToList<T>();
            return new PageResult<T>()
            {
                CurrentPage = pageIndex,
                ItemsPerPage = pageSize,
                TotalItems = total,
                Items = jsonResults
            };
        }
        /// <summary>
        /// 根据sql语句返回DataTable数据
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="cmdTimeout">执行超时时间，默认30毫秒</param>
        /// <param name="parameters">DbParameter[]参数</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string sql, int cmdTimeout = 30, params DbParameter[] parameters)
        {
            return GetDataTables(sql, cmdTimeout, parameters).FirstOrDefault();
        }
        /// <summary>
        /// 根据sql语句返回List数据
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="cmdTimeout">执行超时时间，默认30毫秒</param>
        /// <param name="parameters">DbParameter[] 参数</param>
        /// <returns></returns>
        public override List<DataTable> GetDataTables(string sql, int cmdTimeout = 30, params DbParameter[] parameters)
        {
            var dts = new List<DataTable>();
            //TODO： connection 不能dispose 或者 用using，否则下次获取connection会报错提示“the connectionstring property has not been initialized。”
            var connection = Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (var cmd = new SqlCommand(sql, (SqlConnection) connection))
            {
                cmd.CommandTimeout = cmdTimeout;
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                
                using (var da = new SqlDataAdapter(cmd))
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
