using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class UploadFileService : BaseService<UploadFile, UploadFileOuputDto, string>, IUploadFileService
    {
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly ILogService _logService;
        public UploadFileService(IUploadFileRepository repository, ILogService logService) : base(repository)
        {
            _uploadFileRepository = repository;
            _logService = logService;
            _uploadFileRepository.OnOperationLog += _logService.OnOperationLog;
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
    }
}
