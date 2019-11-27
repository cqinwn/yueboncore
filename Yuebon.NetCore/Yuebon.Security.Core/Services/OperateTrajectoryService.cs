using System;
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
    public class OperateTrajectoryService : BaseService<OperateTrajectory, string>, IOperateTrajectoryService
    {
        private readonly IOperateTrajectoryRepository _repository;
        private readonly ILogService _logService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public OperateTrajectoryService(IOperateTrajectoryRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

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
            return _repository.GetTrajectoryListByPage(filter, currentpage, pagesize, userid, authorid);
        }

        /// <summary>
        /// 得到汇总
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="authorid"></param>
        /// <returns></returns>
        public OperateTrajectorySumInfoTypeOutputDto GetSum(string userid, string authorid)
        {
            return _repository.GetSum(userid, authorid);
        }

    }
}