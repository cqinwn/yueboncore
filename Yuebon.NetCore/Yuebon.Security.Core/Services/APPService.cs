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
        public APPService(IAPPRepository repository, ILogService logService) : base(repository)
        {
            _appRepository = repository;
            _logService = logService;
        }

        /// <summary>
        /// ͬ������ʵ�塣
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="trans">�������</param>
        /// <returns></returns>
        public override long Insert(APP entity, IDbTransaction trans = null)
        {
            long result = repository.Insert(entity, trans); 
            this.UpdateCacheAllowApp();
            return result;
        }

        /// <summary>
        /// �첽����ʵ�塣
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="id">����ID</param>
        /// <param name="trans">�������</param>
        /// <returns></returns>
        public override async Task<bool> UpdateAsync(APP entity, object id, IDbTransaction trans = null)
        {
            bool result=await repository.UpdateAsync(entity, id, trans);
            this.UpdateCacheAllowApp();
            return result;
        }
        /// <summary>
        /// �첽������ʵ�塣
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="trans">�������</param>
        /// <returns></returns>
        public override async Task<long> InsertAsync(APP entity, IDbTransaction trans = null)
        {
            long result = await repository.InsertAsync(entity, trans);
            this.UpdateCacheAllowApp();
            return result;
        }
        /// <summary>
        /// ��ȡapp����
        /// </summary>
        /// <param name="appid">Ӧ��ID</param>
        /// <param name="secret">Ӧ����ԿAppSecret</param>
        /// <returns></returns>
        public APP GetAPP(string appid, string secret)
        {
            return _appRepository.GetAPP(appid, secret);
        }
        /// <summary>
        /// ��ȡapp����
        /// </summary>
        /// <param name="appid">Ӧ��ID</param>
        /// <returns></returns>
        public APP GetAPP(string appid)
        {
            return _appRepository.GetAPP(appid);
        }
        public IList<AppOutputDto> SelectApp()
        {
            return _appRepository.SelectApp();
        }

        /// <summary>
        /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
        /// </summary>
        /// <param name="search">��ѯ������</param>
        /// <returns>ָ������ļ���</returns>
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
        /// ���¿���Ӧ�û���
        /// </summary>
        public void UpdateCacheAllowApp()
        {
            IEnumerable<APP> appList = repository.GetAllByIsNotDeleteAndEnabledMark();
            MemoryCacheHelper.Set("cacheAppList", appList);
        }
    }
}