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
    public class ArticleFavoriteApp
    {

        IArticleFavoriteService service = IoCContainer.Resolve<IArticleFavoriteService>();

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Insert(string articleid, string creatorid)
        {
            ArticleFavorite entry = new ArticleFavorite();
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
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Deleted(string article, string creatorid)
        {
            string strWhere = " ArticleNewsId='" + article + "' and CreatorUserId='" + creatorid + "'";
            ArticleFavorite entry = service.GetWhere(strWhere);

            if (entry != null)
            {
                return service.Delete(entry, null);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool QueryOppFavorite(string article, string creatorid)
        {
            string strWhere = " ArticleNewsId='" + article + "' and CreatorUserId='" + creatorid + "'";
            ArticleFavorite entry = service.GetWhere(strWhere);

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
