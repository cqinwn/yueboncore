using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 用对象属性及属性值替换预设字符串
    /// 主要应用于模板打印，导出
    /// </summary>
    public class ObjectReplaceHtmlHelper
    {

        /// <summary>
        /// 用实体属性替换相关的字符串，主要应用于打印和导出
        /// 方法将日期时间型属性值截取为日期型，格式“YYYY-MM-DD”，
        /// 将布尔型属性值调整为是或否
        /// </summary>
        /// <param name="objInfo">实体对象</param>
        /// <param name="strReplace">要替换的原字符串</param>
        /// <param name="prefix">变量前缀</param>
        /// <returns></returns>
        public static string ObjectReplaceString(object objInfo, string strReplace, string prefix = "")
        {
            string result = string.Empty;
            string nowReplace = strReplace;
            Type type = objInfo.GetType();//获得该类的Type
            foreach (PropertyInfo pi in type.GetProperties())
            {
                string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                var value = pi.GetValue(objInfo, null);//用pi.GetValue获得值
                var propertyType = value?.GetType() ?? typeof(object);//获得属性的类型
                string replaceOld = "$" + prefix + name;
                string newStrValue = "";
                if (value != null)
                {
                    //将日期时间型和布尔型数据进行处理，其他枚举数据提前处理
                    if (propertyType.Name == "DateTime")//如果是时间型取日期
                    {
                        newStrValue = value.ToString().Substring(0, 10);
                    }
                    else if (propertyType.Name == "Boolean")//布尔型转为是或否
                    {
                        bool blvalue;
                        if (bool.TryParse(value.ToString(), out blvalue))
                        {
                            newStrValue = "是";
                        }
                        else
                        {
                            newStrValue = "否";
                        }
                    }
                    else
                    {
                        newStrValue = value.ToString();
                    }
                }
                nowReplace = nowReplace.Replace(replaceOld, newStrValue);
            }
            result += nowReplace;
            return result;
        }
    }
}
