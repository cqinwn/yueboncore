namespace Yuebon.Security.Services;

public class ItemsService: BaseService<Items, ItemsOutputDto>, IItemsService
{
    private readonly IItemsRepository _repository;
    public ItemsService(IItemsRepository itemsRepository)
    {
        repository = itemsRepository;
        _repository = itemsRepository;
    }


    /// <summary>
    /// ��ȡ���ܲ˵�������Vue �����б�
    /// </summary>
    /// <returns></returns>
    public async Task<List<Items>> GetAllItemsTreeTable()
    {
        //List<ItemsOutputDto> reslist = new List<ItemsOutputDto>();
        //IEnumerable<Items> elist =await _repository.GetListWhereAsync("1=1");
        //List<Items> list = elist.OrderBy(t => t.SortCode).ToList();
        //List<Items> oneMenuList = list.FindAll(t => t.ParentId == 0);
        //foreach (Items item in oneMenuList)
        //{
        //    ItemsOutputDto menuTreeTableOutputDto = new ItemsOutputDto();
        //    menuTreeTableOutputDto = item.MapTo<ItemsOutputDto>();
        //    menuTreeTableOutputDto.Children = GetSubMenus(list, item.Id).ToList<ItemsOutputDto>();
        //    reslist.Add(menuTreeTableOutputDto);
        //}
        return await _repository.GetAllItemsTreeTable();
    }

    /// <summary>
    /// ���ݱ����ѯ�ֵ����
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
    public async Task<Items> GetByEnCodAsynce(string enCode)
    {
        return await _repository.GetByEnCodAsynce(enCode);
    }
    /// <summary>
    /// ����ʱ�жϷ�������Ƿ���ڣ��ų��Լ���
    /// </summary>
    /// <param name="enCode">�������</param
    /// <param name="id">����Id</param>
    /// <returns></returns>
    public async Task<Items> GetByEnCodAsynce(string enCode, long id)
    {
        return await _repository.GetByEnCodAsynce(enCode,id);
    }

    /// <summary>
    /// ��ȡ�Ӳ˵����ݹ����
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId">����Id</param>
    /// <returns></returns>
    private List<ItemsOutputDto> GetSubMenus(List<Items> data, long parentId)
    {
        List<ItemsOutputDto> list = new List<ItemsOutputDto>();
        ItemsOutputDto menuTreeTableOutputDto = new ItemsOutputDto();
        var ChilList = data.FindAll(t => t.ParentId == parentId);
        foreach (Items entity in ChilList)
        {
            menuTreeTableOutputDto = entity.MapTo<ItemsOutputDto>();
            menuTreeTableOutputDto.Children = GetSubMenus(data, entity.Id).OrderBy(t => t.SortCode).MapTo<ItemsOutputDto>();
            list.Add(menuTreeTableOutputDto);
        }
        return list;
    }
}