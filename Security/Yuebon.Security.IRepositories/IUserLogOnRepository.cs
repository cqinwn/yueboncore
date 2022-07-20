namespace Yuebon.Security.IRepositories;

public interface IUserLogOnRepository:IRepository<UserLogOn>
{

    /// <summary>
    /// ���ݻ�ԱID��ȡ�û���¼��Ϣʵ��
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    UserLogOn GetByUserId(long userId);
}