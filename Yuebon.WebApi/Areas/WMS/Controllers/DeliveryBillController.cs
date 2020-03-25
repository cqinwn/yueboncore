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
    /// 出库发运单主表接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class DeliveryBillController : AreaApiController<DeliveryBill, DeliveryBillOutputDto, IDeliveryBillService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public DeliveryBillController(IDeliveryBillService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "DeliveryBill/List";
            AuthorizeKey.InsertKey = "DeliveryBill/Add";
            AuthorizeKey.UpdateKey = "DeliveryBill/Edit";
            AuthorizeKey.UpdateEnableKey = "DeliveryBill/Enable";
            AuthorizeKey.DeleteKey = "DeliveryBill/Delete";
            AuthorizeKey.DeleteSoftKey = "DeliveryBill/DeleteSoft";
            AuthorizeKey.ViewKey = "DeliveryBill/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(DeliveryBill info)
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
        protected override void OnBeforeUpdate(DeliveryBill info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(DeliveryBill info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
    }
}