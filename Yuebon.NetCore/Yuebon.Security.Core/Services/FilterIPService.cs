using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class FilterIPService: BaseService<FilterIP, FilterIPOutputDto>, IFilterIPService
    {
        private readonly IFilterIPRepository _repository;
        private readonly ILogService _logService;
        public FilterIPService(IFilterIPRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
        }
        /// <summary>
        /// ��֤IP��ַ�Ƿ񱻾ܾ�
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool ValidateIP(string ip)
        {
          return  _repository.ValidateIP(ip);
        }

        /// <summary>
        /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
        /// </summary>
        /// <param name="search">��ѯ������</param>
        /// <returns>ָ������ļ���</returns>
        public override async Task<PageResult<FilterIPOutputDto>> FindWithPagerAsync(SearchInputDto<FilterIP> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (StartIP like '%{0}%' or EndIP like '%{0}%')", search.Keywords);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<FilterIP> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<FilterIPOutputDto> pageResult = new PageResult<FilterIPOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<FilterIPOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}