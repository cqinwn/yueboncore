using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Mapping;
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
    public class MenuService: BaseService<Menu, MenuOutputDto, string>, IMenuService
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
        /// <param name="logService"></param>
        public MenuService(IMenuRepository repository,IUserRepository _userRepository, IRoleAuthorizeRepository _roleAuthorizeRepository, ISystemTypeRepository _systemTypeRepository, ILogService logService) : base(repository)
        {
            _MenuRepository = repository;
            userRepository = _userRepository;
            roleAuthorizeRepository = _roleAuthorizeRepository;
            systemTypeRepository = _systemTypeRepository;
            _logService = logService;
            _MenuRepository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<Menu> GetMenuByUser(string userId)
        {
            List<Menu> result = new List<Menu>();
            List<Menu> allMenuls = new List<Menu>();
            List<Menu> subMenuls = new List<Menu>();
            string where = string.Format("Layers=1");
            IEnumerable<Menu> allMenus = _MenuRepository.GetAllByIsNotDeleteAndEnabledMark();
            allMenuls = allMenus.ToList();
            if (userId == string.Empty) //超级管理员
            {
                return allMenuls;
            }
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
        public async Task<List<MenuTreeTableOutputDto>> GetAllMenuTreeTable(string systemTypeId)
        {
            string where = "1=1";
            if (!string.IsNullOrEmpty(systemTypeId))
            {
                where = " Id='" + systemTypeId + "'";
            }
            IEnumerable<SystemType> listSystemType = await systemTypeRepository.GetListWhereAsync(where);
            List<MenuTreeTableOutputDto> reslist = new List<MenuTreeTableOutputDto>();
            foreach (SystemType systemType in listSystemType)
            {
                MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();
                menuTreeTableOutputDto.Id = systemType.Id;
                menuTreeTableOutputDto.FullName = systemType.FullName;
                menuTreeTableOutputDto.EnCode = systemType.EnCode;
                menuTreeTableOutputDto.UrlAddress = systemType.Url;
                menuTreeTableOutputDto.EnabledMark = systemType.EnabledMark;

                menuTreeTableOutputDto.SystemTag = true;

                IEnumerable<Menu> elist = await _MenuRepository.GetListWhereAsync("SystemTypeId='" + systemType.Id + "'");
                if (elist.Count() > 0)
                {
                    List<Menu> list = elist.OrderBy(t => t.SortCode).ToList();
                    menuTreeTableOutputDto.Children = GetSubMenus(list, "").ToList<MenuTreeTableOutputDto>();
                }
                reslist.Add(menuTreeTableOutputDto);
            }
            return reslist;
        }


        /// <summary>
        /// 获取子菜单，递归调用
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        private List<MenuTreeTableOutputDto> GetSubMenus(List<Menu> data, string parentId)
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
    }
}