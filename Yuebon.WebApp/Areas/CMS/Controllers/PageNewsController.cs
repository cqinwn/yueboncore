﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.CMS.Application;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Route("CMS/[controller]/[action]")]
    public class PageNewsController : BusinessController<PageNews, PageNewsOutputDto, IPageNewsService,string>
    {

        public PageNewsController(IPageNewsService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "PageNews/Add";
            AuthorizeKey.UpdateKey = "PageNews/Edit";
            AuthorizeKey.DeleteKey = "PageNews/Delete";
            AuthorizeKey.UpdateEnableKey = "PageNews/Enable";
            AuthorizeKey.ListKey = "PageNews/List";
            AuthorizeKey.ViewKey = "PageNews/View";
            AuthorizeKey.DeleteSoftKey = "PageNews/DeleteSoft";
        }

        protected override void OnBeforeInsert(PageNews info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DepartmentId;
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
        protected override void OnBeforeUpdate(PageNews info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
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
                result.ResData = iService.Get(id).MapTo<PageNewsOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type, "获取单页面内容异常", ex);//错误记录
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
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SortCode desc,CreatorTime " : Request.Query["sort"].ToString();
            string where = GetPagerCondition();
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (Title like '%{0}%' or SeoTitle like '%{0}%' or Tags like '%{0}%' or Zhaiyao like '%{0}%')", keywords);
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<PageNewsOutputDto> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList().MapTo<PageNewsOutputDto>();

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