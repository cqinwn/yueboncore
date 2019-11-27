using System;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Pages;

namespace Yuebon.CMS.Application
{
    public class ArticleCommentsApp
    {

        IArticleCommentsService service = IoCContainer.Resolve<IArticleCommentsService>();

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Insert(string articleid, string parentid, string description, string creatorid)
        {
            ArticleComments entry = new ArticleComments();
            entry.ArticleNewsId = articleid;
            entry.ParentID = parentid;
            entry.Description = description;
            entry.CreatorTime = DateTime.Now;
            entry.CreatorUserId = creatorid;
            entry.CompanyId = "";
            entry.DeptId = "";


            if (service.Insert(entry, null) > 0)
            {
                return entry.Id;
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 加载评论
        /// </summary>
        /// <param name="articleid">文档编号</param>
        /// <param name="userId">访问用户编号</param>
        /// <returns></returns>
        public IEnumerable<ArticleCommentsOntputDto> GetArticleCommentsListInfo(string oppid, string userId)
        {
            return service.GetArticleCommentsListInfo(oppid, userId);
        }
        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelArticleComments(string id )
        {
            return service.DeleteSoft(false, id);
        }
    }
}
