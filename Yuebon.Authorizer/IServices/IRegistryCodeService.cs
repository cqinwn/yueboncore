using System;
using Yuebon.Commons.IServices;
using Yuebon.Authorizer.Dtos;
using Yuebon.Authorizer.Models;

namespace Yuebon.Authorizer.IServices
{
    /// <summary>
    /// 定义服务接口
    /// </summary>
    public interface IRegistryCodeService:IService<RegistryCode,RegistryCodeOutputDto, string>
    {
    }
}
