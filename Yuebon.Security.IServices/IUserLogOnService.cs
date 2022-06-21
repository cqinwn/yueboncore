using System;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IUserLogOnService:IService<UserLogOn, UserLogOnOutputDto>
    {

        /// <summary>
        /// ���ݻ�ԱID��ȡ�û���¼��Ϣʵ��
        /// </summary>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        UserLogOn GetByUserId(long userId);

        /// <summary>
        /// ���ݻ�ԱID��ȡ�û���¼��Ϣʵ��
        /// </summary>
        /// <param name="info">����������Ϣ</param>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        Task<bool> SaveUserTheme(UserThemeInputDto info, long userId);
        Task<bool> UpdateAsync(UserLogOn entity,long id);
        
    }
}
