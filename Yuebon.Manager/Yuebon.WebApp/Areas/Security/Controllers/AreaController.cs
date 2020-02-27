using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Areas.Security.Models;
using Yuebon.WebApp.Controllers;
using Yuebon.WebApp.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Tree;
using Yuebon.Security.Application;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Dtos;
using Yuebon.Commons.Mapping;
using System.Reflection;
using Yuebon.Commons.Json;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class AreaController : BusinessController<Area, IAreaService>
    {
        public AreaController(IAreaService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.InsertKey = "Area/Add";
            AuthorizeKey.UpdateKey = "Area/Edit";
            AuthorizeKey.DeleteKey = "Area/Delete";
            AuthorizeKey.ListKey = "Area/List";
            AuthorizeKey.ViewKey = "Area/View";
            AuthorizeKey.DeleteSoftKey = "Area/DeleteSoft";
        }

        protected override void OnBeforeInsert(Area info)
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
                info.Layers = 1;
                info.ParentId = "";
            }
            else
            {
                info.Layers = iService.Get(info.ParentId).Layers + 1;
            }

        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Area info)
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
                result.ResData = iService.Get(id).MapTo<AreaOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type, "获取地区异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 分类select2树形展开，新增、修改需要
        /// </summary>
        /// <returns></returns>
        public IActionResult FindTreeSelectJson()
        {
            List<Area> list = iService.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Area item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }

        public IActionResult FindTreeSelectJsonCity()
        {
            List<Area> list = iService.GetAllByIsNotDeleteAndEnabledMark("Layers in(0,1)").OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Area item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }

        public IActionResult FindTreeSelectJsonTowns()
        {
            List<Area> list = iService.GetAllByIsNotDeleteAndEnabledMark("Layers in(3)").OrderBy(t => t.SortCode).ToList();

            var treeList = new List<TreeSelectModel>();
            foreach (Area item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId1 = item.ParentId;
                treeList.Add(treeModel);
            }
            return ToJsonContent(treeList.TreeSelectJson());
        }

        /// <summary>
        /// 查询所有字典分类，树形展开，初始化数据字典列表展示需要
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllTreeViewJson()
        {
            AreaApp areaApp = new AreaApp();

            return ToJsonContent(areaApp.ItemsTreeViewJson());
        }

        /// <summary>
        /// 查询所有省份
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllProvince()
        {
            AreaApp areaApp = new AreaApp();
            List<AreaSelect2OutDto> list= areaApp.GetProvinceAll();
            return ToJsonContent(list.ToJson());
        }

        /// <summary>
        /// 根据省份查询所有城市
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListCityByProvinceId(string id)
        {
            AreaApp areaApp = new AreaApp();
            List<AreaSelect2OutDto> list = areaApp.GetCityByProvinceId(id);
            return ToJsonContent(list.ToJson());
        }
        /// <summary>
        /// 根据城市查询所有县区
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListDistrictByCityId(string id)
        {
            AreaApp areaApp = new AreaApp();
            List<AreaSelect2OutDto> list = areaApp.GetDistrictByCityId(id);
            return ToJsonContent(list.ToJson());
        }
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public IActionResult GetAlltownsViewJson()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            //base.CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Layers" : Request.Query["sort"].ToString();
            string where = "1=1 and Layers in(3)";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
            }
            List<AreaOutputDto> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList().MapTo<AreaOutputDto>();

            return ToJsonContent(list);
        }
    }
}
