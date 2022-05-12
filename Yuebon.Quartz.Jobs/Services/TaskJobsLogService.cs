using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Quartz.Dtos;
using Yuebon.Quartz.IRepositories;
using Yuebon.Quartz.IServices;
using Yuebon.Quartz.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Quartz.Services
{
    /// <summary>
    /// 定时任务执行日志服务接口实现
    /// </summary>
    public class TaskJobsLogService: BaseService<TaskJobsLog,TaskJobsLogOutputDto>, ITaskJobsLogService
    {
		private readonly ITaskJobsLogRepository _repository;
        private readonly ILogService _logService;
        public TaskJobsLogService(ITaskJobsLogRepository taskJobsLogRepository,ILogService logService)
        {
            repository = taskJobsLogRepository;
            _repository = taskJobsLogRepository;
			_logService=logService;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<TaskJobsLogOutputDto>> FindWithPagerAsync(SearchInputDto<TaskJobsLog> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (TaskId like '%{0}%' or  TaskName like '%{0}%')", search.Keywords);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<TaskJobsLog> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<TaskJobsLogOutputDto> pageResult = new PageResult<TaskJobsLogOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<TaskJobsLogOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}