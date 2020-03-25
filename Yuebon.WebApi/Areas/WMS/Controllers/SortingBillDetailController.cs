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
    /// 分拣明细接口
    /// </summary>
    [ApiController]
    [Route("api/WMS/[controller]")]
    public class SortingBillDetailController : AreaApiController<SortingBillDetail, SortingBillDetailOutputDto, ISortingBillDetailService, string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public SortingBillDetailController(ISortingBillDetailService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "SortingBillDetail/List";
            AuthorizeKey.InsertKey = "SortingBillDetail/Add";
            AuthorizeKey.UpdateKey = "SortingBillDetail/Edit";
            AuthorizeKey.UpdateEnableKey = "SortingBillDetail/Enable";
            AuthorizeKey.DeleteKey = "SortingBillDetail/Delete";
            AuthorizeKey.DeleteSoftKey = "SortingBillDetail/DeleteSoft";
            AuthorizeKey.ViewKey = "SortingBillDetail/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(SortingBillDetail info)
        {
            info.Id = GuidUtils.CreateNo();
            //info.CreatorTime = DateTime.Now;
            //info.CreatorUserId = CurrentUser.UserId;
            //info.DeleteMark = false;
            //if (info.SortCode == null)
            //{
            //    info.SortCode = 99;
            //}
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(SortingBillDetail info)
        {
            //info.LastModifyUserId = CurrentUser.UserId;
            //info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(SortingBillDetail info)
        {
            //info.DeleteMark = true;
            //info.DeleteTime = DateTime.Now;
            //info.DeleteUserId = CurrentUser.UserId;
        }
    }
}