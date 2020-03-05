using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 日志管理
    /// </summary>
    public class LogApp
    {
        ILogService logService = IoCContainer.Resolve<ILogService>();

        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="info"></param>
        public void Insert(LogInPutDto info)
        {
            Log logInfo = new Log();
            logInfo=info.MapTo<Log>();
            logInfo.Id = GuidUtils.CreateNo();
            logService.Insert(logInfo);
        }
    }
}
