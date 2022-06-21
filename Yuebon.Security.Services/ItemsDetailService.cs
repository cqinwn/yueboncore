namespace Yuebon.Security.Services;

/// <summary>
/// 
/// </summary>
public class ItemsDetailService: BaseService<ItemsDetail, ItemsDetailOutputDto>, IItemsDetailService
{
    private readonly IRepository<ItemsDetail> _repository;
    private readonly ILogService _logService;
    private readonly IItemsService itemsService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logService"></param>
    public ItemsDetailService(IRepository<ItemsDetail> itemsDetailRepository,  IItemsService _itemsService)
    {
        repository=itemsDetailRepository;
        _repository = itemsDetailRepository;
        itemsService = _itemsService;
    }

    /// <summary>
    /// ���������ֵ��������ȡ�÷����������
    /// </summary>
    /// <param name="itemCode">�������</param>
    /// <returns></returns>
    public async Task<List<ItemsDetailOutputDto>> GetItemDetailsByItemCode(string itemCode)
    {
        string where = string.Empty;
        if (!string.IsNullOrEmpty(itemCode))
        {
            where = string.Format("EnCode='{0}'", itemCode);
        }
        Items items = await itemsService.GetByEnCodAsynce(itemCode);
        List<ItemsDetailOutputDto> resultList = new List<ItemsDetailOutputDto>();
        if (items != null)
        {
            where = string.Format("ItemId='{0}'", items.Id);
            IEnumerable<ItemsDetail> list = _repository.GetAllByIsNotDeleteAndEnabledMark(where);
            resultList = list.OrderBy(t => t.SortCode).MapTo<ItemsDetailOutputDto>();
        }
        return resultList;
    }


    /// <summary>
    /// ��ȡ������Vue �����б�
    /// </summary>
    /// <param name="itemId">���Id</param>
    /// <returns></returns>
    public async Task<List<ItemsDetailOutputDto>> GetAllItemsDetailTreeTable(string itemId)
    {
        string where = "1=1";
        List<ItemsDetailOutputDto> reslist = new List<ItemsDetailOutputDto>();
        where += " and ItemId='" + itemId + "'";
        IEnumerable<ItemsDetail> elist = await _repository.GetListWhereAsync(where);
        List<ItemsDetail> list = elist.OrderBy(t => t.SortCode).ToList();
        List<ItemsDetail> oneMenuList = list.FindAll(t => t.ParentId == 0);
        foreach (ItemsDetail item in oneMenuList)
        {
            ItemsDetailOutputDto menuTreeTableOutputDto = new ItemsDetailOutputDto();
            menuTreeTableOutputDto = item.MapTo<ItemsDetailOutputDto>();
            menuTreeTableOutputDto.Children = GetSubMenus(list, item.Id).ToList<ItemsDetailOutputDto>();
            reslist.Add(menuTreeTableOutputDto);
        }
        return reslist;
    }


    /// <summary>
    /// ��ȡ�Ӳ˵����ݹ����
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId">����Id</param>
    /// <returns></returns>
    private List<ItemsDetailOutputDto> GetSubMenus(List<ItemsDetail> data, long parentId)
    {
        List<ItemsDetailOutputDto> list = new List<ItemsDetailOutputDto>();
        ItemsDetailOutputDto menuTreeTableOutputDto = new ItemsDetailOutputDto();
        var ChilList = data.FindAll(t => t.ParentId == parentId);
        foreach (ItemsDetail entity in ChilList)
        {
            menuTreeTableOutputDto = entity.MapTo<ItemsDetailOutputDto>();
            menuTreeTableOutputDto.Children = GetSubMenus(data, entity.Id).OrderBy(t => t.SortCode).MapTo<ItemsDetailOutputDto>();
            list.Add(menuTreeTableOutputDto);
        }
        return list;
    }
}