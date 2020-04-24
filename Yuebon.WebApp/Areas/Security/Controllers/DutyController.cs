﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.WebApp.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Tree;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Mapping;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class DutyController : BusinessController<Role, RoleOutputDto, IRoleService, string>
    {
        private IOrganizeService organizeService;
        public DutyController(IRoleService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;

            AuthorizeKey.InsertKey = "Duty/Add";
            AuthorizeKey.UpdateKey = "Duty/Edit";
            AuthorizeKey.DeleteKey = "Duty/Delete";
            AuthorizeKey.UpdateEnableKey = "Duty/Enable";
            AuthorizeKey.ListKey = "Duty/List";
            AuthorizeKey.ViewKey = "Duty/View";
            AuthorizeKey.DeleteSoftKey = "Duty/DeleteSoft";
        }

        protected override void OnBeforeInsert(Role info)
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
            info.Category = 2;

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Role info)
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
            string where = "Category=2";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
            }

            Yuebon.Commons.Pages.PagerInfo pagerInfo = GetPagerInfo();
            List<RoleOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<RoleOutputDto>();
            List<RoleOutputDto> listResult =new List<RoleOutputDto>();
            foreach (RoleOutputDto item in list)
            {
                item.OrganizeName = organizeService.Get(item.OrganizeId).FullName;
                listResult.Add(item);
            }
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = listResult
            };
            return ToJsonContent(result);
        }


        /// <summary>
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindTreeSelectJson()
        {
            string where = "Category=2";
            List<Role> list = iService.GetAllByIsNotDeleteAndEnabledMark(where).OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Role item in list)
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