using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
    /// <summary>
    /// 
    /// </summary>
    public class UploadFileService : BaseService<UploadFile, UploadFileOutputDto>, IUploadFileService
    {
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly ILogService _logService;
        public UploadFileService(IUploadFileRepository uploadFileRepository, ILogService logService)
        {
            _uploadFileRepository = uploadFileRepository;
            repository = uploadFileRepository;
            _logService = logService;
        }

        /// <summary>
        /// 根据应用Id和应用标识批量更新数据
        /// </summary>
        /// <param name="beLongAppId">应用Id</param>
        /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
        /// <param name="belongApp">应用标识</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool UpdateByBeLongAppId(string beLongAppId, string oldBeLongAppId,string belongApp = null, IDbTransaction trans = null)
        {
           return _uploadFileRepository.UpdateByBeLongAppId(beLongAppId, oldBeLongAppId, belongApp,trans);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<UploadFileOutputDto>> FindWithPagerAsync(SearchInputDto<UploadFile> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and  FileName like '%{0}%' ", search.Keywords);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<UploadFile> list = await _uploadFileRepository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<UploadFileOutputDto> pageResult = new PageResult<UploadFileOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<UploadFileOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}
