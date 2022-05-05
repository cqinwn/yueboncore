using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Tenants.IRepositories;
using Yuebon.Tenants.IServices;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Services
{
    /// <summary>
    /// 用户登录信息服务接口实现
    /// </summary>
    public class TenantLogonService : BaseService<TenantLogon,TenantLogonOutputDto>, ITenantLogonService
    {
		private readonly ITenantLogonRepository _repository;
        public TenantLogonService(ITenantLogonRepository repository) 
        {
			_repository=repository;
        }
    }
}