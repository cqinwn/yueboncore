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
    public class ArticleStarApp
    {

        IArticleStarService service = IoCContainer.Resolve<IArticleStarService>();

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Insert(string articleid, string creatorid)
        {
            ArticleStar entry = new ArticleStar();
            entry.ArticleNewsId = articleid;
            entry.CreatorTime = DateTime.Now;
            entry.CreatorUserId = creatorid;

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
        /// 修改记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Update(string articleid, string starscore, string creatorid)
        {
            string strWhere = " ArticleNewsId='" + articleid + "' and CreatorUserId='" + creatorid + "'";
            ArticleStar entry = service.GetWhere(strWhere);

            if (entry != null)
            {
                entry.StarScore = decimal.Parse(starscore);
                return service.Update(entry, null);
            }
            else //不存在则新增
            {
                entry = new ArticleStar();
                entry.ArticleNewsId = articleid;
                entry.StarScore = decimal.Parse(starscore);
                entry.CreatorTime = DateTime.Now;
                entry.CreatorUserId = creatorid;

                if (service.Insert(entry, null) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool QueryArticleStar(string articleid, string creatorid)
        {
            string strWhere = " ArticleNewsId='" + articleid + "' and CreatorUserId='" + creatorid + "'";
            ArticleStar entry = service.GetWhere(strWhere);

            if (entry != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
