using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class OrganizeRepository : BaseRepository<Organize>, IOrganizeRepository
    {
        public OrganizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// ��ȡ���ڵ���֯
        /// </summary>
        /// <param name="id">��֯Id</param>
        /// <returns></returns>
        public Organize GetRootOrganize(string id)
        {
            //var sb = new StringBuilder(";WITH ");
            ////if(dbConnectionOptions.DatabaseType == DatabaseType.MySql)
            ////{
            ////    sb.Append(" Recursive ");
            ////}
            //sb.Append(" T AS (");
            //sb.Append(" SELECT Id, ParentId, FullName, Layers FROM Sys_Organize");
            //sb.AppendFormat(" WHERE Id = '{0}'",id);
            //sb.Append(" UNION ALL ");
            //sb.Append(" SELECT A.Id, A.ParentId, A.FullName, A.Layers FROM Sys_Organize AS A JOIN T AS B ON A.Id = B.ParentId ) SELECT* FROM T ORDER BY Layers");
            //return  DapperConn.QueryFirstOrDefault<Organize>(sb.ToString());

            return Db.Queryable<Organize>().ToParentList(it => it.ParentId, id).FindLast(o=>o.Layers==1);
        }
    }
}