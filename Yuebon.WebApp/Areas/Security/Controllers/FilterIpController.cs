using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Commons.Mapping;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class FilterIpController : BusinessController<FilterIP, FilterIPOutputDto, IFilterIPService, string>
    {
        public FilterIpController(IFilterIPService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "FilterIP/Add";
            AuthorizeKey.UpdateKey = "FilterIP/Edit";
            AuthorizeKey.DeleteKey = "FilterIP/Delete";
            AuthorizeKey.UpdateEnableKey = "FilterIP/Enable";
            AuthorizeKey.ListKey = "FilterIP/List";
            AuthorizeKey.ViewKey = "FilterIP/View";
            AuthorizeKey.DeleteSoftKey = "FilterIP/DeleteSoft";
        }

        protected override void OnBeforeInsert(FilterIP info)
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
        protected override void OnBeforeUpdate(FilterIP info)
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
            CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SortCode" : Request.Query["sort"].ToString();
            string where = "1=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (StartIP like '%{0}%' or EndIP like '%{0}%' or Description like '%{0}%')", keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<FilterIPOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<FilterIPOutputDto>();
           
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }
    }
}