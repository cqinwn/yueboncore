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
using Yuebon.WMS.Dtos;
using Yuebon.WMS.Models;
using Yuebon.WMS.IServices;

namespace Yuebon.WebApi.Areas.WMS.Controllers
{
    /// <summary>
    /// 出库单主表接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class OutStockController : AreaApiController<OutStock, OutStockOutputDto, IOutStockService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public OutStockController(IOutStockService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "OutStock/List";
            AuthorizeKey.InsertKey = "OutStock/Add";
            AuthorizeKey.UpdateKey = "OutStock/Edit";
            AuthorizeKey.UpdateEnableKey = "OutStock/Enable";
            AuthorizeKey.DeleteKey = "OutStock/Delete";
            AuthorizeKey.DeleteSoftKey = "OutStock/DeleteSoft";
            AuthorizeKey.ViewKey = "OutStock/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(OutStock info)
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
        protected override void OnBeforeUpdate(OutStock info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(OutStock info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
    }
}