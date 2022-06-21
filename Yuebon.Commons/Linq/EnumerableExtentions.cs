namespace Yuebon.Commons.Linq
{
    public static partial class EnumerableExtentions
    {
        public static T[] AsToArray<T>(this IEnumerable<T> source, bool isNullAsEmpty = false)
        {
            if (source == null)
            {
                return isNullAsEmpty ? new T[0] : null;
            }

            return source as T[] ?? source.ToArray();
        }

        public static List<T> AsToList<T>(this IEnumerable<T> source, bool isNullAsEmpty = false)
        {
            if (source == null)
            {
                return isNullAsEmpty ? new List<T>() : null;
            }
            return source as List<T> ?? source.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="process"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> process)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (process == null)
            {
                throw new ArgumentNullException(nameof(process));
            }

            foreach (T item in source)
            {
                process(item);
            }
        }

        public static void ForEach<T, R>(this IEnumerable<T> source, Func<T, R> process)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (process == null)
            {
                throw new ArgumentNullException(nameof(process));
            }

            foreach (T item in source)
            {
                process(item);
            }
        }
    }
}
