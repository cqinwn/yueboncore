
using System.Security.Claims;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;

namespace Yuebon.Security.Services;

/// <summary>
/// 
/// </summary>
public class LogService : BaseService<Log, LogOutputDto>, ILogService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logRepository"></param>
    public LogService(ILogRepository logRepository)
    {
        repository= logRepository;
    }

    public async void AddAsync(Log entity)
    {
       await repository.InsertAsync(entity);
    }
    /// <summary>
    /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
    /// </summary>
    /// <param name="search">��ѯ������</param>
    /// <returns>ָ������ļ���</returns>
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
        List<Log> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
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
    /// ���������Ϣ��д���û��Ĳ�����־��¼
    /// </summary>
    /// <param name="tableName">����������</param>
    /// <param name="operationType">��������</param>
    /// <param name="note">������ϸ����</param>
    /// <returns></returns>
    public async Task<bool> OnOperationLog(string tableName, string operationType, string note)
    {
        try
        {
            //��Ȼʵ��������¼����������ǻ���Ҫ�жϸñ��Ƿ������ñ����棬������ڣ��򲻼�¼������־��
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
            var user = yuebonCacheHelper.Get("login_user_" + userId).ToJson().ToObject<YuebonCurrentUser>();
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
                    info.Description = note;
                    info.Date = info.CreatorTime = DateTime.Now;
                    info.CreatorUserId = CurrentUser.UserId;
                    info.Account = CurrentUser.Account;
                    info.RealName = CurrentUser.NickName;
                    info.IPAddress = CurrentUser.CurrentLoginIP;
                    long lg =await repository.InsertAsync(info);
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
    /// ���������Ϣ��д���û��Ĳ�����־��¼
    /// ��Ҫ����д����ģ����־
    /// </summary>
    /// <param name="module">����ģ������</param>
    /// <param name="operationType">��������</param>
    /// <param name="note">������ϸ����</param>
    /// <param name="currentUser">�����û�</param>
    /// <returns></returns>
    public async Task<bool> OnOperationLog(string module, string operationType, string note, YuebonCurrentUser currentUser)
    {
        //��Ȼʵ��������¼����������ǻ���Ҫ�жϸñ��Ƿ������ñ����棬������ڣ��򲻼�¼������־��
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
                info.Description = note;
                info.Date = info.CreatorTime = DateTime.Now;
                info.CreatorUserId = currentUser.UserId;
                info.Account = currentUser.Account;
                info.RealName = currentUser.NickName;
                info.IPAddress = currentUser.CurrentLoginIP;
                long lg = repository.Insert(info);
                if (lg > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
}