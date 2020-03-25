using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserFocusService : IService<UserFocus, UserFocusOutputDto, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        long InsertFocus(string focusid, string creatoruserid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        int DeleteFocus(string focusid, string creatoruserid);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        int GetTotalFocus(string creatoruserid);
        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        IEnumerable<UserFocusExtendOutPutDto> GetUserFocusListByPage(string filter, string currentpage,
            string pagesize, string userid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <param name="creatoruserid"></param>
        /// <returns></returns>
        bool GetIfFocusStatus(string focusid, string creatoruserid);
    }
}
