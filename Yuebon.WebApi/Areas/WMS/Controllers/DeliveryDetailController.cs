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
    /// 发运单明细表接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class DeliveryDetailController : AreaApiController<DeliveryDetail, DeliveryDetailOutputDto, IDeliveryDetailService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public DeliveryDetailController(IDeliveryDetailService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "DeliveryDetail/List";
            AuthorizeKey.InsertKey = "DeliveryDetail/Add";
            AuthorizeKey.UpdateKey = "DeliveryDetail/Edit";
            AuthorizeKey.UpdateEnableKey = "DeliveryDetail/Enable";
            AuthorizeKey.DeleteKey = "DeliveryDetail/Delete";
            AuthorizeKey.DeleteSoftKey = "DeliveryDetail/DeleteSoft";
            AuthorizeKey.ViewKey = "DeliveryDetail/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(DeliveryDetail info)
        {
            info.Id = GuidUtils.CreateNo();
            
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(DeliveryDetail info)
        {
            //info.LastModifyUserId = CurrentUser.UserId;
            //info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(DeliveryDetail info)
        {
            //info.DeleteMark = true;
            //info.DeleteTime = DateTime.Now;
            //info.DeleteUserId = CurrentUser.UserId;
        }
    }
}