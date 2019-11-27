using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class OperateTrajectoryDetailService : BaseService<OperateTrajectoryDetail, string>, IOperateTrajectoryDetailService
    {
        private readonly IOperateTrajectoryDetailRepository _repository;
        private readonly ILogService _logService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public OperateTrajectoryDetailService(IOperateTrajectoryDetailRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 分页得到职位列表
        /// </summary>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        ///  <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public IEnumerable<OperateTrajectoryDetailOutputDto> GetTrajectoryListByPage(string filter, string currentpage,
            string pagesize, string userid)
        {
            return _repository.GetTrajectoryListByPage(filter,currentpage, pagesize, userid);
        }

        /// <summary>
        /// 得到总消息数
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCounts(string userid)
        {
            return _repository.GetTotalCounts(userid);
        }
        /// <summary>
        /// 得到筛选总条数
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCountsByFilter(string filter, string userid)
        {
            return _repository.GetTotalCountsByFilter(filter, userid);
        }

    }
}