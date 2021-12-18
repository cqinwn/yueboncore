using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Repositories;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 日志仓储实现
    /// </summary>
    public class LogRepository : BaseRepository<Log, Int64>, ILogRepository
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

        }
        /// <summary>
        /// 测试性能，建议删除
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public long InsertTset(int len)
        {
           
            int n = 0;

            var sb = new StringBuilder(" EF 与Dapper常用方法性能分析 ： \n");
            Log logEntity1 = new Log()
            {
                Id = GuidUtils.IdGenerator(),
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
            using (var content=new MySqlDbContext())
            {
                content.Add<Log>(logEntity1); ;
            }
                Log logEntity2 = new Log()
                {
                    Id = GuidUtils.IdGenerator(),
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
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();
            Stopwatch stopwatch5 = new Stopwatch();
            Stopwatch stopwatch6 = new Stopwatch();
            Stopwatch stopwatch7 = new Stopwatch();
            Stopwatch stopwatch8 = new Stopwatch();
            Stopwatch stopwatch9 = new Stopwatch();
            Stopwatch stopwatch10 = new Stopwatch();
            Stopwatch stopwatch11 = new Stopwatch();
            Stopwatch stopwatch12 = new Stopwatch();
            Stopwatch stopwatch13 = new Stopwatch();
            Stopwatch stopwatch14 = new Stopwatch();

            stopwatch.Start();

            //DapperConn.Insert<Log>(logEntity1);
            stopwatch.Stop();
            sb.Append("Dapper 单条数据插入Insert耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch1.Start();
           Add(logEntity2);
            stopwatch1.Stop();
            sb.Append("EF  单条数据插入Add耗时:" + (stopwatch1.ElapsedMilliseconds + "  毫秒\n"));

            logEntity1.DeleteMark = false;
            logEntity1.LastModifyTime = DateTime.Now;

            logEntity2.DeleteMark = false;
            logEntity2.LastModifyTime = DateTime.Now;
            stopwatch2.Start();
            Update(logEntity1);
            stopwatch2.Stop();
            sb.Append("Dapper  单条数据更新Update耗时:" + (stopwatch2.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch3.Start();
            Edit(logEntity2);
            stopwatch3.Stop();
            sb.Append("EF 单条数据更新Edit耗时:" + (stopwatch3.ElapsedMilliseconds + "  毫秒\n"));

            List<Log> logList = new List<Log>();

            List<Log> logList2 = new List<Log>();
            List<Log> logList3 = new List<Log>();
            List<Log> logList4 = new List<Log>();
            List<Log> logList5 = new List<Log>();
            while (n < len.ToInt())
            {
                Log logEntity = new Log()
                {
                    Id = GuidUtils.IdGenerator(),
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
                Log logEntity3 = new Log()
                {
                    Id = GuidUtils.IdGenerator(),
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
                logList2.Add(logEntity3);
                Log logEntity4 = new Log()
                {
                    Id = GuidUtils.IdGenerator(),
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
                logList3.Add(logEntity4);
                Log logEntity5 = new Log()
                {
                    Id = GuidUtils.IdGenerator(),
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
                logList4.Add(logEntity5);
                Log logEntity6 = new Log()
                {
                    Id = GuidUtils.IdGenerator(),
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
                logList5.Add(logEntity6);
                n++;
            }

            string sql = "insert into Sys_Log ([Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (@Date, @Account, @NickName, @OrganizeId, @Type, @IPAddress, @IPAddressName, @ModuleId, @ModuleName, @Result, @Description, @DeleteMark, @EnabledMark, @CreatorTime, @CreatorUserId, @LastModifyTime, @LastModifyUserId, @DeleteTime, @DeleteUserId, @Id)";

            stopwatch4.Start();
            DbContext.BulkInsert<Log>(logList);
            stopwatch4.Stop();
            sb.Append("使用BulkInsert批量插入"+n+"条数据耗时:" + (stopwatch4.ElapsedMilliseconds + "  毫秒\n"));

            stopwatch5.Start();
            DbContext.AddRange<Log>(logList3);
            stopwatch5.Stop();
            sb.Append("EF 批量插入" + n + "条数据AddRange耗时:" + (stopwatch5.ElapsedMilliseconds + "  毫秒\n"));
           
                //stopwatch6.Start();
                //conn.Insert(logList4);
                //stopwatch6.Stop();
                //sb.Append("Dapper 批量插入" + n + "条数据Insert批量耗时:" + (stopwatch6.ElapsedMilliseconds + "  毫秒\n"));

                stopwatch7.Start();
                DapperConn.Execute(sql, logList5);
                stopwatch7.Stop();
                sb.Append("Dapper 批量插入" + n + "条数据ExecuteAsync耗时:" + (stopwatch7.ElapsedMilliseconds + "  毫秒\n"));
           
            List<Log> newlogList = new List<Log>();
            foreach(Log item in logList)
            {
                Log info = new Log();
                info = item;
                info.LastModifyTime = DateTime.Now;
                info.Description += item.Description + item.Description +"更新数据";
                newlogList.Add(info);
            }
            Stopwatch stopwatch15 = new Stopwatch();
            stopwatch15.Start();
           // Update(newlogList);
            stopwatch15.Stop();
            sb.Append("Dapper批量更新" + n + "条数据Update耗时:" + (stopwatch15.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch8.Start();
            DbContext.EditRange<Log>(newlogList);
            stopwatch8.Stop();
            sb.Append("EF 批量更新" + n + "条数据EditRange耗时:" + (stopwatch8.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch9.Start();
            Get(logEntity1.Id);
            stopwatch9.Stop();
            sb.Append("Dapper 查询单个实体Get耗时:" + (stopwatch9.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch10.Start();
            DbContext.GetDbSet<Log>().Find(logEntity1.Id);
            stopwatch10.Stop();
            sb.Append("Ef查询单个实体Find耗时:" + (stopwatch10.ElapsedMilliseconds + "  毫秒\n"));
            sql = $"select * from sys_Log where Id='" + logEntity1.Id + "'";
            stopwatch11.Start();
            DbContext.GetDbSet<Log>().FromSqlRaw<Log>(sql).FirstOrDefaultAsync<Log>();
            stopwatch11.Stop();
            sb.Append("Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:" + (stopwatch11.ElapsedMilliseconds + "  毫秒\n"));
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = 1,
                PageSize = 50
            };
            stopwatch12.Start();
            List<Log> list = FindWithPager("", pagerInfo, "CreatorTime", true);
            PageResult<LogOutputDto> pageResult = new PageResult<LogOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<LogOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            stopwatch12.Stop();
            sb.Append("Dapper 分页查询耗时:" + (stopwatch12.ElapsedMilliseconds + "  毫秒\n"));
            stopwatch13.Start();

            List<Log> list2 = GetByPagination(m => true, pagerInfo, true).ToList<Log>();
            PageResult<LogOutputDto> pageResult2 = new PageResult<LogOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list2.MapTo<LogOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            stopwatch13.Stop();
            sb.Append("EF 分页查询耗时:" + (stopwatch13.ElapsedMilliseconds + "  毫秒\n")); stopwatch.Start();

            sql = $"select * from Sys_log";
            string[] orderBys = { "CreatorTime desc" };
            stopwatch14.Start();
            PageResult<Log> list3 =DbContext.SqlQueryByPagination<Log>(sql, orderBys, 1,50);
            //PageResult<LogOutputDto> pageResult2 = new PageResult<LogOutputDto>
            //{
            //    CurrentPage = pagerInfo.CurrenetPageIndex,
            //    Items = list2.MapTo<LogOutputDto>(),
            //    ItemsPerPage = pagerInfo.PageSize,
            //    TotalItems = pagerInfo.RecordCount
            //};
            stopwatch14.Stop();
            sb.Append("EF 分页查询耗时:" + (stopwatch14.ElapsedMilliseconds + "  毫秒\n"));
            Log4NetHelper.Info(sb.ToString());
            return 1;
        }

        /// <summary>
        /// 物理删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(Int64 id, IDbTransaction trans = null)
        {
            int row = DapperConn.Execute($"delete from {tableName} where Id=@id", new { @id = id }, trans);
            return row > 0 ? true : false;
        }
    }
}