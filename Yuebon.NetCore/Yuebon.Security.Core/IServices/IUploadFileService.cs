using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IUploadFileService : IService<UploadFile, UploadFileOutputDto>
    {
        /// <summary>
        /// 根据应用Id和应用标识批量更新数据
        /// </summary>
        /// <param name="beLongAppId">应用Id</param>
        /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
        /// <param name="belongApp">应用标识</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        bool UpdateByBeLongAppId(string beLongAppId,string oldBeLongAppId, string belongApp = null, IDbTransaction trans = null);
    }
}
