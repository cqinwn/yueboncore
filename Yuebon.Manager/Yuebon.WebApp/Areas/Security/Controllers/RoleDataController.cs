using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class RoleDataController : BusinessController<RoleData, IRoleDataService>
    {
        public RoleDataController(IRoleDataService _iService) : base(_iService)
        {
            iService = _iService;
        }

        protected override void OnBeforeInsert(RoleData info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
        }

        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IActionResult GetById(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ViewKey);
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id).MapTo<RoleDataOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
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
            RoleDataApp roleAuthorizeApp = new RoleDataApp();
            return ToJsonContent(roleAuthorizeApp.OrganizeTreeViewJson(roleId));
        }
    }
}