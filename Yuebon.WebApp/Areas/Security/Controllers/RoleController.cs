using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using System.Reflection;
using Yuebon.Commons.Log;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class RoleController : BusinessController<Role, RoleOutputDto, IRoleService, string>
    {
        private IOrganizeService organizeService;
        public RoleController(IRoleService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;

            AuthorizeKey.InsertKey = "Role/Add";
            AuthorizeKey.UpdateKey = "Role/Edit";
            AuthorizeKey.DeleteKey = "Role/Delete";
            AuthorizeKey.UpdateEnableKey = "Role/Enable";
            AuthorizeKey.ListKey = "Role/List";
            AuthorizeKey.ViewKey = "Role/View";
            AuthorizeKey.ExtendKey = "Role/SetAuthorize";
            AuthorizeKey.DeleteSoftKey = "Role/DeleteSoft";
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
            info.Category = 1;

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
                result.ResData = iService.Get(id).MapTo<RoleOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取角色异常", ex);//错误记录
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
            string orderFlied = Request.Query["sort"].ToString() == "" ? "SortCode" : Request.Query["sort"].ToString();
            string where = "Category=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
            }

            Yuebon.Commons.Pages.PagerInfo pagerInfo = GetPagerInfo();
            List<RoleOutputDto> list = iService.FindWithPager(where, pagerInfo, orderFlied, order).MapTo<RoleOutputDto>();
            List<RoleOutputDto> listResult = new List<RoleOutputDto>();
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
            string where = "Category=1";
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