using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Extend;
using Yuebon.Commons.IoC;
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
        IMenuService service = IoCContainer.Resolve<IMenuService>();
        ISystemTypeService systemservice = IoCContainer.Resolve<ISystemTypeService>();
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
        public List<MenuInputDto> GetMenuFuntionJson(string roleIds, string systemCode)
        {
            List<MenuInputDto> list = new List<MenuInputDto>();
            try
            {
                SystemType systemType = systemservice.GetByCode(systemCode);
                List<Menu> listMenu = GetMenusByRole(roleIds, systemType.Id).OrderBy(t => t.SortCode).ToList();
                //var ChildNodeList = listMenu.FindAll(t => t.ParentId == "");
                //foreach (Menu menu in ChildNodeList)
                //{
                //    VuexMenusTreeModel vueTreeModel = new VuexMenusTreeModel();
                //    vueTreeModel.path = menu.UrlAddress;
                //    vueTreeModel.component = "Layout";
                //    vueTreeModel.name = menu.EnCode;
                //    vueTreeModel.redirect = menu.UrlAddress;
                //    Meta meta = new Meta();
                //    meta.title = menu.FullName;
                //    meta.icon = menu.Icon == null ? "" : menu.Icon;
                //    vueTreeModel.meta = meta;

                //    vueTreeModel.children = VuexMenusTreeJson(listMenu, menu.Id);
                //    list.Add(vueTreeModel);
                //}
                list =listMenu.MapTo<MenuInputDto>();
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
        /// <param name="roleIds">角色ID</param>
        /// <param name="systemCode">系统类型代码子系统代码</param>
        /// <returns></returns>
        public List<VuexMenusTreeModel> GetMenuFuntionVuexMenusTreeJson(string roleIds, string systemCode)
        {
            List<VuexMenusTreeModel> list = new List<VuexMenusTreeModel>();
            try
            { 
                SystemType systemType = systemservice.GetByCode(systemCode);
                List<Menu> listMenu = GetMenusByRole(roleIds, systemType.Id).OrderBy(t => t.SortCode).ToList();
                var ChildNodeList = listMenu.FindAll(t => t.ParentId == "");
                foreach (Menu menu in ChildNodeList)
                {
                    VuexMenusTreeModel vueTreeModel = new VuexMenusTreeModel();
                    vueTreeModel.path = menu.UrlAddress;
                    vueTreeModel.component = "Layout";
                    vueTreeModel.name = menu.EnCode;
                    vueTreeModel.redirect = menu.UrlAddress;
                    Meta meta = new Meta();
                    meta.title = menu.FullName;
                    meta.icon = menu.Icon == null ? "" : menu.Icon;
                    vueTreeModel.meta = meta;

                    vueTreeModel.children = VuexMenusTreeJson(listMenu, menu.Id);
                    list.Add(vueTreeModel);
                }
                //list = VuexMenusTreeJson(listMenu, "");
            }
            catch(Exception ex)
            {
                Log4NetHelper.Error("根据用户角色和子系统代码获取菜单异常",ex);
            }
            return list;
        }
        /// <summary>
        /// 将菜单数据转换VuexMenusTree模式Json格式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private static List<VuexMenusTreeModel> VuexMenusTreeJson(List<Menu> data, string parentId)
        {
            List<VuexMenusTreeModel> list = new List<VuexMenusTreeModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId);
            foreach (Menu entity in ChildNodeList)
            {
                VuexMenusTreeModel vueTreeModel = new VuexMenusTreeModel();
                vueTreeModel.path = entity.UrlAddress;
                vueTreeModel.component = "Layout";
                vueTreeModel.name = entity.EnCode;
                vueTreeModel.redirect = entity.UrlAddress;
                Meta meta = new Meta();
                meta.title = entity.FullName;
                meta.icon = entity.Icon==null?"": entity.Icon;
                vueTreeModel.meta = meta;

                vueTreeModel.children = VuexMenusTreeJson(data, entity.Id);
                list.Add(vueTreeModel);
            }
            return list;
        }
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="typeId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<Menu> GetMenuByUser(string userId,string typeId)
        {
            FunctionApp functionApp = new FunctionApp();
            List<FunctionOutputDto> functionList = functionApp.GetFunctionsByUser(userId, typeId);
            List<Menu> menuList = service.GetAllByIsNotDeleteAndEnabledMark().ToList();
            List<Menu> menuListResult = new List<Menu>();
            foreach(Menu item in menuList)
            {
                if (functionList.Count(t => t.EnCode ==item.EnCode)>0)
                {
                    menuListResult.Add(item);
                }
            }
            return menuListResult;
        }


        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="roleIds">用户角色ID</param>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<Menu> GetMenusByRole(string roleIds, string systemId)
        {
            FunctionApp functionApp = new FunctionApp();
            List<FunctionOutputDto> functionList = functionApp.GetFunctionsByRole(roleIds, systemId);
            List<Menu> menuList = service.GetAllByIsNotDeleteAndEnabledMark().ToList();
            List<Menu> menuListResult = new List<Menu>();
            foreach (Menu item in menuList)
            {
                if (functionList.Count(t => t.EnCode == item.EnCode) > 0)
                {
                    menuListResult.Add(item);
                }
            }
            return menuListResult;
        }
    }
}
