using System;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义单据编码服务接口
    /// </summary>
    public interface ISequenceService:IService<Sequence,SequenceOutputDto, string>
    {
        /// <summary>
        /// 获取最新业务单据编码
        /// </summary>
        /// <param name="sequenceName">业务单据编码名称</param>
        /// <returns></returns>
        Task<CommonResult> GetSequenceNext(string sequenceName);
    }
}
