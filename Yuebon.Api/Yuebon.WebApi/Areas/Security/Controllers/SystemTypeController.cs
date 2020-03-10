using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 子系统接口
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class SystemTypeController : AreaApiController<SystemType, ISystemTypeService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public SystemTypeController(ISystemTypeService _iService) : base(_iService)
        {
            iService = _iService;
        }

        /// <summary>
        /// 获取可以切换的登录的应用子系统
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSubSystemList")]
        public IActionResult GetSubSystemList()
        {
            CommonResult result = new CommonResult();
            string roleIDsStr = string.Format("'{0}'", CurrentUser.Role.Replace(",", "','"));
            IEnumerable<RoleAuthorize> roleAuthorizes = new RoleAuthorizeApp().GetListRoleAuthorizeByRoleId(roleIDsStr, 0);

            string strWhere = " Id in (";
            foreach (RoleAuthorize item in roleAuthorizes)
            {
                strWhere += "'" + item.ItemId + "',";
            }
            strWhere = strWhere.Substring(0, strWhere.Length - 1) + ")";
            List<SystemTypeOutputDto> list = iService.GetAllByIsNotDeleteAndEnabledMark(strWhere).OrderBy(t => t.SortCode).ToList().MapTo<SystemTypeOutputDto>();
            result.ResData = list;
            result.Success = true;
            return ToJsonContent(result);
        }
    }
}