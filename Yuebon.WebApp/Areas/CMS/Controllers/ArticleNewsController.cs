using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Yuebon.CMS.Application;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.WebApp.Controllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yuebon.WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Route("CMS/[controller]/[action]")]
    public class ArticleNewsController : BusinessController<ArticleNews, IArticleNewsService>
    {
        private IArticleCategoryService articleCategoryService;

        public ArticleNewsController(IArticleNewsService _iService, IArticleCategoryService _articleCategoryService) : base(_iService)
        {
            iService = _iService;
            articleCategoryService = _articleCategoryService;


            AuthorizeKey.ListKey = "ArticleNews/List";
            AuthorizeKey.InsertKey = "ArticleNews/Add";
            AuthorizeKey.UpdateKey = "ArticleNews/Edit";
            AuthorizeKey.UpdateEnableKey = "ArticleNews/Enable";
            AuthorizeKey.DeleteKey = "ArticleNews/Delete";
            AuthorizeKey.DeleteSoftKey = "ArticleNews/DeleteSoft";
            AuthorizeKey.ViewKey = "ArticleNews/View";
            AuthorizeKey.ExtendKey = "ArticleNews/ArticleSetting";
        }


        //新增前的默认字段填写
        protected override void OnBeforeInsert(ArticleNews info)
        {
            //留给子类对参数对象进行修改
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId =CurrentUser.UserId;
            info.DeleteMark = false;
            info.CompanyId = CurrentUser.OrganizeId;
            info.DeptId = CurrentUser.DepartmentId;
            info.TotalBrowse = 0;
            info.TotalFavorite = 0;
            info.TotalGood = 0;
            info.TotalMsg = 0;
            info.StarScore = 0.00M;
            info.ExtraStarScore = 0.00M;
            info.CategoryName = articleCategoryService.GetCategoryNameStr(info.CategoryId);
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
        protected override void OnBeforeUpdate(ArticleNews info)
        {
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId =CurrentUser.UserId;
            info.CategoryId = info.CategoryId;
            info.CategoryName = articleCategoryService.GetCategoryNameStr(info.CategoryId);

        }
        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(ArticleNews info)
        {
            //留给子类对参数对象进行修改
            info.DeleteMark = true;
            info.DeleteUserId =CurrentUser.UserId;
            info.DeleteTime= DateTime.Now;
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
                ArticleNewsApp articleNewsApp = new ArticleNewsApp();
                result.ResData = articleNewsApp.Get(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.Error(type, "获取文章异常", ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["title"].ToString() == null ? "" : Request.Query["title"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "t1.SortCode desc,t1.CreatorTime " : Request.Query["sort"].ToString();
            string categoryId = Request.Query["categoryId"].ToString() == null ? "" : Request.Query["categoryId"].ToString();
            string nickName = Request.Query["nickName"].ToString() == null ? "" : Request.Query["nickName"].ToString();
            string addstartTime = Request.Query["addstartTime"].ToString() == null ? "" : Request.Query["addstartTime"].ToString();
            string addendTime = Request.Query["addendTime"].ToString() == null ? "" : Request.Query["addendTime"].ToString();
            string where =GetPagerCondition(true);
            bool order = orderByDir == "asc" ? false : true;
            string oderfliedo = "CreatorTime,SortCode,EnabledMark,DeleteMark,";
            if (oderfliedo.Contains(orderFlied))
            {
                orderFlied = "t1." + orderFlied;
            }
           if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (t1.Title like '%{0}%' or t1.Tags like '%{0}%')", keywords);
            }
            if (!string.IsNullOrEmpty(categoryId))
            {
                where += string.Format(" and t1.CategoryId like '%{0}%'", categoryId);
            }
            if (!string.IsNullOrEmpty(nickName))
            {
                where += string.Format(" and (t2.NickName like '%{0}%' or t2.Account like '%{0}%' or t2.RealName  like '%{0}%' or t2.MobilePhone like '%{0}%')", nickName);
            }

            if (!string.IsNullOrEmpty(addstartTime))
            {
                where += string.Format(" and t1.CreatorTime>='{0}'", addstartTime.ToDateTime());
            }
            if (!string.IsNullOrEmpty(addendTime))
            {
                where += string.Format(" and t1.CreatorTime<='{0}'", Convert.ToDateTime(addendTime).AddDays(1));
            }
            // string addTime = Request.Query["addTime"].ToString() == null ? "" : Request.Query["addTime"].ToString();
            PagerInfo pagerInfo = GetPagerInfo();
            List<ArticleNewsOutputDto> list = iService.FindWithPagerRelationUser(where, pagerInfo, orderFlied, order).MapTo<ArticleNewsOutputDto>();
            
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }
        /// <summary>
        /// 基础设置
        /// </summary>
        /// <returns></returns>
        public IActionResult ArticleSetting()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ExtendKey);
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            ArtSetting artSetting = XmlConverter.Deserialize<ArtSetting>("xmlconfig/article.config");
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Add("ArtSetting", (object)artSetting);
            return View(artSetting);
        }
        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveSetting(ArtSetting info)
        {
            CommonResult result = new CommonResult();
            ArtSetting artSetting = XmlConverter.Deserialize<ArtSetting>("xmlconfig/article.config");
            artSetting = info;
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("ArtSetting"))
            {
                yuebonCacheHelper.Replace("ArtSetting", artSetting);
            }
            else
            {
                //写入缓存
                yuebonCacheHelper.Add("ArtSetting", artSetting);
            }
            XmlConverter.Serialize<ArtSetting>(artSetting, "xmlconfig/article.config");
            result.Success = true;
            return ToJsonContent(result);
        }
    }
}
