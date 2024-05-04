namespace Yuebon.Security.Models;
/// <summary>
/// 系统用户角色表
/// </summary>
[SugarTable("Sys_User_Role", "系统用户角色表")]
[Serializable]
public class UserRole: BaseEntity
{
    /// <summary>
    /// 用户Id
    /// </summary>
    [SugarColumn(ColumnDescription = "用户Id")]
    public long UserId { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(UserId))]
    public User SysUser { get; set; }

    /// <summary>
    /// 角色Id
    /// </summary>
    [SugarColumn(ColumnDescription = "角色Id")]
    public long RoleId { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(RoleId))]
    public Role SysRole { get; set; }
}
