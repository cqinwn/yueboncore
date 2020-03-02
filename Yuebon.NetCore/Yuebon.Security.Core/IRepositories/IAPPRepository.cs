using System;
using System.Collections.Generic;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAPPRepository:IRepository<APP,string>
    {
        /// <summary>
        /// 获取app对象
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <param name="secret">应用密钥AppSecret</param>
        /// <returns></returns>
        APP GetAPP(string appid, string secret);

        /// <summary>
        /// 获取app对象
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <returns></returns>
        APP GetAPP(string appid);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<AppOutputDto> SelectApp();
    }
}