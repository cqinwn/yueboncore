using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Tree;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Application
{
    public class RoleDataApp
    {

        IOrganizeService service = IoCContainer.Resolve<IOrganizeService>();
        IRoleDataService roleDataService = IoCContainer.Resolve<IRoleDataService>();
        IRoleService roleService = IoCContainer.Resolve<IRoleService>();
        IUserService userService = IoCContainer.Resolve<IUserService>();

        public RoleData GetId(string roleId)
        {
            string where = string.Format("RoleId='{0}'", roleId);
            return roleDataService.GetWhere(where);
        }
        /// <summary>
        /// 获取用户所属角色对应的数据权限集合
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<RoleData> FindByUser(string userId)
        {
            //获取用户信息
            User user = userService.Get(userId);
            //获取用户包含的角色
            string[] roleIds = user.RoleId.Split(',');
            List<string> roleList = new List<string>();
            for (int i= 0;i < roleIds.Length;i++)
            {
                roleList.Add(roleIds[i]);
            }

            //根据角色获取对应的数据权限集合
            List<RoleData> list = new List<RoleData>();
            foreach (string roleId in roleList)
            {
                string where = string.Format("RoleId='{0}'", roleId);
                RoleData info = roleDataService.GetWhere(where);
                if (info != null)
                {
                    #region 替换所在部门和所在公司的值
                    if (!string.IsNullOrEmpty(info.BelongCompanys))
                    {
                        //不重复出现的公司列表
                        List<string> notDuplicatedCompanyList = new List<string>();

                        List<string> companyList = info.BelongCompanys.Split(',').ToList();
                        for (int i = 0; i < companyList.Count; i++)
                        {
                            if (!notDuplicatedCompanyList.Contains(companyList[i]))
                            {
                                notDuplicatedCompanyList.Add(companyList[i]);
                            }
                        }
                        info.BelongCompanys = string.Join(",", notDuplicatedCompanyList);
                    }
                    if (!string.IsNullOrEmpty(info.BelongDepts))
                    {
                        //不重复出现的部门列表
                        List<string> notDuplicatedDeptList = new List<string>();

                        List<string> deptList = info.BelongDepts.Split(',').ToList();
                        for (int i = 0; i < deptList.Count; i++)
                        {

                            if (!notDuplicatedDeptList.Contains(deptList[i]))
                            {
                                notDuplicatedDeptList.Add(deptList[i]);
                            }
                        }

                        info.BelongDepts = string.Join(",", deptList);
                    }
                    #endregion

                    list.Add(info);
                }
            }
            return list;
        }
        /// <summary>
        /// 机构树形treeview需要,角色分配权限时需要
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> OrganizeTreeViewJson(string roleId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<RoleData> authorizedata = new List<RoleData>();
            if (!string.IsNullOrEmpty(roleId))
            {
                string sqlWhere = string.Format("RoleId='{0}'", roleId);
                RoleData roleData = roleDataService.GetWhere(sqlWhere);
                if (roleData != null)
                {
                    if (!string.IsNullOrEmpty(roleData.BelongCompanys))
                    {
                        string[] ids = roleData.BelongCompanys.Split(',');
                        for (int i = 0; i < ids.Length; i++)
                        {
                            RoleData roleDataInfo = new RoleData();
                            roleDataInfo.BelongCompanys = ids[i];
                            authorizedata.Add(roleDataInfo);
                        }
                    }
                    if (!string.IsNullOrEmpty(roleData.BelongDepts))
                    {
                        string[] ids = roleData.BelongDepts.Split(',');
                        for (int i = 0; i < ids.Length; i++)
                        {
                            RoleData roleDataInfo = new RoleData();
                            roleDataInfo.BelongCompanys = ids[i];
                            authorizedata.Add(roleDataInfo);
                        }
                    }
                }
            }
            List<Organize> listOrganize = service.GetListWhere().OrderBy(t => t.SortCode).ToList();
            list = TreeViewJson(listOrganize, authorizedata, "");
            return list;
        }

        public List<TreeViewModel> TreeViewJson(List<Organize> data, List<RoleData> authorizedata, string parentId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Organize entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.nodes = ChildrenTreeViewList(data, authorizedata, entity.Id);
                treeViewModel.tags = entity.Id;
                TreeViewSateModel treeViewSateModel = new TreeViewSateModel();
                treeViewSateModel.@checked = authorizedata.Count(t => t.BelongCompanys == entity.Id) == 0 ? false : true;
                treeViewSateModel.expanded = true;
                treeViewModel.state = treeViewSateModel;
                list.Add(treeViewModel);
            }
            return list;
        }
        public List<TreeViewModel> ChildrenTreeViewList(List<Organize> data, List<RoleData> authorizedata, string parentId)
        {
            List<TreeViewModel> listChildren = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Organize entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.nodes = ChildrenTreeViewList(data, authorizedata, entity.Id);
                treeViewModel.tags = entity.Id;
                TreeViewSateModel treeViewSateModel = new TreeViewSateModel();
                treeViewSateModel.@checked = authorizedata.Count(t => t.BelongCompanys == entity.Id) == 0 ? false : true;
                treeViewSateModel.expanded = true;
                treeViewModel.state = treeViewSateModel;
                listChildren.Add(treeViewModel);
            }
            return listChildren;
        }
    }
}
