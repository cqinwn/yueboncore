/*******************************************************************************
 * Copyright © 2017-2019 Yuebon.Framework 版权所有
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
            TimeSpan dep = value-now;

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
        /// 
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
    }
}