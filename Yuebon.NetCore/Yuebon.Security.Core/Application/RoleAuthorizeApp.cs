using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Tree;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.Security.Application
{
    public class RoleAuthorizeApp
    {
        private IFunctionRepository service = new FunctionRepository();
        private ISystemTypeRepository serviceSystemType = new SystemTypeRepository();

        private IRoleAuthorizeRepository serviceRoleAuthorize = new RoleAuthorizeRepository();
        /// <summary>
        /// 系统功能树形treeview需要,角色分配权限时需要
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> FuntionTreeViewJson(string roleId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<RoleAuthorize> authorizedata = new List<RoleAuthorize>();
            if (!string.IsNullOrEmpty(roleId))
            {
                string sqlWhere = string.Format("ObjectId='{0}'", roleId);
                authorizedata = serviceRoleAuthorize.GetListWhere(sqlWhere).ToList();
            }
            List<SystemType> systemTypeList = serviceSystemType.GetAll().OrderBy(t => t.SortCode).ToList();
            foreach (SystemType item in systemTypeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = item.Id;
                treeViewModel.text = item.FullName;
                treeViewModel.icon = "fas fa-sitemap";
                string sqlwhere = string.Format("SystemTypeId='{0}'", item.Id);
                List<Function> listFunction = service.GetListWhere(sqlwhere).OrderBy(t => t.SortCode).ToList();
                treeViewModel.nodes = TreeViewJson(listFunction, authorizedata, "");
                TreeViewSateModel treeViewSateModel = new TreeViewSateModel();
                treeViewSateModel.@checked=authorizedata.Count(t => t.ItemId == item.Id) == 0 ? false : true;
                treeViewSateModel.expanded = true;
                treeViewModel.state = treeViewSateModel;
                treeViewModel.tags = item.Id;
                list.Add(treeViewModel);
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="authorizedata"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeViewModel> TreeViewJson(List<Function> data, List<RoleAuthorize> authorizedata,string parentId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Function entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.icon = string.IsNullOrEmpty(entity.Icon) ? "far fa-circle" : entity.Icon;
                treeViewModel.nodes = ChildrenTreeViewList(data, authorizedata, entity.Id);
                treeViewModel.tags = entity.Id;
                TreeViewSateModel treeViewSateModel = new TreeViewSateModel();
                treeViewSateModel.@checked = authorizedata.Count(t => t.ItemId == entity.Id) == 0 ? false : true;
                treeViewSateModel.expanded = true;
                treeViewModel.state = treeViewSateModel;
                list.Add(treeViewModel);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="authorizedata"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeViewModel> ChildrenTreeViewList(List<Function> data, List<RoleAuthorize> authorizedata, string parentId)
        {
            List<TreeViewModel> listChildren = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Function entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.icon = string.IsNullOrEmpty(entity.Icon) ? "far fa-circle" : entity.Icon;
                treeViewModel.nodes = ChildrenTreeViewList(data, authorizedata, entity.Id);
                treeViewModel.tags = entity.Id;
                TreeViewSateModel treeViewSateModel = new TreeViewSateModel();
                treeViewSateModel.@checked = authorizedata.Count(t => t.ItemId == entity.Id) == 0 ? false : true;
                treeViewSateModel.expanded = true;
                treeViewModel.state = treeViewSateModel;
                listChildren.Add(treeViewModel);
            }
            return listChildren;
        }
    }
}
