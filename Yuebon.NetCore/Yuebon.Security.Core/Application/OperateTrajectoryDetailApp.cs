using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Linq;
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
    public class OperateTrajectoryDetailApp
    {
        IOperateTrajectoryDetailService service = IoCContainer.Resolve<IOperateTrajectoryDetailService>();


        /// <summary>
        /// 分页得到职位列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<OperateTrajectoryDetailOutputDto> GetTrajectoryListByPage(string filter,string currentpage,
            string pagesize, string userid)
        {
            return service.GetTrajectoryListByPage(filter,currentpage, pagesize, userid);
        }

        /// <summary>
        /// 得到总消息数
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCounts(string userid)
        {
            return service.GetTotalCounts(userid);
        }
        /// <summary>
        /// 得到筛选总条数
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCountsByFilter(string filter, string userid)
        {
            return service.GetTotalCountsByFilter(filter, userid);
        }
        /// <summary>
        /// 获取所有未推送消息
        /// </summary>
        /// <returns></returns>
        public List<OperateTrajectoryDetail> GetListwithNoSend()
        {
            return service.GetListWhere(" IsSendMSg=0").AsToList();
        }
         
    }
}
