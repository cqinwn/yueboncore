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
        ///  ���ݽڵ�Id��ȡ�ӽڵ�Id����(�����Լ�)
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        Task<List<long>> GetChildIdListWithSelfById(long pid);
        /// <summary>
        /// ��ȡ���ڵ���֯
        /// </summary>
        /// <param name="id">��֯Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(long? id);
        /// <summary>
        /// ���ݵ�ǰ��¼�û���ȡ����Id����
        /// </summary>
        /// <returns></returns>
        Task<List<long>> GetUserOrgIdList();
        /// <summary>
        /// �����û���ɫ��ȡ��֯Id����
        /// </summary>
        /// <param name = "userId"> �û�ID </ param >
        /// < returns ></ returns >
        Task<List<long>> GetUserRoleOrgIdList(long userId);
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

        /// <summary>
        /// ������֯���ͻ�ȡ��˾����֯
        /// </summary>
        /// <param name="orgType">��֯����</param>
        /// <returns></returns>
        Task<List<Organize>> GetOrganizesByOrgTypeAsync(string orgType);
    }
}
