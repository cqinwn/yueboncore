using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class SystemTypeController : BusinessController<SystemType, ISystemTypeService>
    {
        public SystemTypeController(ISystemTypeService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "SystemType/Add";
            AuthorizeKey.UpdateKey = "SystemType/Edit";
            AuthorizeKey.DeleteKey = "SystemType/Delete";
            AuthorizeKey.UpdateEnableKey = "SystemType/Enable";
            AuthorizeKey.ListKey = "SystemType/List";
            AuthorizeKey.ViewKey = "SystemType/View";
            AuthorizeKey.DeleteSoftKey = "SystemType/DeleteSoft";
        }

        protected override void OnBeforeInsert(SystemType info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;
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
        protected override void OnBeforeUpdate(SystemType info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            //base.CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SortCode" : Request.Query["sort"].ToString();
            string where = "";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" FullName like '%{0}%' or EnCode like '%{0}%'", keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<SystemTypeOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<SystemTypeOutputDto>();

            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
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
                result.ResData = iService.Get(id).MapTo<SystemTypeOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// select2 选择
        /// </summary>
        /// <returns></returns>
        public IActionResult FindTreeSelectJson()
        {
            List<SystemType> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();
            var treeList = new List<TreeSelectModel>();
            foreach (SystemType item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = "";
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }
    }
}