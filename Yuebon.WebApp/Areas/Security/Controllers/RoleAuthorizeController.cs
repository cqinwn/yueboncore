using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.Commons.Tree;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Models;
using Yuebon.Commons.Helpers;
using Yuebon.WebApp.Areas.Security.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class RoleAuthorizeController : BusinessController<RoleAuthorize, RoleAuthorizeOutputDto, IRoleAuthorizeService, string>
    {
        private IMenuService menuService;
        private IFunctionService functionService;
        private IRoleDataService roleDataService;
        private IOrganizeService organizeService;
        public RoleAuthorizeController(IRoleAuthorizeService _iService, IMenuService _menuService, IFunctionService _functionService, IRoleDataService _roleDataService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            menuService = _menuService;
            functionService = _functionService;
            roleDataService = _roleDataService;
            organizeService = _organizeService;
        }


        protected override void OnBeforeInsert(RoleAuthorize info)
        {
            //留给子类对参数对象进行修改

            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="nodeIds">功能权限</param>
        /// <param name="dataIds">数据权限</param>
        /// <param name="roleId">角色</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveRoleAuthorize(string nodeIds, string dataIds, string roleId)
        {
            CheckAuthorized("Role/SetAuthorize");
            CommonResult result = new CommonResult();
            try
            {
                string where = string.Format("ObjectId='{0}'", roleId);
                iService.DeleteBatchWhere(where);
                where = string.Format("RoleId='{0}'", roleId);
                roleDataService.DeleteBatchWhere(where);
                if (!string.IsNullOrEmpty(nodeIds))
                {
                    string[] ids = nodeIds.Split(',');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ids[i]))
                        {
                            string[] id = ids[i].Split(':');

                            RoleAuthorize info = new RoleAuthorize();
                            info.ObjectId = roleId;
                            if (id[1].ToString() == "0")
                            {
                                info.ItemType = 0;
                            }
                            else
                            {
                                info.ItemType = 1;
                            }
                            info.ObjectType = 1;
                            info.ItemId = id[0].ToString();
                            OnBeforeInsert(info);
                            iService.Insert(info);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(dataIds))
                {
                    string belongCompanys = string.Empty;
                    string belongDepts = string.Empty;
                    string[] ids = dataIds.Split(',');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ids[i]))
                        {
                            Organize organize = organizeService.Get(ids[i]);
                            if (organize.CategoryId == "Company" || organize.CategoryId == "Group")
                            {
                                belongCompanys += ids[i] + ",";
                            }
                            else if (organize.CategoryId == "Department" || organize.CategoryId == "WorkGroup")
                            {
                                belongDepts += ids[i] + ",";
                            }
                        }
                    }

                    RoleData roleData = new RoleData();
                    roleData.Id = GuidUtils.CreateNo();
                    roleData.RoleId = roleId;
                    if (!string.IsNullOrEmpty(belongCompanys))
                    {
                        roleData.BelongCompanys = belongCompanys.Substring(0, belongCompanys.Length - 1);
                    }
                    if (!string.IsNullOrEmpty(belongDepts))
                    {
                        roleData.BelongDepts = belongDepts.Substring(0, belongDepts.Length - 1);
                    }
                    roleDataService.Insert(roleData);
                }
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 角色分配权限树
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IActionResult GetPermissionTree(string roleId)
        {
            RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
            return ToJsonContent(roleAuthorizeApp.FuntionTreeViewJson(roleId));
        }
    }
}