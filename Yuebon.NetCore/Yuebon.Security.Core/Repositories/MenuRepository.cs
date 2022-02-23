using Dapper;
using System.Collections.Generic;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository()
        {
        }

        public MenuRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }


        /// <summary>
        /// 根据角色ID字符串（逗号分开)和系统类型ID，获取对应的操作功能列表
        /// </summary>
        /// <param name="roleIds">角色ID</param>
        /// <param name="typeID">系统类型ID</param>
        /// <param name="isMenu">是否是菜单</param>
        /// <returns></returns>
        public IEnumerable<Menu> GetFunctions(string roleIds, string typeID,bool isMenu = false)
        {
            string sql = $"SELECT DISTINCT b.* FROM sys_menu as b INNER JOIN Sys_RoleAuthorize as a On b.Id = a.ItemId  WHERE ObjectId IN (" + roleIds + ")";
            if (roleIds == "")
            {
                sql = $"SELECT DISTINCT b.* FROM sys_menu as b where 1=1 ";
            }
            if (isMenu)
            {
                sql = sql + "and menutype in('M','C')";
            }
            if (!string.IsNullOrEmpty(typeID))
            {
                sql = sql + string.Format(" AND SystemTypeId='{0}' ", typeID);
            }
            return DapperConnRead.Query<Menu>(sql);
        }


        /// <summary>
        /// 根据系统类型ID，获取对应的操作功能列表
        /// </summary>
        /// <param name="typeID">系统类型ID</param>
        /// <returns></returns>
        public IEnumerable<Menu> GetFunctions(string typeID)
        {
            string sql = $"SELECT DISTINCT b.* FROM sys_menu as b ";
            if (!string.IsNullOrEmpty(typeID))
            {
                sql = sql + string.Format(" Where SystemTypeId='{0}' ", typeID);
            }
            return DapperConnRead.Query<Menu>(sql);
        }
    }
}