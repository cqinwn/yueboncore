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
using Yuebon.AspNetCore.Mvc;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 角色数据权限接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleDataController : AreaApiController<RoleData, RoleDataOutputDto, RoleDataInputDto, IRoleDataService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public RoleDataController(IRoleDataService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(RoleData info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(RoleData info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(RoleData info)
        {
        }


        /// <summary>
        /// 角色可以访问数据
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        [HttpGet("GetAllRoleDataByRoleId")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllRoleDataByRoleId(string roleId)
        {
            CommonResult result = new CommonResult();
            string where = string.Format("RoleId='{0}'", roleId); 
            List<long> resultlist = new List<long>();
            IEnumerable<RoleData> list =await iService.GetListWhereAsync(where);
            foreach (RoleData info in list)
            {
                resultlist.Add(info.AuthorizeData);
            }
            result.ResData = resultlist;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
    }
}