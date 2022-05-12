using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class UserLogOnRepository : BaseRepository<UserLogOn>, IUserLogOnRepository
    {
        public UserLogOnRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// ���ݻ�ԱID��ȡ�û���¼��Ϣʵ��
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserLogOn GetByUserId(long userId)
        {
            string sql = @"SELECT * FROM Sys_UserLogOn t WHERE t.UserId = @UserId";
            return Db.Ado.SqlQuerySingle<UserLogOn>(sql, new { UserId = userId });
        }
    }
}