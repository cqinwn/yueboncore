using System;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Security.IServices;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;

namespace Yuebon.CMS.Services
{
    public class BannerService: BaseService<Banner, BannerOutputDto, string>, IBannerService
    {
		private readonly IBannerRepository _repository;
        private readonly ILogService _logService;
        public BannerService(IBannerRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }


        /// <summary>
        /// 根据广告位代码获取该广告位的广告内容
        /// </summary>
        /// <param name="enCode">g广告位唯一编码</param>
        /// <returns></returns>
        public IEnumerable<Banner> GetListByAdEnCode(string enCode)
        {
            string where = string.Format("AdId=(select Id from CMS_Advert where EnCode='{0}')", enCode);
            IEnumerable<Banner> list = _repository.GetListWhere(where);
            return list;
        }
    }
}