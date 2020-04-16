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

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleAuthorizeController : AreaApiController<RoleAuthorize, RoleAuthorizeOutputDto, IRoleAuthorizeService,string>
    {
        private readonly IFunctionService functionService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_functionService"></param>
        public RoleAuthorizeController(IRoleAuthorizeService _iService, IFunctionService _functionService) : base(_iService)
        {
            iService = _iService;
            functionService = _functionService;
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


    }
}