namespace Yuebon.Security.IServices
{
    /// <summary>
    /// �����ֵ���ϸ
    /// </summary>
    public interface IItemsDetailService:IService<ItemsDetail, ItemsDetailOutputDto>
    {
        /// <summary>
        /// ���������ֵ��������ȡ�÷����������
        /// </summary>
        /// <param name="itemCode">�������</param>
        /// <returns></returns>
        Task<List<ItemsDetailOutputDto>> GetItemDetailsByItemCode(string itemCode);

        /// <summary>
        /// ��ȡ������Vue �����б�
        /// </summary>
        /// <param name="itemId">���Id</param>
        /// <returns></returns>
       Task<List<ItemsDetailOutputDto>> GetAllItemsDetailTreeTable(string itemId);
    }
}
