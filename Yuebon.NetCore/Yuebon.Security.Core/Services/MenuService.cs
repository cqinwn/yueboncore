using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuService: BaseService<Menu, MenuOutputDto>, IMenuService
    {
        private readonly IMenuRepository _MenuRepository;
        private readonly IUserRepository userRepository;
        private readonly ISystemTypeRepository systemTypeRepository;
        private readonly IRoleAuthorizeRepository roleAuthorizeRepository;
        private readonly ILogService _logService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="_userRepository"></param>
        /// <param name="_roleAuthorizeRepository"></param>
        /// <param name="_systemTypeRepository"></param>
        /// <param name="logService"></param>
        public MenuService(IMenuRepository menuRepository,IUserRepository _userRepository, IRoleAuthorizeRepository _roleAuthorizeRepository, ISystemTypeRepository _systemTypeRepository, ILogService logService)
        {
            repository=menuRepository;
            _MenuRepository = menuRepository;
            userRepository = _userRepository;
            roleAuthorizeRepository = _roleAuthorizeRepository;
            systemTypeRepository = _systemTypeRepository;
            _logService = logService;
        }

        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<Menu> GetMenuByUser(long userId)
        {
            List<Menu> result = new List<Menu>();
            List<Menu> allMenuls = new List<Menu>();
            List<Menu> subMenuls = new List<Menu>();
            string where = string.Format("Layers=1");
            IEnumerable<Menu> allMenus = _MenuRepository.GetAllByIsNotDeleteAndEnabledMark();
            allMenuls = allMenus.ToList();
            
            var user = userRepository.Get(userId);
            if (user == null)
                return result;
            var userRoles = user.RoleId;
            where = string.Format("ItemType = 1 and ObjectType = 1 and ObjectId='{0}'",userRoles);
            var Menus = roleAuthorizeRepository.GetListWhere(where);
            foreach (RoleAuthorize item in Menus)
            {
                Menu MenuEntity = allMenuls.Find(t => t.Id == item.ItemId);
                if (MenuEntity != null)
                {
                    result.Add(MenuEntity);
                }
            }
            return result.OrderBy(t => t.SortCode).ToList();
        }


        /// <summary>
        /// 获取功能菜单适用于Vue 树形列表
        /// </summary>
        /// <param name="systemTypeId">子系统Id</param>
        /// <returns></returns>
        public async Task<List<MenuTreeTableOutputDto>> GetAllMenuTreeTable(long systemTypeId)
        {
            string where = "1=1";
            List<MenuTreeTableOutputDto> reslist = new List<MenuTreeTableOutputDto>();
            if (!string.IsNullOrEmpty(systemTypeId.ToString()))
            {
                IEnumerable<Menu> elist = await _MenuRepository.GetListWhereAsync("SystemTypeId=" + systemTypeId);
                List<Menu> list = elist.OrderBy(t => t.SortCode).ToList();
                List<Menu> oneMenuList = list.FindAll(t => t.ParentId == 0);
                foreach (Menu item in oneMenuList)
                {
                    MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();

                    menuTreeTableOutputDto = item.MapTo<MenuTreeTableOutputDto>();
                    menuTreeTableOutputDto.Id = item.Id;
                    menuTreeTableOutputDto.FullName = item.FullName;
                    menuTreeTableOutputDto.EnCode = item.EnCode;
                    menuTreeTableOutputDto.UrlAddress = item.UrlAddress;
                    menuTreeTableOutputDto.EnabledMark = item.EnabledMark;
                    menuTreeTableOutputDto.Children = GetSubMenus(list, item.Id).ToList<MenuTreeTableOutputDto>();
                    reslist.Add(menuTreeTableOutputDto);
                }

            }
            else
            {
                IEnumerable<SystemType> listSystemType = await systemTypeRepository.GetListWhereAsync(where);

                foreach (SystemType systemType in listSystemType)
                {
                    MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();
                    menuTreeTableOutputDto.Id = systemType.Id;
                    menuTreeTableOutputDto.FullName = systemType.FullName;
                    menuTreeTableOutputDto.EnCode = systemType.EnCode;
                    menuTreeTableOutputDto.UrlAddress = systemType.Url;
                    menuTreeTableOutputDto.EnabledMark = systemType.EnabledMark;

                    menuTreeTableOutputDto.SystemTag = true;

                    IEnumerable<Menu> elist = await _MenuRepository.GetListWhereAsync("SystemTypeId=" + systemType.Id);
                    if (elist.Count() > 0)
                    {
                        List<Menu> list = elist.OrderBy(t => t.SortCode).ToList();
                        menuTreeTableOutputDto.Children = GetSubMenus(list, 0).ToList<MenuTreeTableOutputDto>();
                    }
                    reslist.Add(menuTreeTableOutputDto);
                }
            }
            return reslist;
        }


        /// <summary>
        /// 获取子菜单，递归调用
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        private List<MenuTreeTableOutputDto> GetSubMenus(List<Menu> data, long parentId)
        {
            List<MenuTreeTableOutputDto> list = new List<MenuTreeTableOutputDto>();
            MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();
            var ChilList = data.FindAll(t => t.ParentId == parentId);
            foreach (Menu entity in ChilList)
            {
                menuTreeTableOutputDto = entity.MapTo<MenuTreeTableOutputDto>();
                menuTreeTableOutputDto.Children = GetSubMenus(data, entity.Id).OrderBy(t => t.SortCode).MapTo<MenuTreeTableOutputDto>();
                list.Add(menuTreeTableOutputDto);
            }
            return list;
        }

        /// <summary>
        /// 根据角色ID字符串（逗号分开)和系统类型ID，获取对应的操作功能列表
        /// </summary>
        /// <param name="roleIds">角色ID</param>
        /// <param name="typeID">系统类型ID</param>
        /// <param name="isMenu">是否是菜单</param>
        /// <returns></returns>
        public List<Menu> GetFunctions(string roleIds, long typeID,bool isMenu=false)
        {
            return _MenuRepository.GetFunctions(roleIds, typeID, isMenu).ToList();
        }


        /// <summary>
        /// 根据系统类型ID，获取对应的操作功能列表
        /// </summary>
        /// <param name="typeID">系统类型ID</param>
        /// <returns></returns>
        public List<Menu> GetFunctions(long typeID)
        {
            return _MenuRepository.GetFunctions(typeID).ToList();
        }


        /// <summary>
        /// 根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限
        /// </summary>
        /// <param name="enCode">菜单功能编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<MenuOutputDto>> GetListByParentEnCode(string enCode)
        {
            string where = string.Format("EnCode='{0}'", enCode);
            Menu function = await repository.GetWhereAsync(where);
            where = string.Format("ParentId='{0}'", function.ParentId);
            IEnumerable<Menu> list = await repository.GetAllByIsNotEnabledMarkAsync(where);
            return list.MapTo<MenuOutputDto>().ToList();
        }
        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="idsInfo">主键Id集合</param>
        /// <returns></returns>
        public CommonResult DeleteBatchWhere(DeletesInputDto idsInfo)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                if (idsInfo.Ids[0] != null)
                {
                    where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                    IEnumerable<Menu> list = _MenuRepository.GetListWhere(where);
                    if (list.Count()>0)
                    {
                        result.ErrMsg = "功能存在子集数据，不能删除";
                        return result;
                    }
                }
            }
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
            bool bl = repository.DeleteBatchWhere(where);
            if (bl)
            {
                result.ErrCode ="0";
            }
            return result;
        }

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="idsInfo">主键Id集合</param>
        /// <returns></returns>
        public async Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto idsInfo)
        {
            CommonResult result = new CommonResult();
            string where =string.Empty;
            for (int i =0;i< idsInfo.Ids.Length;i++)
            {
                if (idsInfo.Ids[0].ToString().Length>0)
                {
                    where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                    IEnumerable<Menu> list = _MenuRepository.GetListWhere(where);
                    if (list.Count()>0)
                    {
                        result.ErrMsg = "功能存在子集数据，不能删除";
                        return result;
                    }
                }
            }
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
            bool bl = await repository.DeleteBatchWhereAsync(where);
            if (bl)
            {
                result.ErrCode = "0";
            }
            return result;
        }
    }
}