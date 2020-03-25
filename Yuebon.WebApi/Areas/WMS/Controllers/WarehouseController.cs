using Microsoft.AspNetCore.Mvc;
using System;
using Yuebon.AspNetCore.Controllers;
using Yuebon.Commons.Helpers;
using Yuebon.WMS.Dtos;
using Yuebon.WMS.IServices;
using Yuebon.WMS.Models;

namespace Yuebon.WebApi.Areas.WMS.Controllers
{
    /// <summary>
    /// 仓库表接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class WarehouseController : AreaApiController<Warehouse, WarehouseOutputDto, IWarehouseService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public WarehouseController(IWarehouseService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "Warehouse/List";
            AuthorizeKey.InsertKey = "Warehouse/Add";
            AuthorizeKey.UpdateKey = "Warehouse/Edit";
            AuthorizeKey.UpdateEnableKey = "Warehouse/Enable";
            AuthorizeKey.DeleteKey = "Warehouse/Delete";
            AuthorizeKey.DeleteSoftKey = "Warehouse/DeleteSoft";
            AuthorizeKey.ViewKey = "Warehouse/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Warehouse info)
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
        protected override void OnBeforeUpdate(Warehouse info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Warehouse info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
    }
}