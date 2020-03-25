using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;
using Yuebon.WebApp.Models;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class WorkOrderController : BusinessController<WorkOrder, WorkOrderOutputDto, IWorkOrderService, string>
    {
        public WorkOrderController(IWorkOrderService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.InsertKey = "WorkOrder/Add";
            AuthorizeKey.UpdateKey = "WorkOrder/Edit";
            AuthorizeKey.DeleteKey = "WorkOrder/Delete";
            AuthorizeKey.UpdateEnableKey = "WorkOrder/Enable";
            AuthorizeKey.ListKey = "WorkOrder/List";
            AuthorizeKey.ViewKey = "WorkOrder/View";
            AuthorizeKey.DeleteSoftKey = "SystemType/DeleteSoft";
        }


        protected override void OnBeforeInsert(WorkOrder info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;
            info.Status = "0";
            if (string.IsNullOrEmpty(info.Mobile))
            {
                info.Mobile = CurrentUser.MobilePhone;
            }
            if (!string.IsNullOrEmpty(info.SecretContent))
            {
                info.SecretContent = DEncrypt.Encrypt(info.SecretContent);
            }
            info.Title = CurrentUser.Account;

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(WorkOrder info)
        {
            //留给子类对参数对象进行修改
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            if (!string.IsNullOrEmpty(info.SecretContent))
            {
                info.SecretContent = DEncrypt.Encrypt(info.SecretContent);
            }
        }

        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override IActionResult GetById(string id)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ViewKey);
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id).MapTo<WorkOrderOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type, "获取工单异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Id" : Request.Query["sort"].ToString();
            string where = GetPagerCondition();
            bool order = orderByDir == "desc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (Title like '%{0}%' or Description like '%{0}%')", keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<WorkOrderOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<WorkOrderOutputDto>();
           // List<WorkOrderOutputDto> resultList = list.ToListOutput<WorkOrder,WorkOrderOutputDto>();
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }

        /// <summary>
        /// 设置处理状态
        /// </summary>
        /// <param name="id">主键Id</param>
        [HttpPost]
        public IActionResult SetStatus1ByIds(string ids)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized("WorkOrder/SetStatusByIds");
            CommonResult result = new CommonResult();
            bool blresut =new WorkOrderApp().SetStatusByIds(ids);
            if (blresut)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

    }
}