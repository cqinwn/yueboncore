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
    public class ArticleBrowseTrajectoryApp
    {

        IArticleBrowseTrajectoryService service = IoCContainer.Resolve<IArticleBrowseTrajectoryService>();

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Insert(string oppid, string creatorid)
        {
            ArticleBrowseTrajectory entry = new ArticleBrowseTrajectory();
            entry.ArticleId = oppid;
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
        /// 更新记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Update(string id)
        {
            ArticleBrowseTrajectory entry = service.Get(id);
            if (entry != null)
            {
                entry.LeaveTime = DateTime.Now;
                TimeSpan ts1 = new TimeSpan(((DateTime)entry.LeaveTime).Ticks);
                TimeSpan ts2 = new TimeSpan(((DateTime)entry.CreatorTime).Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                entry.Duration = ts.Seconds;

                return service.Update(entry, id);
            }
            else
            {
                return false;
            }


        }
    }
}
