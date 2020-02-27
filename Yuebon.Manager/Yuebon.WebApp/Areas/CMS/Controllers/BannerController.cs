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
using Yuebon.CMS.Application;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Mapping;
using System.Reflection;
using Yuebon.Commons.Log;

namespace Yuebon.WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Route("CMS/[controller]/[action]")]
    public class BannerController : BusinessController<Banner,IBannerService>
    {
        public BannerController(IBannerService _iService) : base(_iService)
        {
            iService = _iService;


            AuthorizeKey.ListKey = "Banner/List";
            AuthorizeKey.InsertKey = "Banner/Add";
            AuthorizeKey.UpdateKey = "Banner/Edit";
            AuthorizeKey.UpdateEnableKey = "Banner/Enable";
            AuthorizeKey.DeleteKey = "Banner/Delete";
            AuthorizeKey.DeleteSoftKey = "Banner/DeleteSoft";
            AuthorizeKey.ViewKey = "Banner/View";
        }

        protected override void OnBeforeInsert(Banner info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.EnabledMark = true;//默认开启
            info.DeleteMark = false;//默认没有被删除禁用
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DepartmentId;
            if (info.LinkUrl == null)
            {
                info.LinkUrl = "#";
            };
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
        protected override void OnBeforeUpdate(Banner info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            if (info.LinkUrl == null)
            {
                info.LinkUrl = "#";
            };
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
                result.ResData = iService.Get(id).MapTo<BannerOutputDto>();
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type, "获取广告异常", ex);//错误记录
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
            List<Banner> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList().MapTo<Banner>();
            List<BannerOutputDto> resultList = new List<BannerOutputDto>();
            AdvertApp advertApp = new AdvertApp();
            foreach (Banner item in list)
            {
                BannerOutputDto info = new BannerOutputDto();
                info = item.MapTo<BannerOutputDto>();
                info.ADTitle = advertApp.GetAdvertById(item.AdId).Title;
                resultList.Add(info);
            }

            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = resultList
            };
            return ToJsonContent(result);
        }

    }
}