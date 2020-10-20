using System;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class FilterIPService: BaseService<FilterIP, FilterIPOutputDto, string>, IFilterIPService
    {
        private readonly IFilterIPRepository _repository;
        private readonly ILogService _logService;
        public FilterIPService(IFilterIPRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
        /// <summary>
        /// 验证IP地址是否被拒绝
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool ValidateIP(string ip)
        {
          return  _repository.ValidateIP(ip);
        }
    }
}