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
    public class AdvertController : BusinessController<Advert, AdvertOutputDto, IAdvertService,string>
    {
        public AdvertController(IAdvertService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "Advert/Add";
            AuthorizeKey.UpdateKey = "Advert/Edit";
            AuthorizeKey.DeleteKey = "Advert/Delete";
            AuthorizeKey.UpdateEnableKey = "Advert/Enable";
            AuthorizeKey.ListKey = "Advert/List";
            AuthorizeKey.ViewKey = "Advert/View";
            AuthorizeKey.DeleteSoftKey = "Advert/DeleteSoft";
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeInsert(Advert info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.EnabledMark = true;//默认开启
            info.DeleteMark = false;//默认没有被删除禁用
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DepartmentId;
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Advert info)
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
                result.ResData = iService.Get(id).MapTo<AdvertOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error("获取广告位异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public IActionResult GetAllname()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ListKey);
            IEnumerable<Advert> list = iService.GetAll();
            var treeList = new List<TreeSelectModel>();
            foreach (Advert item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = string.Format("{0}(宽{1}pxX高{2}px)", item.Title,item.ViewWidth,item.ViewHeight);
                treeModel.parentId = "";
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

            List<AdvertOutputDto> list = iService.GetListWhere(where).ToList().MapTo<AdvertOutputDto>();

            return ToJsonContent(list);
        }
    }
}