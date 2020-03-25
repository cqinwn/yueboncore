using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.CMS.Models;
using Yuebon.CMS.IServices;
using Yuebon.Commons.Models;
using Yuebon.CMS.Dtos;
using Yuebon.Commons.Tree;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using System.Reflection;
using Yuebon.Commons.Log;

namespace Yuebon.WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Route("CMS/[controller]/[action]")]
    public class PageCategoryController : BusinessController<PageCategory, PageCategoryOutputDto,IPageCategoryService,string>
    {
        public PageCategoryController(IPageCategoryService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "PageCategory/Add";
            AuthorizeKey.UpdateKey = "PageCategory/Edit";
            AuthorizeKey.DeleteKey = "PageCategory/Delete";
            AuthorizeKey.UpdateEnableKey = "PageCategory/Enable";
            AuthorizeKey.ListKey = "PageCategory/List";
            AuthorizeKey.ViewKey = "PageCategory/View";

            AuthorizeKey.DeleteSoftKey = "PageCategory/DeleteSoft";
        }

        protected override void OnBeforeInsert(PageCategory info)
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
            if (string.IsNullOrEmpty(info.ParentId))
            {
                info.ClassLayer = 1;
                info.ParentId = "";
            }
            else
            {
                info.ClassLayer = iService.Get(info.ParentId).ClassLayer + 1;
            }

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(PageCategory info)
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
                result.ResData = iService.Get(id).MapTo<PageCategoryOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type,"获取单页分类异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据父类查询所有子类菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FindTreeSelectJson()
        {
            List<PageCategory> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (PageCategory item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.Title;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }


        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            //base.CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "ClassLayer" : Request.Query["sort"].ToString();
            string where = "1=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and Title like '%{0}%' ", keywords);
            }

            List<PageCategoryOutputDto> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList().MapTo<PageCategoryOutputDto>();

            return ToJsonContent(list);
        }
    }
}