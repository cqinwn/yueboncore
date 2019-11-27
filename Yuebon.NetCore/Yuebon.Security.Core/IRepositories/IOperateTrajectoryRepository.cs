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
    public interface IOperateTrajectoryRepository : IRepository<OperateTrajectory,string>
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
        IEnumerable<OperateTrajectoryOutputDto> GetTrajectoryListByPage(string filter,string currentpage,
            string pagesize, string userid,string authorid);
        /// <summary>
        /// 得到汇总
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        OperateTrajectorySumInfoTypeOutputDto GetSum(string userid,string authorid);
       
    }
}