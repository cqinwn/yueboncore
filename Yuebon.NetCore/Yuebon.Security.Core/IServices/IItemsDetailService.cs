using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public interface IItemsDetailService:IService<ItemsDetail, ItemsDetailOutputDto, string>
    {
        /// <summary>
        /// 根据数据字典分类编码获取该分类可用内容
        /// </summary>
        /// <param name="itemCode">分类编码</param>
        /// <returns></returns>
        Task<List<ItemsDetailOutputDto>> GetItemDetailsByItemCode(string itemCode);
    }
}
