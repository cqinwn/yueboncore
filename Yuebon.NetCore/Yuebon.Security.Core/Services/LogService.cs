using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Net;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Zxw.Framework.NetCore.Extensions;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class LogService : BaseService<Log, LogOutputDto, string>, ILogService
    {
        private readonly ILogRepository _iLogRepository;
        private readonly IUserRepository _iuserRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userRepository"></param>
        public LogService(ILogRepository repository, IUserRepository userRepository) : base(repository)
        {
            _iLogRepository = repository;
            _iuserRepository = userRepository;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public async Task<PageResult<LogOutputDto>> FindWithPagerSearchAsync(SearchLogModel search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.CreatorTime1))
            {
                where += " and CreatorTime >='"+ search.CreatorTime1.ToDateTime()+ "'";
            }
            if (!string.IsNullOrEmpty(search.CreatorTime2))
            {
                where += " and CreatorTime <='" + search.CreatorTime2.ToDateTime() + "'";
            }
            if (!string.IsNullOrEmpty(search.Filter.Type))
            {
                where += " and Type='"+ search.Filter.Type + "'";
            }
            if (!string.IsNullOrEmpty(search.Filter.IPAddress))
            {
                where += string.Format(" and IPAddress = '{0}'", search.Filter.IPAddress);
            };
            if (!string.IsNullOrEmpty(search.Filter.Account))
            {
                where += string.Format(" and Account = '{0}'", search.Filter.Account);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };

            //Expression<Func<Log, bool>> filter = log => true;
            //if (!string.IsNullOrEmpty(search.Keywords))
            //{
            //    filter = filter.And(log => log.Account.StartsWith(search.Keywords) || log.ModuleName.StartsWith(search.Keywords) || log.IPAddress.StartsWith(search.Keywords)
            // || log.IPAddressName.StartsWith(search.Keywords) || log.Description.StartsWith(search.Keywords));
            //}
            //if (!string.IsNullOrEmpty(search.EnCode))
            //{
            //    filter = filter.And(log=>search.EnCode.Contains(log.Type));
            //}
            List<Log> list = await _iLogRepository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<LogOutputDto> pageResult = new PageResult<LogOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<LogOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }

        /// <summary>
        /// 根据相关信息，写入用户的操作日志记录
        /// </summary>
        /// <param name="tableName">操作表名称</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="note">操作详细表述</param>
        /// <returns></returns>
        public bool OnOperationLog(string tableName, string operationType, string note)
        {
            try
            {
                //虽然实现了这个事件，但是我们还需要判断该表是否在配置表里面，如果不在，则不记录操作日志。
                //var identities = _httpContextAccessor.HttpContext.User.Identities;
                if (HttpContextHelper.HttpContext == null)
                {
                    return false;
                }
                var identities =HttpContextHelper.HttpContext.User.Identities;
                var claimsIdentity = identities.First<ClaimsIdentity>();
                List<Claim> claimlist = claimsIdentity.Claims as List<Claim>;
                string userId = claimlist[0].Value;
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                YuebonCurrentUser CurrentUser = new YuebonCurrentUser();
                var user = JsonSerializer.Deserialize<YuebonCurrentUser>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
                if (user != null)
                {
                    CurrentUser = user;
                    bool insert = operationType == DbLogType.Create.ToString(); ;//&& settingInfo.InsertLog;
                    bool update = operationType == DbLogType.Update.ToString();// && settingInfo.UpdateLog;
                    bool delete = operationType == DbLogType.Delete.ToString();// && settingInfo.DeleteLog;
                    bool deletesoft = operationType == DbLogType.DeleteSoft.ToString();// && settingInfo.DeleteLog;
                    bool exception = operationType == DbLogType.Exception.ToString();// && settingInfo.DeleteLog;
                    bool sql = operationType == DbLogType.SQL.ToString();// && settingInfo.DeleteLog;

                    if (insert || update || delete || deletesoft || exception || sql)
                    {
                        Log info = new Log();
                        info.ModuleName = tableName;
                        info.Type = operationType;
                        info.Description = note;
                        info.Date = info.CreatorTime = DateTime.Now;
                        info.CreatorUserId = CurrentUser.UserId;
                        info.Account = CurrentUser.Account;
                        info.NickName = CurrentUser.NickName;
                        info.OrganizeId = CurrentUser.OrganizeId;
                        info.IPAddress = CurrentUser.CurrentLoginIP;
                        info.IPAddressName = CurrentUser.IPAddressName;
                        info.Result = true;
                        long lg = _iLogRepository.Insert(info);
                        if (lg > 0)
                        {
                            return true;
                        }
                    }
                }
            }catch(Exception ex)
            {
                Log4NetHelper.Error("",ex);
                return false;
            }
            return false;
        }


        /// <summary>
        /// 根据相关信息，写入用户的操作日志记录
        /// 主要用于写操作模块日志
        /// </summary>
        /// <param name="module">操作模块名称</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="note">操作详细表述</param>
        /// <param name="currentUser">操作用户</param>
        /// <returns></returns>
        public bool OnOperationLog(string module, string operationType, string note, YuebonCurrentUser currentUser)
        {
            //虽然实现了这个事件，但是我们还需要判断该表是否在配置表里面，如果不在，则不记录操作日志。
            //OperationLogSettingInfo settingInfo = BLLFactory<OperationLogSetting>.Instance.FindByTableName(tableName, trans);
            
            if (currentUser != null)
            {
                bool login = operationType == DbLogType.Login.ToString();
                bool visit = operationType == DbLogType.Visit.ToString();
                bool exit = operationType == DbLogType.Exit.ToString();
                bool other = operationType == DbLogType.Other.ToString();
                bool insert = operationType == DbLogType.Create.ToString();
                bool update = operationType == DbLogType.Update.ToString();
                bool delete = operationType == DbLogType.Delete.ToString();
                bool deletesoft = operationType == DbLogType.DeleteSoft.ToString();
                bool exception = operationType == DbLogType.Exception.ToString();
                if (login|| visit|| exit|| other||insert || update || delete || deletesoft || exception)
                {
                    Log info = new Log();
                    info.ModuleName = module;
                    info.Type = operationType;
                    info.Description = note;
                    info.Date = info.CreatorTime = DateTime.Now;
                    info.CreatorUserId = currentUser.UserId;
                    info.Account = currentUser.Account;
                    info.NickName = currentUser.NickName;
                    info.OrganizeId = currentUser.OrganizeId;
                    info.IPAddress = currentUser.CurrentLoginIP;
                    info.IPAddressName = IpAddressUtil.GetCityByIp(currentUser.CurrentLoginIP);
                    info.Result = true;
                    long lg = _iLogRepository.Insert(info);
                    if (lg > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}