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
    /// 商操作轨迹明细表接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class OperateTrajectoryDetailController : AreaApiController<OperateTrajectoryDetail, OperateTrajectoryDetailOutputDto, IOperateTrajectoryDetailService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public OperateTrajectoryDetailController(IOperateTrajectoryDetailService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "OperateTrajectoryDetail/List";
            AuthorizeKey.InsertKey = "OperateTrajectoryDetail/Add";
            AuthorizeKey.UpdateKey = "OperateTrajectoryDetail/Edit";
            AuthorizeKey.UpdateEnableKey = "OperateTrajectoryDetail/Enable";
            AuthorizeKey.DeleteKey = "OperateTrajectoryDetail/Delete";
            AuthorizeKey.DeleteSoftKey = "OperateTrajectoryDetail/DeleteSoft";
            AuthorizeKey.ViewKey = "OperateTrajectoryDetail/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(OperateTrajectoryDetail info)
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
        protected override void OnBeforeUpdate(OperateTrajectoryDetail info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(OperateTrajectoryDetail info)
        {
        }
    }
}