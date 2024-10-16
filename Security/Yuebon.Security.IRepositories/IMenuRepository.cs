namespace Yuebon.Security.IRepositories;

public interface IMenuRepository:IRepository<Menu>
{

    /// <summary>
    /// 根据角色ID字符串（逗号分开)和系统类型ID，获取对应的操作功能列表
    /// </summary>
    /// <param name="roleIds">角色ID</param>
    /// <param name="typeID">系统类型ID</param>
    /// <param name="isMenu">是否是菜单</param>
    /// <returns></returns>
    IEnumerable<Menu> GetFunctions(List<long> roleIds, long typeID, bool isMenu = false);

    /// <summary>
    /// 根据系统类型ID，获取对应的操作功能列表
    /// </summary>
    /// <param name="typeID">系统类型ID</param>
    /// <returns></returns>
    IEnumerable<Menu> GetFunctions(long typeID);
}