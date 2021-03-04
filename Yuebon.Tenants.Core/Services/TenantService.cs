using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Tenants.Dtos;
using Yuebon.Tenants.IRepositories;
using Yuebon.Tenants.IServices;
using Yuebon.Tenants.Models;

namespace Yuebon.Tenants.Services
{
    /// <summary>
    /// 租户服务接口实现
    /// </summary>
    public class TenantService: BaseService<Tenant,TenantOutputDto, string>, ITenantService
    {
		private readonly ITenantRepository _repository;
        private readonly ITenantLogonRepository _repositoryLogon;
        public TenantService(ITenantRepository repository, ITenantLogonRepository repositoryLogon) : base(repository)
        {
			_repository=repository;
            _repositoryLogon = repositoryLogon;
        }

        /// <summary>
        /// 根据租户账号查询租户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<Tenant> GetByUserName(string userName)
        {
            return await _repository.GetByUserName(userName);
        }


        /// <summary>
        /// 注册租户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tenantLogOnEntity"></param>
        public async Task<bool> InsertAsync(Tenant entity, TenantLogon tenantLogOnEntity)
        {
            return await _repository.InsertAsync(entity, tenantLogOnEntity);
        }


        /// <summary>
        /// 租户登陆验证。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（第一次md5加密后）</param>
        /// <returns>验证成功返回用户实体，验证失败返回null|提示消息</returns>
        public async Task<Tuple<Tenant, string>> Validate(string userName, string password)
        {
            var userEntity = await _repository.GetByUserName(userName);

            if (userEntity == null)
            {
                return new Tuple<Tenant, string>(null, "系统不存在该用户，请重新确认。");
            }

            if (!userEntity.EnabledMark)
            {
                return new Tuple<Tenant, string>(null, "该用户已被禁用，请联系管理员。");
            }

            var userSinginEntity = _repositoryLogon.GetByTenantId(userEntity.Id);

            string inputPassword = MD5Util.GetMD5_32(DEncrypt.Encrypt(MD5Util.GetMD5_32(password).ToLower(), userSinginEntity.TenantSecretkey).ToLower()).ToLower();

            if (inputPassword != userSinginEntity.TenantPassword)
            {
                return new Tuple<Tenant, string>(null, "密码错误，请重新输入。");
            }
            else
            {
                TenantLogon userLogOn = _repositoryLogon.GetWhere("UserId='" + userEntity.Id + "'");
                if (userLogOn.AllowEndTime < DateTime.Now)
                {
                    return new Tuple<Tenant, string>(null, "您的账号已过期，请联系系统管理员！");
                }
                if (userLogOn.LockEndDate > DateTime.Now)
                {
                    string dateStr = userLogOn.LockEndDate.ToEasyStringDQ();
                    return new Tuple<Tenant, string>(null, "当前被锁定，请" + dateStr + "登录");
                }
                if (userLogOn.FirstVisitTime == null)
                {
                    userLogOn.FirstVisitTime = userLogOn.PreviousVisitTime = DateTime.Now;
                }
                else
                {
                    userLogOn.PreviousVisitTime = DateTime.Now;
                }
                userLogOn.LogOnCount++;
                userLogOn.LastVisitTime = DateTime.Now;
                userLogOn.TenantOnLine = true;
                await _repositoryLogon.UpdateAsync(userLogOn, userLogOn.Id);
                return new Tuple<Tenant, string>(userEntity, "");
            }
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<TenantOutputDto>> FindWithPagerAsync(SearchInputDto<Tenant> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += " and (TenantName like '%" + search.Keywords + "%' or CompanyName like '%" + search.Keywords + "%')";
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<Tenant> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<TenantOutputDto> pageResult = new PageResult<TenantOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<TenantOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}