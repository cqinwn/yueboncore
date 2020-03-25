using Microsoft.AspNetCore.Http;
using System;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Net;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Cache;
using Newtonsoft.Json;
using Yuebon.Commons.Json;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class LogService: BaseService<Log, LogOutputDto, string>, ILogService
    {
        private readonly ILogRepository _iLogRepository;
        private readonly IUserRepository _iuserRepository;

        private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userRepository"></param>
        public LogService(ILogRepository repository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _iLogRepository = repository;
            _iuserRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
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
            //虽然实现了这个事件，但是我们还需要判断该表是否在配置表里面，如果不在，则不记录操作日志。
            //OperationLogSettingInfo settingInfo = BLLFactory<OperationLogSetting>.Instance.FindByTableName(tableName, trans);
            //if (settingInfo != null)
            //{

            UserAuthSession CurrentUser = new UserAuthSession();//SessionHelper.GetSession<UserAuthSession>("CurrentUser");
            //if (CurrentUser == null)
            //{
                //string userId= DEncrypt.Decrypt(CookiesHelper.ReadCookie(_httpContextAccessor.HttpContext,"loginuser"),"qingwen");
                //YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                //UserAuthSession CurrentUser  = JsonConvert.DeserializeObject<UserAuthSession>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
            //}
            if (CurrentUser != null)
            {
                bool insert = operationType == DbLogType.Create.ToString(); ;//&& settingInfo.InsertLog;
                bool update = operationType == DbLogType.Update.ToString();// && settingInfo.UpdateLog;
                bool delete = operationType == DbLogType.Delete.ToString();// && settingInfo.DeleteLog;
                bool deletesoft = operationType == DbLogType.DeleteSoft.ToString();// && settingInfo.DeleteLog;
                bool exception = operationType == DbLogType.Exception.ToString();// && settingInfo.DeleteLog;
                if (insert || update || delete || deletesoft || exception)
                {
                    Log info = new Log();
                    info.ModuleName = tableName;
                    info.Type = operationType;
                    info.Description = note;
                    info.Date = info.CreatorTime = DateTime.Now;
                    info.CreatorUserId = CurrentUser.UserId;
                    info.Account = CurrentUser.Account;
                    info.NickName = CurrentUser.RealName;
                    info.OrganizeId = CurrentUser.OrganizeId;
                    info.IPAddress = CurrentUser.CurrentLoginIP;
                    info.IPAddressName = IpAddressUtil.GetCityByIp(CurrentUser.CurrentLoginIP);
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