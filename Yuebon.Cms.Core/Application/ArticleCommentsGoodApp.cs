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
    public class ArticleCommentsGoodApp
    {

        IArticleCommentsGoodService service = IoCContainer.Resolve<IArticleCommentsGoodService>();

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Insert(string commnetsid, string creatorid)
        {
            ArticleCommentsGood entry = new ArticleCommentsGood();
            entry.CommentsId = commnetsid;
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
        public bool Deleted(string commentsid, string creatorid)
        {
            string strWhere = " CommentsId='" + commentsid + "' and CreatorUserId='" + creatorid + "'";
            ArticleCommentsGood entry = service.GetWhere(strWhere);

            if (entry != null)
            {
                return service.Delete(entry, null);
            }
            else
            {
                return false;
            }
        }
    }
}
