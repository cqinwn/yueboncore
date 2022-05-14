using System;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.IServices
{
    /// <summary>
    /// 定义租户服务接口
    /// </summary>
    public interface ITenantService:IService<Tenant,TenantOutputDto>
    {


        /// <summary>
        /// 根据租户账号查询租户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<Tenant> GetByUserName(string userName);


        /// <summary>
        /// 注册租户户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tenantLogOnEntity"></param>
        Task<bool> InsertAsync(Tenant entity, TenantLogon tenantLogOnEntity);

        /// <summary>
        /// 初始化租户数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> InitTenantDataAsync(Tenant entity);
        /// <summary>
        /// 租户登陆验证。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（第一次md5加密后）</param>
        /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
        Task<Tuple<Tenant, string>> Validate(string userName, string password);
    }
}
