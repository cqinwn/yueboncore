using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
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
        List<Menu> GetMenuByUser(string userId);

        /// <summary>
        /// ��ȡ���ܲ˵�������Vue �����б�
        /// </summary>
        /// <param name="systemTypeId">��ϵͳId</param>
        /// <returns></returns>
        Task<List<MenuTreeTableOutputDto>> GetAllMenuTreeTable(string systemTypeId);


        /// <summary>
        /// ���ݽ�ɫID�ַ��������ŷֿ�)��ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
        /// </summary>
        /// <param name="roleIds">��ɫID</param>
        /// <param name="typeID">ϵͳ����ID</param>
        /// <param name="isMenu">�Ƿ��ǲ˵�</param>
        /// <returns></returns>
        List<Menu> GetFunctions(string roleIds, string typeID,bool isMenu=false);

        /// <summary>
        /// ����ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
        /// </summary>
        /// <param name="typeID">ϵͳ����ID</param>
        /// <returns></returns>
        List<Menu> GetFunctions(string typeID);

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
        CommonResult DeleteBatchWhere(DeletesInputDto ids, IDbTransaction trans = null);
        /// <summary>
        /// �첽����������ɾ��
        /// </summary>
        /// <param name="ids">����Id����</param>
        /// <param name="trans">�������</param>
        /// <returns></returns>
        Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids, IDbTransaction trans = null);
    }
}
