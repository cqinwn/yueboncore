using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.Security.Application
{
    public class FunctionApp
    {

        private IFunctionRepository service = new FunctionRepository();
        private ISystemTypeRepository serviceSystemType = new SystemTypeRepository();
        private IRoleRepository serviceRole = new RoleRepository();
        private IUserRepository serviceUser = new UserRepository();

        /// <summary>
        /// 系统功能树形展开treeview需要
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> FuntionTreeViewJson()
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<SystemType> systemTypeList = serviceSystemType.GetAll().OrderBy(t=>t.SortCode).ToList();
            foreach(SystemType item in systemTypeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = item.Id;
                treeViewModel.text = item.FullName;
                treeViewModel.icon = "fas fa-sitemap";
                string sqlwhere = string.Format("SystemTypeId='{0}'", item.Id);
                List<Function> listFunction = service.GetListWhere(sqlwhere).OrderBy(t => t.SortCode).ToList();
                treeViewModel.nodes = TreeViewJson(listFunction, "");
                treeViewModel.tags = item.Id;
                list.Add(treeViewModel);
            }
            
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeViewModel> TreeViewJson(List<Function> data, string parentId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Function entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.icon = string.IsNullOrEmpty(entity.Icon)? "far fa-circle" : entity.Icon;
                treeViewModel.nodes = ChildrenTreeViewList(data, entity.Id);
                treeViewModel.tags = entity.Id;
                list.Add(treeViewModel);
            }
            return list;
        }
        public List<TreeViewModel> ChildrenTreeViewList(List<Function> data, string parentId)
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
                treeViewModel.nodes = ChildrenTreeViewList(data, entity.Id);
                treeViewModel.tags = entity.Id;
                listChildren.Add(treeViewModel);
            }
            return listChildren;
        }

        /// <summary>
        /// 根据用户ID，获取对应的功能列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="typeID">系统类别ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsByUser(string userID, string typeID)
        {
            string where = string.Format("");
            string roleId = serviceUser.Get(userID).RoleId;
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("Role_Functions_" + roleId))
            {
                functions = JsonConvert.DeserializeObject<List<FunctionOutputDto>>(yuebonCacheHelper.Get("Role_Functions_" + roleId).ToJson());
            }
            else
            {
                string roleIDsStr = string.Format("'{0}'",roleId.Replace(",","','"));
                if (roleIDsStr != "")
                {
                    functions = service.GetFunctions(roleIDsStr, typeID).ToList().MapTo<FunctionOutputDto>();
                    //写入缓存
                    yuebonCacheHelper.Add("Role_Functions_" + roleId, functions);
                }
            }
            return functions;
        }

        /// <summary>
        /// 根据用户角色IDs，获取对应的功能列表
        /// </summary>
        /// <param name="roleIds">用户角色ID</param>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsByRole(string roleIds, string systemId)
        {
            string where = string.Format("");
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("Role_Functions_" + roleIds + systemId))
            {
                functions = JsonConvert.DeserializeObject<List<FunctionOutputDto>>(yuebonCacheHelper.Get("Role_Functions_" + roleIds + systemId).ToJson());
            }
            else
            {
                string roleIDsStr = string.Format("'{0}'", roleIds.Replace(",", "','"));
                if (roleIDsStr != "")
                {
                    functions = service.GetFunctions(roleIDsStr, systemId).ToList().MapTo<FunctionOutputDto>();
                    //写入缓存
                    yuebonCacheHelper.Add("Role_Functions_" + roleIds + systemId, functions);
                }
            }
            return functions;
        }
        /// <summary>
        ///获取超级管理员操作所有功能，
        /// </summary>
        /// <param name="roleId">超级管理员角色ID</param>
        /// <param name="typeID">系统类别ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsByAdmin(string roleId, string typeID)
        {
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("Role_Functions_" + roleId))
            {
                functions = JsonConvert.DeserializeObject<List<FunctionOutputDto>>(yuebonCacheHelper.Get("Role_Functions_" + roleId).ToJson());
            }
            else
            {
                functions = service.GetAll().ToList().MapTo<FunctionOutputDto>();
                //写入缓存
                yuebonCacheHelper.Add("Role_Functions_" + roleId, functions);
            }
            return functions;
        }

    }
}
