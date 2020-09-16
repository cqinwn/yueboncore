using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义序号编码规则表服务接口
    /// </summary>
    public interface ISequenceRuleService:IService<SequenceRule,SequenceRuleOutputDto, string>
    {
    }
}
