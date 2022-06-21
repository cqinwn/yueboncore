using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Yuebon.Commons.Extend
{
    /// <summary>
    /// IEnumerable扩展类
    /// </summary>
    [DebuggerStepThrough]
    public static class ExtIEnumerable
    {
        /// <summary>
        /// 循环IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> fun)
        {
            foreach (T item in source)
            {
                fun(item);
            }
            return source;
        }
        /// <summary>
        /// IEnumerable转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public static List<TResult> ToList<T, TResult>(this IEnumerable<T> source, Func<T, TResult> fun)
        {
            List<TResult> result = new List<TResult>();
            source.Each(m => result.Add(fun(m)));
            return result;
        }
        
    }
}
