using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Commons.DbContextCore;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 日志仓储实现
    /// </summary>
    public class LogRepository : BaseRepository<Log, string>, ILogRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public LogRepository()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public LogRepository(IDbContextCore dbContext) : base(dbContext)
        {
            this.dbConfigName = "MsSqlServerCode";
        }
        /// <summary>
        /// 测试性能，建议删除
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public long InsertTset(int len)
        {
           
            int n = 0;

            var sb = new StringBuilder(n + " 条数据插入 ： \n");
            List<Log> logList = new List<Log>();

            Log logEntity1 = new Log()
            {
                Id = GuidUtils.GuId(),
                Date = DateTime.Now,
                Account = "admin",
                NickName = "超级管理员",
                OrganizeId = "2020101619392209546893",
                Type = "SQL",
                IPAddress = "171.110.40.191",
                IPAddressName = "中国广西壮族自治区玉林市",
                ModuleName = "Log",
                Result = true,
                Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
                DeleteMark = false,
                EnabledMark = true,
                CreatorTime = DateTime.Now,
                CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
            };
            Log logEntity2 = new Log()
            {
                Id = GuidUtils.GuId(),
                Date = DateTime.Now,
                Account = "admin",
                NickName = "超级管理员",
                OrganizeId = "2020101619392209546893",
                Type = "SQL",
                IPAddress = "171.110.40.191",
                IPAddressName = "中国广西壮族自治区玉林市",
                ModuleName = "Log",
                Result = true,
                Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
                DeleteMark = false,
                EnabledMark = true,
                CreatorTime = DateTime.Now,
                CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
            };
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
           Insert(logEntity1);
            stopwatch.Stop();
            sb.Append("Dapper Insert耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch.Start();
           Add(logEntity2);
            stopwatch.Stop();
            sb.Append("EF Add耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));

            logEntity1.DeleteMark = false;
            logEntity1.LastModifyTime = DateTime.Now;

            logEntity2.DeleteMark = false;
            logEntity2.LastModifyTime = DateTime.Now;
            stopwatch.Start();
            Update(logEntity1);
            stopwatch.Stop();
            sb.Append("Dapper Update耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch.Start();
            Edit(logEntity2);
            stopwatch.Stop();
            sb.Append("EF Edit耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));

            while (n < len.ToInt())
            {
                Log logEntity = new Log()
                {
                    Id = GuidUtils.GuId(),
                    Date = DateTime.Now,
                    Account = "admin",
                    NickName = "超级管理员",
                    OrganizeId = "2020101619392209546893",
                    Type = "SQL",
                    IPAddress = "171.110.40.191",
                    IPAddressName = "中国广西壮族自治区玉林市",
                    ModuleName = "Log",
                    Result = true,
                    Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
                    DeleteMark = false,
                    EnabledMark = true,
                    CreatorTime = DateTime.Now,
                    CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
                };
                logList.Add(logEntity);
                n++;
            }

            string sql = "insert into Sys_Log ([Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (@Date, @Account, @NickName, @OrganizeId, @Type, @IPAddress, @IPAddressName, @ModuleId, @ModuleName, @Result, @Description, @DeleteMark, @EnabledMark, @CreatorTime, @CreatorUserId, @LastModifyTime, @LastModifyUserId, @DeleteTime, @DeleteUserId, @Id)";

            stopwatch.Start();
            _dbContext.BulkInsert<Log>(logList);
            stopwatch.Stop();
            sb.Append("EF BulkInsert耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));

            stopwatch.Start();
            _dbContext.EditRange<Log>(logList);
            stopwatch.Stop();
            sb.Append("EF EditRange批量耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch.Start();
            _dbContext.AddRange<Log>(logList);
            stopwatch.Stop();
            sb.Append("EF AddRange批量耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            using (IDbConnection conn = OpenSharedConnection())
            {
               
                stopwatch.Start();
                conn.Insert(logList);
                stopwatch.Stop();
                sb.Append("Dapper Insert批量耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));

                stopwatch.Start();
                conn.Execute(sql, logList);
                stopwatch.Stop();
                sb.Append("Dapper ExecuteAsync耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            }
            stopwatch.Start();
            Get(logEntity1.Id);
            stopwatch.Stop();
            sb.Append("Dapper Get耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch.Start();
            _dbContext.GetDbSet<Log>().Find(logEntity1.Id);
            stopwatch.Stop();
            sb.Append("Ef Core Find耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            Log4NetHelper.Info(sb.ToString());
            return 1;
        }

        /// <summary>
        /// 物理删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(string id, IDbTransaction trans = null)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                int row = conn.Execute($"delete from {tableName} where Id=@id", new { @id = id }, trans);
                return row > 0 ? true : false;
            }
        }
    }
}