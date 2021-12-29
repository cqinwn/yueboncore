using Dapper;
using System;
using System.Data;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class UserLogOnRepository : BaseRepository<UserLogOn, string>, IUserLogOnRepository
    {
        public UserLogOnRepository()
        {
        }

        public UserLogOnRepository(IDbContextCore dbContext) : base(dbContext)
        {
         
        }



        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserLogOn GetByUserId(string userId)
        {
            string sql = @"SELECT * FROM Sys_UserLogOn t WHERE t.UserId = @UserId";
            return DapperConn.QueryFirst<UserLogOn>(sql, new { UserId = userId });
        }
    }
}