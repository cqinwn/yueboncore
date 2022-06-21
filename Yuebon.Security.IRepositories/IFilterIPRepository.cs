namespace Yuebon.Security.IRepositories;

public interface IFilterIPRepository:IRepository<FilterIP>
{
    /// <summary>
    /// ��֤IP��ַ�Ƿ񱻾ܾ�
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    bool ValidateIP(string ip);
}