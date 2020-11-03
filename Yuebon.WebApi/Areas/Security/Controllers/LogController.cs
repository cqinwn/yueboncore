using Microsoft.AspNetCore.Mvc;
using System;
using Yuebon.AspNetCore.Controllers;
using Yuebon.Commons.Helpers;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 日志接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class LogController : AreaApiController<Log, LogOutputDto, LogInputDto, ILogService, string>
    {

        private IOrganizeService organizeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_organizeService"></param>
        public LogController(ILogService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;

            AuthorizeKey.ListKey = "Log/List";
            AuthorizeKey.InsertKey = "Log/Add";
            AuthorizeKey.UpdateKey = "Log/Edit";
            AuthorizeKey.UpdateEnableKey = "Log/Enable";
            AuthorizeKey.DeleteKey = "Log/Delete";
            AuthorizeKey.DeleteSoftKey = "Log/DeleteSoft";
            AuthorizeKey.ViewKey = "Log/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Log info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Log info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Log info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
    }
}