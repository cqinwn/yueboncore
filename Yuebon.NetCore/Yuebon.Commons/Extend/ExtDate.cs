/*******************************************************************************
 * Copyright © 2017-2020 Yuebon.Framework 版权所有
 * Author: Yuebon
 * Description: Yuebon快速开发平台
 * Website：http://www.yuebon.com
*********************************************************************************/
using System;

namespace Yuebon.Commons.Extend
{
    /// <summary>
    /// 日期扩展方法
    /// </summary>
    public static class ExtDate
    {
        /// <summary>
        /// 格式：刚刚、几分钟前、几小时前、几天前、yyyy/MM/dd
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEasyString(this DateTime value)
        {
            DateTime now = DateTime.Now;
            if (now < value) return value.ToString("yyyy/MM/dd");
            TimeSpan dep = now - value;
            if (dep.TotalMinutes < 30)
            {
                return "刚刚";
            }
            else if (dep.TotalMinutes >= 30 && dep.TotalMinutes < 60)
            {
                return (int)dep.TotalMinutes + " 分钟前";
            }
            else if (dep.TotalHours < 24)
            {
                return (int)dep.TotalHours + " 小时前";
            }
            else if (dep.TotalDays <= 7)
            {
                return (int)dep.TotalDays + " 天前";
            }
            else if (dep.TotalDays > 7 && dep.TotalDays <= 14)
            {
                int defautlWeek = 0;
                defautlWeek = (int)dep.TotalDays / 7;
                if ((int)dep.TotalDays % 7 > 0)
                {
                    defautlWeek++;
                }
                return defautlWeek + " 周前";
            }
            else if (dep.TotalDays > 14 && dep.TotalDays < 365)
            {
                return value.Month.ToString().PadLeft(2, '0') + "-" +
                    value.Day.ToString().PadLeft(2, '0') + " " + value.Hour + ":" + value.Minute;
            }
            else return (now.Year - value.Year) + " 年前";
        }


        /// <summary>
        /// 格式：即将、几分钟后、几小时后、几天后、yyyy/MM/dd
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEasyStringDQ(this DateTime value)
        {
            DateTime now = DateTime.Now;
            if (value < now) return "已过期";
            TimeSpan dep = value - now;

            if (dep.TotalMinutes < 60)
            {
                return (int)dep.TotalMinutes + " 分钟后";
            }
            else if (dep.TotalHours < 24)
            {
                return (int)dep.TotalHours + " 小时后";
            }
            else if (dep.TotalDays <= 30)
            {
                return (int)dep.TotalDays + " 天后";
            }
            else if (dep.TotalDays > 30 && dep.TotalDays <= 90)
            {
                int defautlWeek = 0;
                defautlWeek = (int)dep.TotalDays / 30;
                if ((int)dep.TotalDays % 30 > 0)
                {
                    defautlWeek++;
                }
                return defautlWeek + " 个月后";
            }
            else if (dep.TotalDays > 90 && dep.TotalDays < 365)
            {
                return value.Month.ToString().PadLeft(2, '0') + "-" +
                    value.Day.ToString().PadLeft(2, '0') + " " + value.Hour + ":" + value.Minute;
            }
            else return " 长期";
        }

        /// <summary>
        /// 格式：几秒、几分钟几秒、几小时几分钟几秒
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBrowseTime(this int value)
        {
            if (value > 0)
            {
                TimeSpan ts = new TimeSpan(0, 0, value);
                if (ts.Hours > 0)
                {
                    if (ts.Seconds > 0)
                    {
                        return ts.Hours + "小时" + ts.Minutes + "分钟" + ts.Seconds + "秒";
                    }
                    else
                    {
                        return ts.Hours + "小时" + ts.Minutes + "分钟";
                    }
                }
                else
                {
                    if (ts.Minutes > 0)
                    {
                        return ts.Minutes + "分钟" + ts.Seconds + "秒";
                    }
                    else
                    {
                        return ts.Seconds + "秒";
                    }
                }
            }
            else
            {
                return "1秒";
            }



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEasyString(this DateTime? value)
        {
            if (value.HasValue) return value.Value.ToEasyString();
            else return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToEasyStringDQ(this DateTime? value)
        {
            if (value.HasValue) return value.Value.ToEasyStringDQ();
            else return string.Empty;
        }

        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <param name="drf">决定返回值形式的枚举</param>
        /// <returns>一个代表年月日的int数组，具体数组长度与枚举参数drf有关</returns>
        public static int[] ToDiffResult(DateTime d1, DateTime d2, DiffResultFormat drf)
        {
            #region 数据初始化
            DateTime max;
            DateTime min;
            int year;
            int month;
            int tempYear, tempMonth;
            if (d1 > d2)
            {
                max = d1;
                min = d2;
            }
            else
            {
                max = d2;
                min = d1;
            }
            tempYear = max.Year;
            tempMonth = max.Month;
            if (max.Month < min.Month)
            {
                tempYear--;
                tempMonth = tempMonth + 12;
            }
            year = tempYear - min.Year;
            month = tempMonth - min.Month;
            #endregion
            #region 按条件计算
            if (drf == DiffResultFormat.dd)
            {
                TimeSpan ts = max - min;
                return new int[] { ts.Days };
            }
            if (drf == DiffResultFormat.mm)
            {
                return new int[] { month + year * 12 };
            }
            if (drf == DiffResultFormat.yy)
            {
                return new int[] { year };
            }
            return new int[] { year, month };
            #endregion
        }
    }

    /// <summary>
    /// 关于返回值形式的枚举
    /// </summary>
    public enum DiffResultFormat
    {
        /// <summary>
        /// 年数和月数
        /// </summary>
        yymm,
        /// <summary>
        /// 年数
        /// </summary>
        yy,
        /// <summary>
        /// 月数
        /// </summary>
        mm,
        /// <summary>
        /// 天数
        /// </summary>
        dd,
    }
}
