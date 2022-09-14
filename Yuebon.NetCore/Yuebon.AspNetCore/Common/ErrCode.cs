namespace Yuebon.AspNetCore.Models
{
    /// <summary>
    /// 错误代码描述
    /// </summary>
    public static class ErrCode
    {

        /// <summary>
        /// 请求成功
        /// </summary>
        public static string err0 = "请求成功";

        /// <summary>
        /// 请求成功代码0
        /// </summary>
        public static string successCode = "0";

        /// <summary>
        /// 请求失败
        /// </summary>
        public static string err1 = "请求失败";

        /// <summary>
        /// 请求失败代码1
        /// </summary>
        public static string failCode = "1";

        /// <summary>
        /// 获取access_token时AppID或AppSecret错误。请开发者认真比对appid和AppSecret的正确性，或查看是否正在为恰当的应用调用接口
        /// </summary>
        public static string err40001 = "获取access_token时AppID或AppSecret错误。请开发者认真比对appid和AppSecret的正确性，或查看是否正在为恰当的应用调用接口";

        /// <summary>
        /// 调用接口的服务器URL地址不正确，请联系供应商进行设置
        /// </summary>
        public static string err40002 = "调用接口的服务器URL地址不正确，请联系供应商进行授权";

        /// <summary>
        /// 请确保grant_type字段值为client_credential
        /// </summary>
        public static string err40003 = "请确保grant_type字段值为client_credential";

        /// <summary>
        /// 不合法的凭证类型
        /// </summary>
        public static string err40004 = "不合法的凭证类型";

        /// <summary>
        /// 用户令牌accesstoken超时失效
        /// </summary>
        public static string err401 = "用户令牌accesstoken超时失效";

        /// <summary>
        /// 您未被授权使用该功能，请重新登录试试或联系管理员进行处理
        /// </summary>
        public static string err403 = "您未被授权使用该功能，请重新登录试试或联系系统管理员进行处理";

        /// <summary>
        /// 传递参数出现错误
        /// </summary>
        public static string err40007 = "传递参数出现错误";

        /// <summary>
        /// 用户未登录或超时
        /// </summary>
        public static string err40008 = "用户未登录或超时";
        /// <summary>
        /// 程序异常
        /// </summary>
        public static string err40110 = "程序异常";

        /// <summary>
        /// 更新数据失败
        /// </summary>
        public static string err43001 = "新增数据失败";

        /// <summary>
        /// 更新数据失败
        /// </summary>
        public static string err43002 = "更新数据失败";

        /// <summary>
        /// 物理删除数据失败
        /// </summary>
        public static string err43003 = "删除数据失败";

        /// <summary>
        /// 该用户不存在
        /// </summary>
        public static string err50001 = "该用户不存在";

        /// <summary>
        /// 该用户已存在
        /// </summary>
        public static string err50002 = "用户已存在，请登录或重新注册！";

        /// <summary>
        /// 会员注册失败
        /// </summary>
        public static string err50003 = "会员注册失败";
        /// <summary>
        /// 请求超时
        /// </summary>
        public static string err50004 = "请求超时";

        /// <summary>
        /// 查询数据不存在
        /// </summary>
        public static string err60001 = "查询数据不存在";
    }
}
