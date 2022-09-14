using Yuebon.Core.Dtos;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// ��֯����
    /// </summary>
    public interface IOrganizeService:IService<Organize, OrganizeOutputDto>
    {

        /// <summary>
        /// ��ȡ��֯����������Vue �����б�
        /// </summary>
        /// <returns></returns>
        Task<List<Organize>> GetAllOrganizeTreeTable();

        /// <summary>
        /// ��ȡ���ڵ���֯
        /// </summary>
        /// <param name="id">��֯Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(long? id);


        /// <summary>
        /// ����������ɾ��
        /// </summary>
        /// <param name="ids">����Id����</param>
        /// <returns></returns>
        CommonResult DeleteBatchWhere(DeletesInputDto ids);
        /// <summary>
        /// �첽����������ɾ��
        /// </summary>
        /// <param name="ids">����Id����</param>
        /// <returns></returns>
        Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids);
    }
}
