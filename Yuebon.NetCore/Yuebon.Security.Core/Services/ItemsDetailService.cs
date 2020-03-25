using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Mapping;
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
    public class ItemsDetailService: BaseService<ItemsDetail, ItemsDetailOutputDto, string>, IItemsDetailService
    {
        private readonly IItemsDetailRepository _repository;
        private readonly ILogService _logService;
        private readonly IItemsService itemsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public ItemsDetailService(IItemsDetailRepository repository, ILogService logService, IItemsService _itemsService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            itemsService = _itemsService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据数据字典分类编码获取该分类可用内容
        /// </summary>
        /// <param name="itemCode">分类编码</param>
        /// <returns></returns>
        public async Task<List<ItemsDetailOutputDto>> GetItemDetailsByItemCode(string itemCode)
        {
            string where = string.Empty;

            if (!string.IsNullOrEmpty(itemCode))
            {
                where = string.Format("EnCode='{0}'",itemCode);
            }
            Items items =await itemsService.GetWhereAsync(where);
            List<ItemsDetailOutputDto> resultList = new List<ItemsDetailOutputDto>();
            if (items != null)
            {
                where = string.Format("ItemId='{0}'", items.Id);
               IEnumerable<ItemsDetail> list = _repository.GetAllByIsNotDeleteAndEnabledMark(where);
                resultList = list.OrderBy(t => t.SortCode).MapTo<ItemsDetailOutputDto>();
            }
            return resultList;
        }

    }
}