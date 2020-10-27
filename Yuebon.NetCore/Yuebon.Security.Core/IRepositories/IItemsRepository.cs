using System;
using System.Threading.Tasks;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface IItemsRepository:IRepository<Items, string>
    {
        /// <summary>
        /// 根据编码查询字典分类
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
       Task<Items> GetByEnCodAsynce(string enCode);
    }
}