using System;
using System.Collections.Generic;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
   /// <summary>
   /// 
   /// </summary>
    public interface IOperateTrajectoryDetailRepository : IRepository<OperateTrajectoryDetail,string>
    {
        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        IEnumerable<OperateTrajectoryDetailOutputDto> GetTrajectoryListByPage(string filter,string currentpage,
            string pagesize, string userid);
        /// <summary>
        /// 得到总消息数
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        int GetTotalCounts(string userid);
        /// <summary>
        /// 得到筛选总条数
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        int GetTotalCountsByFilter(string filter, string userid);

        /// <summary>
        /// 按用户汇总统计未推送的访问轨迹数据
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
       List<OperateTrajectoryDetailTotalNoIsSendOutput> GetTotalNoIsSendList(string userId);


        /// <summary>
        /// 按内容发布者分组查询未发送的消息的浏览轨迹
        /// </summary>
        /// <returns></returns>
        List<OperateTrajectoryDetailAuthorUserId> GetNoIsSendListGroupByAuthorUserId();
        /// <summary>
        /// 根据内容发布者更新发送状态
        /// </summary>
        /// <param name="AuthorUserId"></param>
        /// <returns></returns>
        bool UpdateIsSendByAuthorUserId(string AuthorUserId);
    }
}