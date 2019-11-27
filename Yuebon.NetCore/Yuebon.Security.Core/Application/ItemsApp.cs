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
    /// <summary>
    /// 
    /// </summary>
   public class ItemsApp
    {
        private IItemsRepository service = new ItemsRepository();
        /// <summary>
        /// 树形展开treeview需要,数据字典管理页面
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> ItemsTreeViewJson()
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<Items> listFunction = service.GetAll().OrderBy(t => t.SortCode).ToList();
            list = TreeViewJson(listFunction, "");
            return list;
        }

        public List<TreeViewModel> TreeViewJson(List<Items> data, string parentId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Items entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                //treeViewModel.icon = string.IsNullOrEmpty(entity.Icon) ? "far fa-circle" : entity.Icon;
                treeViewModel.nodes = ChildrenTreeViewList(data, entity.Id);
                treeViewModel.tags = entity.Id;
                list.Add(treeViewModel);
            }
            return list;
        }
        public List<TreeViewModel> ChildrenTreeViewList(List<Items> data, string parentId)
        {
            List<TreeViewModel> listChildren = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Items entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                //treeViewModel.icon = string.IsNullOrEmpty(entity.Icon) ? "far fa-circle" : entity.Icon;
                treeViewModel.nodes = ChildrenTreeViewList(data, entity.Id);
                treeViewModel.tags = entity.Id;
                listChildren.Add(treeViewModel);
            }
            return listChildren;
        }

    }
}
