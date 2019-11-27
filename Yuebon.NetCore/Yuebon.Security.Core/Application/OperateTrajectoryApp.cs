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
    public class OperateTrajectoryApp
    {
        IOperateTrajectoryService service = IoCContainer.Resolve<IOperateTrajectoryService>();


        /// <summary>
        /// 分页得到列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        public IEnumerable<OperateTrajectoryOutputDto> GetTrajectoryListByPage(string filter, string currentpage,
            string pagesize, string userid, string authorid)
        {
            return service.GetTrajectoryListByPage(filter, currentpage, pagesize, userid, authorid);
        }

        /// <summary>
        /// 得到汇总
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        public OperateTrajectorySumInfoTypeOutputDto GetSum(string userid, string authorid)
        {
            return service.GetSum(userid, authorid);
        }
    }
}
