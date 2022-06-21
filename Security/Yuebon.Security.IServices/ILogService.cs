using System;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// ��־��¼
    /// </summary>
    public interface ILogService:IService<Log, LogOutputDto>
    {
        void AddAsync(Log entity);
        /// <summary>
        /// ���������Ϣ��д���û��Ĳ�����־��¼
        /// ��Ҫ����д���ݿ���־
        /// </summary>
        /// <param name="tableName">����������</param>
        /// <param name="operationType">��������</param>
        /// <param name="note">������ϸ����</param>
        /// <returns></returns>
         Task<bool> OnOperationLog(string tableName, string operationType, string note);

        /// <summary>
        /// ���������Ϣ��д���û��Ĳ�����־��¼
        /// ��Ҫ����д����ģ����־
        /// </summary>
        /// <param name="module">����ģ������</param>
        /// <param name="operationType">��������</param>
        /// <param name="note">������ϸ����</param>
        /// <param name="currentUser">�����û�</param>
        /// <returns></returns>
        Task<bool> OnOperationLog(string module, string operationType,  string note, YuebonCurrentUser currentUser);
        /// <summary>
        /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
        /// </summary>
        /// <param name="search">��ѯ������</param>
        /// <returns>ָ������ļ���</returns>
        Task<PageResult<LogOutputDto>> FindWithPagerSearchAsync(SearchLogModel search);
    }
}
