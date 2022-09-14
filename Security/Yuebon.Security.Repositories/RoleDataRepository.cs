namespace Yuebon.Security.Repositories
{
    public class RoleDataRepository : BaseRepository<RoleData>, IRoleDataRepository
    {
        public RoleDataRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            return Db.Ado.SqlQuery<string>(sql);
           
        }

    }
}