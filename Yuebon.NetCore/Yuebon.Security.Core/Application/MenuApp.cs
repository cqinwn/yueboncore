using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;
using Yuebon.Security.Services;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuApp
    {
        IMenuService service = App.GetService<IMenuService>();
        ISystemTypeService systemservice = App.GetService<ISystemTypeService>();
        IUserService serviceUser = App.GetService<IUserService>();
        /// <summary>
        /// 获取菜单树JsTree模式
        /// </summary>
        /// <returns></returns>
        public List<JsTreeModel> MenuFuntionJsTree()
        {
            List<JsTreeModel> list = new List<JsTreeModel>();

            List<Menu> listMenu = service.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();
            foreach (Menu item in listMenu)
            {
                JsTreeModel jsTreeModel = new JsTreeModel();
                jsTreeModel.id = item.Id;
                jsTreeModel.text = item.FullName;
                jsTreeModel.icon = item.Icon;
                jsTreeModel.parent = item.ParentId;
                JsTreeStateModel jsTreeStateModel = new JsTreeStateModel();
                jsTreeStateModel.disabled = false;
                jsTreeStateModel.selected = true;
                jsTreeStateModel.opened = true;
                jsTreeModel.state = jsTreeStateModel;
                list.Add(jsTreeModel);
            }
            return list.JsTreeJson();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<MenuInputDto> GetMenu(string parentId)
        {
            List<MenuInputDto> list = new List<MenuInputDto>();

            return list;
        }
        /// <summary>
        /// 获取菜单树TreeView模式
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> MenuFuntionTreeViewJson()
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<Menu> listMenu = service.GetAll().OrderBy(t => t.SortCode).ToList();
            list = JsTreeJson(listMenu, "", "").ToList<TreeViewModel>();
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <param name="blank"></param>
        /// <returns></returns>
        private static string JsTreeJson(List<Menu> data, string parentId, string blank)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            TreeViewModel jsTreeModel = new TreeViewModel();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId);
            var tabline = "";
            
            if (ChildNodeList.Count > 0)
            {
                tabline = tabline + blank;
            }
            foreach (Menu entity in ChildNodeList)
            {
                jsTreeModel.text = entity.FullName;
                jsTreeModel.icon = entity.Icon;
                //list.Add(jsTreeModel);
                jsTreeModel.nodes = JsTreeJson(data, entity.Id, tabline).ToList<TreeViewModel>();
                list.Add(jsTreeModel);
            }
            return list.ToJson().ToString();
        }


        /// <summary>
        /// 根据用户角色获取菜单树VuexMenusTree模式
        /// </summary>
        /// <param name="roleIds">角色ID</param>
        /// <param name="systemCode">系统类型代码子系统代码</param>
        /// <returns></returns>
        public List<MenuOutputDto> GetMenuFuntionJson(string roleIds, string systemCode)
        {
            List<MenuOutputDto> list = new List<MenuOutputDto>();
            try
            {
                SystemType systemType = systemservice.GetByCode(systemCode);
                list = GetMenusByRole(roleIds, systemType.Id).OrderBy(t => t.SortCode).MapTo<MenuOutputDto>();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("根据用户角色和子系统代码获取菜单异常", ex);
            }
            return list;
        }

        /// <summary>
        /// 根据用户角色获取菜单树VuexMenusTree模式
        /// </summary>
        /// <param name="systemCode">系统类型代码子系统代码</param>
        /// <returns></returns>
        public List<MenuOutputDto> GetMenuFuntionJson(string systemCode)
        {
            List<MenuOutputDto> list = new List<MenuOutputDto>();
            try
            {
                SystemType systemType = systemservice.GetByCode(systemCode);
                List<Menu> listMenu = GetMenusByRole(systemType.Id).OrderBy(t => t.SortCode).ToList();
                list = listMenu.MapTo<MenuOutputDto>();
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("根据用户角色和子系统代码获取菜单异常", ex);
            }
            return list;
        }

        /// <summary>
        /// 构建菜单树
        /// </summary>
        /// <param name="menus">菜单列表</param>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        public List<MenuOutputDto> BuildTreeMenus(List<Menu> menus,string parentId="")
        {
            List<MenuOutputDto> resultList = new List<MenuOutputDto>();
            List<Menu> childNodeList = menus.FindAll(t => t.ParentId == parentId);
            foreach (Menu menu in childNodeList)
            {
                MenuOutputDto menuOutputDto = new MenuOutputDto();
                menuOutputDto = menu.MapTo<MenuOutputDto>();
                List<Menu> subChildNodeList = menus.FindAll(t => t.ParentId == menu.Id);
                if (subChildNodeList.Count > 0)
                {
                    menuOutputDto.SubMenu = BuildTreeMenus(menus, menu.Id);
                }
                resultList.Add(menuOutputDto);
            }

            return resultList;
        }
        #region 获取 Vue Router
        /// <summary>
        /// 根据用户角色获取菜单树VueRouter模式
        /// </summary>
        /// <param name="roleIds">角色ID</param>
        /// <param name="systemCode">系统类型代码子系统代码</param>
        /// <returns></returns>
        public List<VueRouterModel> GetVueRouter(string roleIds, string systemCode)
        {
            List<VueRouterModel> list = new List<VueRouterModel>();
            try
            { 
                SystemType systemType = systemservice.GetByCode(systemCode);
                List<Menu> listMenu = GetMenusByRole(roleIds, systemType.Id).OrderBy(t => t.SortCode).ToList();
                List<MenuOutputDto> listTree= BuildTreeMenus(listMenu);
                list = BuildMenus(listTree);
                
            }
            catch(Exception ex)
            {
                Log4NetHelper.Error("根据用户角色和子系统代码获取菜单异常",ex);
            }
            return list;
        }
        /// <summary>
        /// 构建前端路由所需要的菜单
        /// </summary>
        /// <param name="menus">菜单列表</param>
        /// <returns></returns>
        public List<VueRouterModel> BuildMenus(List<MenuOutputDto> menus)
        {
            List<VueRouterModel> routers = new List<VueRouterModel>();
            foreach (MenuOutputDto menu in menus)
            {
                VueRouterModel router = new VueRouterModel();
                router.hidden = menu.IsShow?false:true;
                router.name = GetRouteName(menu);
                router.path = GetRouterPath(menu);
                router.component = GetComponent(menu);
                Meta meta=  new Meta(menu.FullName, menu.Icon == null ? "" : menu.Icon, menu.IsCache);
                if (!menu.IsShow && menu.MenuType.Contains("M"))
                {
                    meta.activeMenu = menu.ActiveMenu;
                }
                router.meta = meta;
                List<MenuOutputDto> cMenus = menu.SubMenu;
                if (cMenus!=null && menu.MenuType == "C")
                {
                    router.alwaysShow=true;
                    router.redirect="noRedirect";
                    router.children=BuildMenus(cMenus);
                }
                else if (IsMeunDoc(menu))
                {
                    List<VueRouterModel> childrenList = new List<VueRouterModel>();
                    VueRouterModel childrenRouter = new VueRouterModel();
                    childrenRouter.path = menu.UrlAddress;
                    childrenRouter.component=menu.Component;
                    childrenRouter.name=menu.EnCode;
                    childrenRouter.meta = new Meta(menu.FullName, menu.Icon == null ? "" : menu.Icon, menu.IsCache);
                    childrenRouter.meta = meta;
                    childrenList.Add(childrenRouter);
                    router.children=childrenList;
                }else if (IsMeunFrame(menu)&& cMenus != null)
                {
                    if (!menu.IsShow)
                    {
                        router.hidden = true;
                    }
                    router.children = BuildMenus(cMenus);
                }
                routers.Add(router);
            }

            return routers;
        }
        /// <summary>
        /// 获取路由名称
        /// </summary>
        /// <param name="menu">菜单信息</param>
        /// <returns></returns>
        public String GetRouteName(MenuOutputDto menu)
        {
            String routerName = menu.EnCode;
            // 非外链并且是一级目录（类型为目录）
            if (IsMeunDoc(menu))
            {
                routerName = "";
            }
            return routerName;
        }
        /// <summary>
        /// 获取路由地址
        /// </summary>
        /// <param name="menu">菜单信息</param>
        /// <returns></returns>
        public String GetRouterPath(MenuOutputDto menu)
        {
            String routerPath = menu.UrlAddress;
            // 非外链并且是一级目录（类型为目录）
            if ("" == menu.ParentId && menu.MenuType == "C"&&!menu.IsFrame)
            {
                routerPath = menu.UrlAddress;// "/" + menu.EnCode;
            }
            // 非外链并且是一级目录（类型为菜单）
            else if (IsMeunDoc(menu))
            {
                routerPath = "/";
            }
            return routerPath;
        }
        /// <summary>
        /// 获取组件信息
        /// </summary>
        /// <param name="menu">菜单信息</param>
        /// <returns></returns>
        public String GetComponent(MenuOutputDto menu)
        {
            String component = "Layout";
            if (!string.IsNullOrEmpty(menu.Component) && IsMeunFrame(menu)&&!IsMeunDoc(menu))
            {
                component = menu.Component;
            }
            else if (string.IsNullOrEmpty(menu.Component) && IsParentView(menu))
            {
                component = "ParentView";
            }
            return component;
        }
        /// <summary>
        /// 是否为菜单内部跳转,并且是一级目录
        /// </summary>
        /// <param name="menu">菜单信息</param>
        /// <returns></returns>
        public bool IsMeunDoc(MenuOutputDto menu)
        {
            return menu.ParentId == "" && menu.MenuType == "M" && !menu.IsFrame;
        }
        /// <summary>
        /// 是否为菜单内部跳转
        /// </summary>
        /// <param name="menu">菜单信息</param>
        /// <returns></returns>
        public bool IsMeunFrame(MenuOutputDto menu)
        {
            return menu.MenuType == "M" && !menu.IsFrame;
        }
        /// <summary>
        /// 是否为parent_view组件
        /// </summary>
        /// <param name="menu">菜单信息</param>
        /// <returns></returns>
        public bool IsParentView(MenuOutputDto menu)
        {
            return menu.ParentId != "" && menu.MenuType == "C";
        }
        #endregion
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="roleIds">用户角色ID</param>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<Menu> GetMenusByRole(string roleIds, string systemId)
        {
            List<Menu> menuListResult = new List<Menu>();
            if (roleIds == "")
            {
               menuListResult = service.GetFunctions("", systemId, true);
            }
            else
            {
                string roleIDsStr = string.Format("'{0}'", roleIds.Replace(",", "','"));
                menuListResult = service.GetFunctions(roleIDsStr, systemId, true);
            }
            return menuListResult;
        }


        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<Menu> GetMenusByRole(string systemId)
        {
            List<Menu> menuListResult = service.GetAllByIsNotDeleteAndEnabledMark("MenuType in ('M','C') and SystemTypeId='"+ systemId + "'").ToList();
            return menuListResult;
        }



        /// <summary>
        /// 根据用户ID，获取对应的功能列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="typeID">系统类别ID</param>
        /// <returns></returns>
        public List<MenuOutputDto> GetFunctionsByUser(string userID, string typeID)
        {
            string where = string.Format("");
            string roleId = serviceUser.Get(userID).RoleId;
            List<MenuOutputDto> functions = new List<MenuOutputDto>();
            string roleIDsStr = string.Format("'{0}'", roleId.Replace(",", "','"));
            if (roleIDsStr != "")
            {
                functions = service.GetFunctions(roleIDsStr, typeID).ToList().MapTo<MenuOutputDto>();
            }
            return functions;
        }
        /// <summary>
        /// 根据用户角色IDs，获取对应的功能列表
        /// </summary>
        /// <param name="roleIds">用户角色ID</param>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<MenuOutputDto> GetFunctionsByRole(string roleIds, string systemId)
        {
            string where = string.Format("");
            List<MenuOutputDto> functions = new List<MenuOutputDto>();
            string roleIDsStr = string.Format("'{0}'", roleIds.Replace(",", "','"));
            if (roleIDsStr != "")
            {
                functions = service.GetFunctions(roleIDsStr, systemId).ToList().MapTo<MenuOutputDto>();
            }
            return functions;
        }

        /// <summary>
        /// 根据用户角色IDs，获取对应的功能列表
        /// </summary>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<MenuOutputDto> GetFunctionsBySystem(string systemId)
        {
            List<MenuOutputDto> functions = new List<MenuOutputDto>();
            functions = service.GetFunctions(systemId).ToList().MapTo<MenuOutputDto>();
            return functions;
        }


    }
}
