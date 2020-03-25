using System;
using System.Collections.Generic;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义操作轨迹明细表服务接口
    /// </summary>
    public interface IOperateTrajectoryDetailService:IService<OperateTrajectoryDetail,OperateTrajectoryDetailOutputDto, string>
    {

        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        IEnumerable<OperateTrajectoryDetailOutputDto> GetTrajectoryListByPage(string filter, string currentpage,
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
    }
}
