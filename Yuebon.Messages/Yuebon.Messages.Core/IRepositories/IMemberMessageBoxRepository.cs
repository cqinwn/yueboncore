using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IRepositories
{
    /// <summary>
    /// 定义仓储接口
    /// </summary>
    public interface IMemberMessageBoxRepository:IRepository<MemberMessageBox, string>
    {

        /// <summary>
        /// 更新已读状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdateIsReadStatus(string id, int isread, string userid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isread">2:全部，0：未读，1：已读</param>
        /// <param name="userid"></param>
        /// <returns></returns>
        int GetTotalCounts(int isread, string userid);
    }
}