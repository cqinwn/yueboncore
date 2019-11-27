using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IoC;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;
using Yuebon.Security.Services;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 应用
    /// </summary>
    public class UserFocusApp
    {
        IUserFocusService service = IoCContainer.Resolve<IUserFocusService>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public long InsertFocus(string focusid, string creatoruserid)
        {
            return service.InsertFocus(focusid, creatoruserid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public int DeleteFocus(string focusid, string creatoruserid)
        {
            return service.DeleteFocus(focusid, creatoruserid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        public bool GetIfFocusStatus(string focusid, string creatoruserid)
        {
            return service.GetIfFocusStatus(focusid, creatoruserid);
        }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="creatoruserid"></param>
            /// <returns></returns>
            public int GetTotalFocus(string creatoruserid)
        {
            return service.GetTotalFocus(creatoruserid);
        }

            /// <summary>
            /// 分页得到列表
            /// </summary>
            /// <param name="currentpage"></param>
            /// <param name="pagesize"></param>
            /// <param name="filter"></param>
            /// <param name="userid"></param>
            /// <returns></returns>
            public IEnumerable<UserFocusExtendOutPutDto> GetUserFocusListByPage(string filter, string currentpage,
            string pagesize, string userid)
        {
            return service.GetUserFocusListByPage(filter, currentpage, pagesize, userid);
        }

    }
}
