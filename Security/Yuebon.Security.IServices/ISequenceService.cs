namespace Yuebon.Security.IServices;

/// <summary>
/// 定义单据编码服务接口
/// </summary>
public interface ISequenceService:IService<Sequence,SequenceOutputDto>
{
    /// <summary>
    /// 获取最新业务单据编码
    /// </summary>
    /// <param name="sequenceName">业务单据编码名称</param>
    /// <returns></returns>
    Task<string> GetSequenceNextTask(string sequenceName);
    /// <summary>
    /// 获取最新业务单据编码
    /// </summary>
    /// <param name="sequenceName">业务单据编码名称</param>
    /// <returns></returns>
   string GetSequenceNext(string sequenceName);
}
