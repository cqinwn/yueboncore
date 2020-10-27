using Dapper;
using System;
using System.Text;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class OrganizeRepository : BaseRepository<Organize, string>, IOrganizeRepository
    {
        public OrganizeRepository()
        {
        }

        public OrganizeRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        public Organize GetRootOrganize(string id)
        {
            var sb = new StringBuilder(";WITH T AS ");
            sb.Append("(");
            sb.Append(" SELECT Id, ParentId, FullName, Layers FROM Sys_Organize");
            sb.AppendFormat(" WHERE Id = '{0}'",id);
            sb.Append(" UNION ALL ");
            sb.Append(" SELECT A.Id, A.ParentId, A.FullName, A.Layers FROM Sys_Organize AS A JOIN T AS B ON A.Id = B.ParentId ) SELECT* FROM T ORDER BY Layers");

            return Execute((conn, trans) =>
            {
                return conn.QueryFirstOrDefault<Organize>(sb.ToString(), trans);
            });
        }
    }
}