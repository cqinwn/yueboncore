namespace Yuebon.AspNetCore.ViewModel;

/// <summary>
/// 数据库连接字符串实体
/// </summary>
[Serializable]
public class DbConnInfo
{
    /// <summary>
    /// 访问地址
    /// </summary>
    [DataMember]
    public string DbAddress { get; set; }
    /// <summary>
    /// 端口，默认SQLServer为1433；Mysql为3306
    /// </summary>
    [DataMember]
    public int DbPort { get; set; }
    /// <summary>
    /// 数据库名称
    /// </summary>
    [DataMember]
    public string DbName { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    [DataMember]
    public string DbUserName { get; set; }
    /// <summary>
    /// 访问密码
    /// </summary>
    [DataMember]
    public string DbPassword { get; set; }
    /// <summary>
    /// 数据库类型
    /// </summary>
    [DataMember]
    public int DbType { get; set; }

}
