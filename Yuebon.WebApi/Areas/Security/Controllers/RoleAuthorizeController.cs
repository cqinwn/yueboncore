using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Newtonsoft.Json;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Security.Application;
using System.Linq;
using Yuebon.AspNetCore.UI;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleAuthorizeController : AreaApiController<RoleAuthorize, RoleAuthorizeOutputDto, RoleAuthorizeInputDto, IRoleAuthorizeService,string>
    {
        private readonly IMenuService menuService;
        private readonly IFunctionService functionService;
        private readonly IRoleDataService roleDataService;
        private readonly IOrganizeService organizeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_menuService"></param>
        /// <param name="_functionService"></param>
        /// <param name="_roleDataService"></param>
        /// <param name="_organizeService"></param>
        public RoleAuthorizeController(IRoleAuthorizeService _iService, IMenuService _menuService, IFunctionService _functionService, IRoleDataService _roleDataService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            menuService = _menuService;
            functionService = _functionService;
            roleDataService = _roleDataService;
            organizeService = _organizeService;
            AuthorizeKey.ListKey = "RoleAuthorize/List";
            AuthorizeKey.InsertKey = "RoleAuthorize/Add";
            AuthorizeKey.UpdateKey = "RoleAuthorize/Edit";
            AuthorizeKey.UpdateEnableKey = "RoleAuthorize/Enable";
            AuthorizeKey.DeleteKey = "RoleAuthorize/Delete";
            AuthorizeKey.DeleteSoftKey = "RoleAuthorize/DeleteSoft";
            AuthorizeKey.ViewKey = "RoleAuthorize/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(RoleAuthorize info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(RoleAuthorize info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(RoleAuthorize info)
        {
        }

        /// <summary>
        /// 角色分配权限树
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        [HttpGet("GetRoleAuthorizeFunction")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetRoleAuthorizeFunction(string roleId,int itemType)
        {
            CommonResult result = new CommonResult();
            roleId = "'" + roleId + "'";
            List<string> resultlist = new List<string>();
            IEnumerable<RoleAuthorize> list= iService.GetListRoleAuthorizeByRoleId(roleId, itemType);
            foreach(RoleAuthorize info in list)
            {
                resultlist.Add(info.ItemId);
            }
            result.ResData = resultlist;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }


        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="search">功能权限</param>
        /// <returns></returns>
        [HttpPost("SaveRoleAuthorize")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> SaveRoleAuthorize(RoleAuthorizeDataInputDto roleinfo)
        {
            CommonResult result = new CommonResult();
            try
            {
                
                List<RoleAuthorize> inList = new List<RoleAuthorize>();
                List<ModuleFunctionOutputDto> list = roleinfo.RoleFunctios.ToList<ModuleFunctionOutputDto>();
                foreach (ModuleFunctionOutputDto item in list)
                {
                    RoleAuthorize info = new RoleAuthorize();
                    info.ObjectId = roleinfo.RoleId;
                    info.ItemType = 1;
                    info.ObjectType = 1;
                    info.ItemId = item.Id.ToString();
                    OnBeforeInsert(info);
                    inList.Add(info);
                }

                List<RoleData> roleDataList = new List<RoleData>();
                List<OrganizeOutputDto> listRoleData = roleinfo.RoleData.ToList<OrganizeOutputDto>();
                foreach (OrganizeOutputDto item in listRoleData)
                {
                    RoleData info = new RoleData();
                    info.RoleId = roleinfo.RoleId;
                    info.AuthorizeData = item.Id;
                    info.DType = "dept";
                    roleDataList.Add(info);
                }
                List<SystemTypeOutputDto> listRoleSystem = roleinfo.RoleSystem.ToList<SystemTypeOutputDto>();
                foreach (SystemTypeOutputDto item in listRoleSystem)
                {
                    RoleAuthorize info = new RoleAuthorize();
                    info.ObjectId = roleinfo.RoleId;
                    info.ItemType = 0;
                    info.ObjectType = 1;
                    info.ItemId = item.Id.ToString();
                    OnBeforeInsert(info);
                    inList.Add(info);
                }
                result.Success = await iService.SaveRoleAuthorize(roleinfo.RoleId,inList, roleDataList);
                if (result.Success)
                {
                    result.ErrCode = ErrCode.successCode;
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        private List<RoleAuthorize> SubFunction(List<ModuleFunctionOutputDto> list, string roleId)
        {
            List<RoleAuthorize> inList = new List<RoleAuthorize>();
            foreach (ModuleFunctionOutputDto item in list)
            {
                RoleAuthorize info = new RoleAuthorize();
                info.ObjectId = roleId;
                //if (item.FunctionTag == "S")
                //{
                //    info.ItemType = 0;
                //}
                //else
                //{
                //    
                //}
                info.ItemType = 1;
                info.ObjectType = 1;
                info.ItemId = item.Id.ToString();
                OnBeforeInsert(info);
                inList.Add(info);
                inList.Concat(SubFunction(item.Children, roleId));
            }
            return inList;
        }

        /// <summary>
        /// 获取功能菜单适用于Vue Tree树形
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllFunctionTree")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllFunctionTree()
        {
            CommonResult result = new CommonResult();
            try
            {
                List<ModuleFunctionOutputDto> list = await iService.GetAllFunctionTree();
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ResData = list;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取菜单异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 获取功能菜单适用于Vue 树形列表
        /// </summary>
        /// <param name="systemTypeId">子系统Id</param>
        /// <returns></returns>
        [HttpGet("GetAllFunctionTreeTable")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllFunctionTreeTable(string systemTypeId)
        {
            CommonResult result = new CommonResult();
            try
            {
                List<FunctionTreeTableOutputDto> list = await functionService.GetAllFunctionTreeTable(systemTypeId);
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ResData = list;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取菜单异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }
    }
}