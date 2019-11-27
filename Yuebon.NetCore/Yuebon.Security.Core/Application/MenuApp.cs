using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Json;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.Security.Application
{
    public class MenuApp
    {
        private IMenuRepository service = new MenuRepository();

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

        public List<MenuOutputDto> GetMenu(string parentId)
        {
            List<MenuOutputDto> list = new List<MenuOutputDto>();

            return list;
        }
        public List<TreeViewModel> MenuFuntionTreeViewJson()
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<Menu> listMenu = service.GetAll().OrderBy(t => t.SortCode).ToList();
            
            list = JsTreeJson(listMenu, "", "").ToList<TreeViewModel>();
            return list;
        }

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
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
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
    }
}
