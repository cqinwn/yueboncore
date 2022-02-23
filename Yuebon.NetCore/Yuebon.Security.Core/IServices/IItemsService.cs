using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IItemsService:IService<Items, ItemsOutputDto>
    {

        /// <summary>
        /// ��ȡ���ܲ˵�������Vue �����б�
        /// </summary>
        /// <returns></returns>
        Task<List<ItemsOutputDto>> GetAllItemsTreeTable();

        /// <summary>
        /// ���ݱ����ѯ�ֵ����
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        Task<Items> GetByEnCodAsynce(string enCode);


        /// <summary>
        /// ����ʱ�жϷ�������Ƿ���ڣ��ų��Լ���
        /// </summary>
        /// <param name="enCode">�������</param
        /// <param name="id">����Id</param>
        /// <returns></returns>
        Task<Items> GetByEnCodAsynce(string enCode, string id);
    }
}
