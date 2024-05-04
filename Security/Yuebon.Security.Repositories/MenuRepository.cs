using System.Linq;

namespace Yuebon.Security.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



        /// <summary>
        /// ���ݽ�ɫID�ַ��������ŷֿ�)��ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
        /// </summary>
        /// <param name="roleIds">��ɫID</param>
        /// <param name="typeID">ϵͳ����ID</param>
        /// <param name="isMenu">�Ƿ��ǲ˵�</param>
        /// <returns></returns>
        public IEnumerable<Menu> GetFunctions(List<long> roleIds, long typeID,bool isMenu = false)
        {
            string sql = string.Empty;
            if (roleIds == null)
            {
                sql = $"SELECT DISTINCT b.* FROM sys_menu as b where 1=1";
            }
            else
            {
                sql = $"SELECT DISTINCT b.* FROM sys_menu as b INNER JOIN Sys_Role_Authorize as a On b.Id = a.ItemId  WHERE ObjectId IN (" +string.Join(",",roleIds) + ") ";

               
            }
            if (isMenu)
            {
                sql = sql + " and menutype in('M','C') ";
            }
            if (!string.IsNullOrEmpty(typeID.ToString()))
            {
                sql = sql + string.Format(" AND SystemTypeId={0}", typeID);
            }
            return Db.Ado.SqlQuery<Menu>(sql);
        }


        /// <summary>
        /// ����ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
        /// </summary>
        /// <param name="typeID">ϵͳ����ID</param>
        /// <returns></returns>
        public IEnumerable<Menu> GetFunctions(long typeID)
        {
            string sql = $"SELECT DISTINCT b.* FROM sys_menu as b ";
            if (!string.IsNullOrEmpty(typeID.ToString()))
            {
                sql = sql + string.Format(" Where SystemTypeId={0}", typeID);
            }
            return Db.Ado.SqlQuery<Menu>(sql);
        }
    }
}