using System;
using System.Collections.Generic;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义操作轨迹表服务接口
    /// </summary>
    public interface IOperateTrajectoryService:IService<OperateTrajectory,OperateTrajectoryOutputDto, string>
    {

        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        IEnumerable<OperateTrajectoryOutputDto> GetTrajectoryListByPage(string filter, string currentpage,
            string pagesize, string userid, string authorid);
        /// <summary>
        /// 得到汇总
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        OperateTrajectorySumInfoTypeOutputDto GetSum(string userid, string authorid);
    }
}
