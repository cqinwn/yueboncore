using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Dtos;
using System.Collections.Generic;
using Yuebon.Commons.Mapping;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 租户服务接口实现
    /// </summary>
    public class TenantService: BaseService<Tenant,TenantOutputDto, string>, ITenantService
    {
		private readonly ITenantRepository _repository;
        private readonly ILogService _logService;
        public TenantService(ITenantRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<TenantOutputDto>> FindWithPagerAsync(SearchInputDto<Tenant> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += " and (TenantName like '%" + search.Keywords + "%' or CompanyName like '%" + search.Keywords + "%')";
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<Tenant> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<TenantOutputDto> pageResult = new PageResult<TenantOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<TenantOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}