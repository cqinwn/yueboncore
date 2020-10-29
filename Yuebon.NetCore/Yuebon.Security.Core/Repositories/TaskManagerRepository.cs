using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Log;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 定时任务仓储接口的实现
    /// </summary>
    public class TaskManagerRepository : BaseRepository<TaskManager, string>, ITaskManagerRepository
    {
		public TaskManagerRepository()
        {
        }
        public TaskManagerRepository(IDbContextCore context) : base(context)
        {
        }



        /// <summary>
        /// 异步按条件设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// 禁用时会将状态更新为暂停
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public override async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, string userId = null, IDbTransaction trans = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "EnabledMark=1 ";
            }
            else
            {
                sql += "EnabledMark=0 ";
                sql += ",Status=0 ";
            }
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",LastModifyUserId='" + userId + "'";
            }
            DateTime lastModifyTime = DateTime.Now;
            sql += ",LastModifyTime=@LastModifyTime where " + where;

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @LastModifyTime = lastModifyTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }


        /// <summary>
        /// 异步批量软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public override async Task<bool> DeleteSoftBatchAsync(bool bl, string where, string userId = null, IDbTransaction trans = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "DeleteMark=0 ";
            }
            else
            {
                sql += "DeleteMark=1 ";
                sql += ",Status=0 ";
            }
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",DeleteUserId='" + userId + "'";
            }
            DateTime deleteTime = DateTime.Now;
            sql += ",DeleteTime=@DeleteTime where " + where;

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @DeleteTime = deleteTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

    }
}