using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
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
    public class APPService: BaseService<APP,AppOutputDto>, IAPPService
    {
        private readonly IAPPRepository _appRepository;
        private readonly ILogService _logService;
        public APPService(IAPPRepository appRepository, ILogService logService)
        {
            repository = appRepository;
            _appRepository = appRepository;
            _logService = logService;
        }

        /// <summary>
        /// 同步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public override int Insert(APP entity)
        {
            int result = repository.Insert(entity); 
            this.UpdateCacheAllowApp();
            return result;
        }

        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public override async Task<bool> UpdateAsync(APP entity, string where)
        {
            bool result=await repository.UpdateAsync(entity, where);
            this.UpdateCacheAllowApp();
            return result;
        }
        /// <summary>
        /// 异步步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public override async Task<int> InsertAsync(APP entity)
        {
            int result = await repository.InsertAsync(entity);
            this.UpdateCacheAllowApp();
            return result;
        }
        /// <summary>
        /// 获取app对象
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <param name="secret">应用密钥AppSecret</param>
        /// <returns></returns>
        public APP GetAPP(string appid, string secret)
        {
            return _appRepository.GetAPP(appid, secret);
        }
        /// <summary>
        /// 获取app对象
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <returns></returns>
        public APP GetAPP(string appid)
        {
            return _appRepository.GetAPP(appid);
        }
        //public IList<AppOutputDto> SelectApp()
        //{
        //    return _appRepository.SelectApp();
        //}

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<AppOutputDto>> FindWithPagerAsync(SearchInputDto<APP> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (AppId like '%{0}%' or RequestUrl like '%{0}%')", search.Keywords);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<APP> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<AppOutputDto> pageResult = new PageResult<AppOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<AppOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
        /// <summary>
        /// 更新可用应用缓存
        /// </summary>
        public void UpdateCacheAllowApp()
        {
            IEnumerable<APP> appList = repository.GetAllByIsNotDeleteAndEnabledMark();
            MemoryCacheHelper.Set("cacheAppList", appList,72000);
        }
    }
}