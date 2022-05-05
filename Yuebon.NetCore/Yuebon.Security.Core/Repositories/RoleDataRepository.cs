using System.Collections.Generic;
using System.Data;
using System.Linq;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleDataRepository : BaseRepository<RoleData>, IRoleDataRepository
    {
        public RoleDataRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// 根据角色返回授权访问部门数据
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
            return Db.Ado.SqlQuery<string>(sql);
           
        }

    }
}