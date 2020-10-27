using Dapper;
using System;
using System.Data;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using System.Collections.Generic;
using Yuebon.Security.Dtos;
using Yuebon.Commons.Extend;
using System.Linq;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 应用仓储
    /// </summary>
    public class APPRepository : BaseRepository<APP,string>, IAPPRepository
    {
        public APPRepository()
        {
        }

        public APPRepository(BaseDbContext context) : base(context)
        {
        }
        /// <summary>
        /// 获取app对象
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <param name="secret">应用密钥AppSecret</param>
        /// <returns></returns>
        public APP GetAPP(string appid, string secret)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM Sys_APP t WHERE t.AppId = @AppId and AppSecret=@AppSecret and EnabledMark=1";
                return conn.QueryFirst<APP>(sql, new { AppId = appid, AppSecret= secret});
                
            }
        }

        /// <summary>
        /// 获取app对象
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <returns></returns>
        public APP GetAPP(string appid)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM Sys_APP t WHERE t.AppId = @AppId and EnabledMark=1";
                return conn.QueryFirst<APP>(sql, new { AppId = appid });

            }
        }
        public IList<AppOutputDto> SelectApp()
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                const string query = @"select a.*,u.id as Id,u.NickName,u.Account,u.HeadIcon from [dbo].[Sys_APP] a,Sys_User u where a.CreatorUserId=u.Id ";
                return conn.Query<AppOutputDto, User, AppOutputDto>(query, (app, user) => { app.UserInfo = user; return app; },null,splitOn: "Id").ToList<AppOutputDto>();
            }
        }
    }
}