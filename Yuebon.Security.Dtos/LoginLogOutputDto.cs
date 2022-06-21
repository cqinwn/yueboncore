namespace Yuebon.Security.Dtos;

public class LoginLogOutputDto
{
    public long Id { get; set; }

    /// <summary>
    /// 日期
    /// </summary>
    public  DateTime? Date { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public  string Account { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public  string NickName { get; set; }

    /// <summary>
    /// 组织主键
    /// </summary>
    public  long? OrganizeId { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    public  string IPAddress { get; set; }

    /// <summary>
    /// IP所在城市
    /// </summary
    public  string IPAddressName { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    public  string Browser { get; set; }

    /// <summary>
    /// 操作系统
    /// </summary>
    public  string OS { get; set; }

    /// <summary>
    /// 结果
    /// </summary>
    public  bool? Result { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public  string Description { get; set; }


    /// <summary>
    /// 删除标志
    /// </summary>
    public  bool? DeleteMark { get; set; }

    /// <summary>
    /// 有效标志
    /// </summary>
    public  bool EnabledMark { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public  DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 创建用户主键
    /// </summary>
    public  long? CreatorUserId { get; set; }


    /// <summary>
    /// 删除时间
    /// </summary>
    public  DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除用户
    /// </summary>
    public  long? DeleteUserId { get; set; }
}
