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
    /// ��֯����
    /// </summary>
    public interface IOrganizeService:IService<Organize, OrganizeOutputDto>
    {

        /// <summary>
        /// ��ȡ��֯����������Vue �����б�
        /// </summary>
        /// <returns></returns>
        Task<List<OrganizeOutputDto>> GetAllOrganizeTreeTable();

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
