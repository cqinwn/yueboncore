using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.IRepositories;
using Yuebon.Tenants.IServices;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Services
{
    /// <summary>
    /// 租户服务接口实现
    /// </summary>
    public class TenantService: BaseService<Tenant,TenantOutputDto, string>, ITenantService
    {
		private readonly ITenantRepository _repository;
        public TenantService(ITenantRepository repository) : base(repository)
        {
			_repository=repository;
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