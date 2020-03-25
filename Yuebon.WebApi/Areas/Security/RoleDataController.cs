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

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleDataController : AreaApiController<RoleData, RoleDataOutputDto, IRoleDataService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public RoleDataController(IRoleDataService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "RoleData/List";
            AuthorizeKey.InsertKey = "RoleData/Add";
            AuthorizeKey.UpdateKey = "RoleData/Edit";
            AuthorizeKey.UpdateEnableKey = "RoleData/Enable";
            AuthorizeKey.DeleteKey = "RoleData/Delete";
            AuthorizeKey.DeleteSoftKey = "RoleData/DeleteSoft";
            AuthorizeKey.ViewKey = "RoleData/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(RoleData info)
        {
            info.Id = GuidUtils.CreateNo();
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
    }
}