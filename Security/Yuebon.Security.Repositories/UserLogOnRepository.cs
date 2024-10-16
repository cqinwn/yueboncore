namespace Yuebon.Security.Repositories
{
    public class UserLogOnRepository : BaseRepository<UserLogOn>, IUserLogOnRepository
    {
        public UserLogOnRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 根据会员ID获取用户登录信息实体
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserLogOn GetByUserId(long userId)
        {
            string sql = @"SELECT * FROM Sys_User_LogOn t WHERE t.UserId = @UserId";
            return Db.Ado.SqlQuerySingle<UserLogOn>(sql, new { UserId = userId });
        }
    }
}