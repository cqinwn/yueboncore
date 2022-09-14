using Yuebon.Commons.Tree;
using Yuebon.Core.Dtos;

namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IMenuService:IService<Menu, MenuOutputDto>
{

    /// <summary>
    /// 根据用户获取功能菜单
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns></returns>
    List<Menu> GetMenuByUser(long userId);

    /// <summary>
    /// 获取功能菜单适用于Vue 树形列表
    /// </summary>
    /// <param name="systemTypeId">子系统Id</param>
    /// <returns></returns>
    Task<List<MenuTreeTableOutputDto>> GetAllMenuTreeTable(long systemTypeId);


    /// <summary>
    /// 根据角色ID字符串（逗号分开)和系统类型ID，获取对应的操作功能列表
    /// </summary>
    /// <param name="roleIds">角色ID</param>
    /// <param name="typeID">系统类型ID</param>
    /// <param name="isMenu">是否是菜单</param>
    /// <returns></returns>
    List<Menu> GetFunctions(string roleIds, long typeID,bool isMenu=false);

    /// <summary>
    /// 根据系统类型ID，获取对应的操作功能列表
    /// </summary>
    /// <param name="typeID">系统类型ID</param>
    /// <returns></returns>
    List<Menu> GetFunctions(long typeID);

    /// <summary>
    /// 根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限
    /// </summary>
    /// <param name="enCode">菜单功能编码</param>
    /// <returns></returns>
    Task<IEnumerable<MenuOutputDto>> GetListByParentEnCode(string enCode);

    /// <summary>
    /// 按条件批量删除
    /// </summary>
    /// <param name="ids">主键Id集合</param>
    /// <param name="trans">事务对象</param>
    /// <returns></returns>
    CommonResult DeleteBatchWhere(DeletesInputDto ids);
    /// <summary>
    /// 异步按条件批量删除
    /// </summary>
    /// <param name="ids">主键Id集合</param>
    /// <param name="trans">事务对象</param>
    /// <returns></returns>
    Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids);


    List<UserVisitMenus> GetFunctionsByUser(long userID, long typeID);

    /// <summary>
    /// 根据用户角色IDs，获取对应的功能列表
    /// </summary>
    /// <param name="systemId">系统类型ID/子系统ID</param>
    /// <returns></returns>
    List<UserVisitMenus> GetFunctionsBySystem(long systemId);

    List<VueRouterModel> GetVueRouter(string roleIds, string systemCode);
}
