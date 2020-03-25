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
    /// 操作轨迹表接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class OperateTrajectoryController : AreaApiController<OperateTrajectory, OperateTrajectoryOutputDto, IOperateTrajectoryService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public OperateTrajectoryController(IOperateTrajectoryService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "OperateTrajectory/List";
            AuthorizeKey.InsertKey = "OperateTrajectory/Add";
            AuthorizeKey.UpdateKey = "OperateTrajectory/Edit";
            AuthorizeKey.UpdateEnableKey = "OperateTrajectory/Enable";
            AuthorizeKey.DeleteKey = "OperateTrajectory/Delete";
            AuthorizeKey.DeleteSoftKey = "OperateTrajectory/DeleteSoft";
            AuthorizeKey.ViewKey = "OperateTrajectory/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(OperateTrajectory info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(OperateTrajectory info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(OperateTrajectory info)
        {
        }
    }
}