using Yuebon.Core.Dtos;
using Yuebon.Commons.Tree;
using Yuebon.Commons.Enums;

namespace Yuebon.Core.Dtos;

/// <summary>
/// 登录成功返回用户信息
/// </summary>
[Serializable]
public class YuebonCurrentUser
{
    /// <summary>
    /// 授权token码
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// appkey
    /// </summary>
    public string AppKey { get; set; }
    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 用户账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    public string RealName { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string HeadIcon { get; set; }
    /// <summary>
    /// 性别
    /// </summary>
    public int? Gender { get; set; }
    /// <summary>
    /// 用户等级
    /// </summary>
    public string MemberGradeId { get; set; }

    /// <summary>
    /// 账号类型
    /// </summary>
    public UserTypeEnum UserType { get; set; }

    /// <summary>
    /// 上级推广员
    /// </summary>
    public long? ReferralUserId { get; set; }
    /// <summary>
    /// 注册时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 组织主键
    /// </summary>
    public virtual long? OrganizeId { get; set; }
    /// <summary>
    /// 角色Id，多个角色Id
    /// </summary>
    public List<long> Role { get; set; }


    /// <summary>
    /// 手机号码
    /// </summary>
    public string MobilePhone { get; set; }
    /// <summary>
    /// 其他对象
    /// </summary>
    public object OtherOpenObj { get; set; }

    /// <summary>
    /// 微信登录SessionId
    /// </summary>
    public string WxSessionId { get; set; }
    /// <summary>
    /// 租户TenantId
    /// </summary>
    public long? TenantId { get; set; }

    /// <summary>
    /// 登录IP地址
    /// </summary>
    public virtual string CurrentLoginIP { get; set; }
    /// <summary>
    /// 登录IP地址
    /// </summary>
    public virtual string IPAddressName { get; set; }


    /// <summary>
    /// 当前访问的系统Id
    /// </summary>
    public long ActiveSystemId { get; set; }
    /// <summary>
    /// 当前访问的系统名称
    /// </summary>
    public string ActiveSystem { get; set; }
    /// <summary>
    /// 当前访问的系统Url
    /// </summary>
    public string ActiveSystemUrl { get; set; }

    /// <summary>
    /// 可以访问子系统
    /// </summary>
    public List<UserVisitSystemnTypes> SubSystemList { get; set; }


    /// <summary>
    /// 授权访问菜单
    /// </summary>
    public List<UserVisitMenus> MenusList { get; set; }
    /// <summary>
    /// 授权访问菜单
    /// </summary>
    public List<VueRouterModel> MenusRouter { get; set; }
    /// <summary>
    /// 授权使用功能
    /// </summary>
    public List<string> Modules { get; set; }
    /// <summary>
    /// 用户设置的软件主题
    /// </summary>
    public string UserTheme { get; set; }

    /// <summary>
    /// token有效时长
    /// </summary>
    public int TokenExpiresIn { get; set; }
}