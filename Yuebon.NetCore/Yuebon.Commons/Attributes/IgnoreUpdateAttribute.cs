namespace Yuebon.Commons.Attributes
{

    /// <summary>
    /// 忽略更新种子数据特性
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class IgnoreUpdateAttribute : Attribute
    {
    }
}
