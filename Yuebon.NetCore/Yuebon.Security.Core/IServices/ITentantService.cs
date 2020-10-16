using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义租户服务接口
    /// </summary>
    public interface ITentantService:IService<Tentant,TentantOutputDto, string>
    {
    }
}
