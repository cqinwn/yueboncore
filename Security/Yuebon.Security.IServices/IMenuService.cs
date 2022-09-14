using Yuebon.Commons.Tree;
using Yuebon.Core.Dtos;

namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IMenuService:IService<Menu, MenuOutputDto>
{

    /// <summary>
    /// �����û���ȡ���ܲ˵�
    /// </summary>
    /// <param name="userId">�û�ID</param>
    /// <returns></returns>
    List<Menu> GetMenuByUser(long userId);

    /// <summary>
    /// ��ȡ���ܲ˵�������Vue �����б�
    /// </summary>
    /// <param name="systemTypeId">��ϵͳId</param>
    /// <returns></returns>
    Task<List<MenuTreeTableOutputDto>> GetAllMenuTreeTable(long systemTypeId);


    /// <summary>
    /// ���ݽ�ɫID�ַ��������ŷֿ�)��ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
    /// </summary>
    /// <param name="roleIds">��ɫID</param>
    /// <param name="typeID">ϵͳ����ID</param>
    /// <param name="isMenu">�Ƿ��ǲ˵�</param>
    /// <returns></returns>
    List<Menu> GetFunctions(string roleIds, long typeID,bool isMenu=false);

    /// <summary>
    /// ����ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
    /// </summary>
    /// <param name="typeID">ϵͳ����ID</param>
    /// <returns></returns>
    List<Menu> GetFunctions(long typeID);

    /// <summary>
    /// ���ݸ������ܱ����ѯ�����Ӽ����ܣ���Ҫ����ҳ�������ťȨ��
    /// </summary>
    /// <param name="enCode">�˵����ܱ���</param>
    /// <returns></returns>
    Task<IEnumerable<MenuOutputDto>> GetListByParentEnCode(string enCode);

    /// <summary>
    /// ����������ɾ��
    /// </summary>
    /// <param name="ids">����Id����</param>
    /// <param name="trans">�������</param>
    /// <returns></returns>
    CommonResult DeleteBatchWhere(DeletesInputDto ids);
    /// <summary>
    /// �첽����������ɾ��
    /// </summary>
    /// <param name="ids">����Id����</param>
    /// <param name="trans">�������</param>
    /// <returns></returns>
    Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids);


    List<UserVisitMenus> GetFunctionsByUser(long userID, long typeID);

    /// <summary>
    /// �����û���ɫIDs����ȡ��Ӧ�Ĺ����б�
    /// </summary>
    /// <param name="systemId">ϵͳ����ID/��ϵͳID</param>
    /// <returns></returns>
    List<UserVisitMenus> GetFunctionsBySystem(long systemId);

    List<VueRouterModel> GetVueRouter(string roleIds, string systemCode);
}
