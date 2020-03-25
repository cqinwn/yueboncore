using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.CMS.Application;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.CMS.Services;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Tree;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Route("CMS/[controller]/[action]")]
    public class ArticleCommentsController:BusinessController<ArticleComments, ArticleCommentsOutputDto, IArticleCommentsService,string>
    {
        public ArticleCommentsController(IArticleCommentsService _iService) : base(_iService)
        {
            iService = _iService;

            AuthorizeKey.ListKey = "ArticleComments/List";
            AuthorizeKey.InsertKey = "ArticleComments/Add";
            AuthorizeKey.UpdateKey = "ArticleComments/Edit";
            AuthorizeKey.UpdateEnableKey = "ArticleComments/Enable";
            AuthorizeKey.DeleteKey = "ArticleComments/Delete";
            AuthorizeKey.DeleteSoftKey = "ArticleComments/DeleteSoft";
            AuthorizeKey.ViewKey = "ArticleComments/View";
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CheckAuthorized(AuthorizeKey.ListKey);
            string title = Request.Query["title"].ToString() == null ? "" : Request.Query["title"].ToString();
            string description = Request.Query["description"].ToString() == null ? "" : Request.Query["description"].ToString();
            string nickname = Request.Query["nickName"].ToString() == null ? "" : Request.Query["nickName"].ToString();
            string categoryId = Request.Query["categoryId"].ToString() == null ? "" : Request.Query["categoryId"].ToString();
            string addstartTime = Request.Query["addstartTime"].ToString() == null ? "" : Request.Query["addstartTime"].ToString();
            string addendTime = Request.Query["addendTime"].ToString() == null ? "" : Request.Query["addendTime"].ToString();
            string enabledflag = Request.Query["enabledflag"].ToString() == null ? "" : Request.Query["enabledflag"].ToString();
            string deleteflag = Request.Query["deleteflag"].ToString() == null ? "" : Request.Query["deleteflag"].ToString();

            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? " t1.CreatorTime " : Request.Query["sort"].ToString();
            string where = " 1=1 ";
            bool order = orderByDir == "asc" ? false : true;
            string oderfliedo = "CreatorTime,SortCode,EnabledMark,DeleteMark,";
            if (oderfliedo.Contains(orderFlied))
            {
                orderFlied = "t1." + orderFlied;
            }
            if (!string.IsNullOrEmpty(title))
            {
                where += string.Format(@" and t1.ArticleNewsId in 
(select Id from cms_articleNews where Title like '%{0}%'
or SubTitle like '%{0}%' or Zhaiyao like '%{0}%') ", title);
            }

            if (!string.IsNullOrEmpty(categoryId))
            {
                where += string.Format(@" and t1.ArticleNewsId in 
(select Id from cms_articleNews where CategoryId='{0}') ", categoryId);
            }

            if (!string.IsNullOrEmpty(description))
            {
                where += string.Format(" and t1.Description like '%{0}%'", description);
            }

            if (!string.IsNullOrEmpty(nickname))
            {
                where += string.Format(@" and t1.CreatorUserId in 
(select Id from Sys_User where Account like '%{0}%' 
or RealName like '%{0}%' 
or NickName like '%{0}%' 
or MobilePhone like '%{0}%') ", nickname);
            }

            if (!string.IsNullOrEmpty(addstartTime))
            {
                where += string.Format(" and t1.CreatorTime >= '{0}'", addstartTime);
            }

            if (!string.IsNullOrEmpty(addendTime))
            {
                where += string.Format(" and t1.CreatorTime<='{0}'", Convert.ToDateTime(addendTime).AddDays(1));
            }

            if (!string.IsNullOrEmpty(enabledflag))
            {
                where += string.Format(" and t1.EnabledMark={0}", enabledflag);
            }

            if (!string.IsNullOrEmpty(deleteflag))
            {
                where += string.Format(" and t1.DeleteMark={0}", deleteflag);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<ArticleCommentsOntputDto> list = iService.FindWithPagerRelationUserNoCheck(where, pagerInfo, orderFlied, order).MapTo<ArticleCommentsOntputDto>();
            ArticleNewsApp aApp = new ArticleNewsApp();
            for (int i=0;i<list.Count;i++)
            {
                string infostr = aApp.GetTitleAndCategoryById(list[i].ArticleNewsId);
                if (infostr != "")
                {
                    list[i].Title = infostr.Split('>')[0];
                    list[i].CategoryName = infostr.Split('>')[1];
                }
                
            }
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