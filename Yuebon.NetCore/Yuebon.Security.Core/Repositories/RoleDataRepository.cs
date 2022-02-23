using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleDataRepository : BaseRepository<RoleData>, IRoleDataRepository
    {
		public RoleDataRepository()
        {
        }

        public RoleDataRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// ���ݽ�ɫ������Ȩ���ʲ�������
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<string> GetListDeptByRole(string roleIds)
        {
            string roleIDsStr = string.Format("'{0}'", roleIds.Replace(",", "','"));
            string where = " RoleId in(" + roleIDsStr + ") and DType='dept'";
            string sql = $"select AuthorizeData from { tableName} ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            using (IDbConnection connection = DapperConn)
            {
                bool isClosed = connection.State == ConnectionState.Closed;
                if (isClosed) connection.Open();
                IEnumerable<string> resultList = connection.Query<string>(sql);
                return resultList.ToList();
            }
        }

    }
}