using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface ISystemTypeService : IService<SystemType, string>
    {

        /// <summary>
        /// 根据系统编码查询系统对象
        /// </summary>
        /// <param name="appkey">系统编码</param>
        /// <returns></returns>
        SystemType GetByCode(string appkey);
    }
}
