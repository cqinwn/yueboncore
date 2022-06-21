using AutoMapper;
using System.Collections;
using System.Linq.Expressions;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Properties;

namespace Yuebon.Commons.Mapping
{
    /// <summary>
    /// 对象映射扩展操作
    /// </summary>
    public static class MapperExtensions
    {
        private static IMapper _mapper;

        /// <summary>
        /// 设置对象映射执行者
        /// </summary>
        /// <param name="mapper">映射执行者</param>
        public static void SetMapper(IMapper mapper)
        {
            mapper.CheckNotNull("mapper");
            _mapper = mapper;
        }

        /// <summary>
        /// 将对象映射为指定类型
        /// </summary>
        /// <typeparam name="TTarget">要映射的目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <returns>目标类型的对象</returns>
        public static TTarget MapTo<TTarget>(this object source)
        {
            CheckMapper();
            return _mapper.Map<TTarget>(source);
        }

        /// <summary>
        /// 使用源类型的对象更新目标类型的对象
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="target">待更新的目标对象</param>
        /// <returns>更新后的目标类型对象</returns>
        public static TTarget MapTo<TSource, TTarget>(this TSource source, TTarget target)
        {
            CheckMapper();
            return _mapper.Map(source, target);
        }

        /// <summary>
        /// 将数据源映射为指定<typeparamref name="TOutputDto"/>的集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TOutputDto"></typeparam>
        /// <param name="source"></param>
        /// <param name="membersToExpand"></param>
        /// <returns></returns>
        public static IQueryable<TOutputDto> ToOutput<TEntity, TOutputDto>(this IQueryable<TEntity> source,
            params Expression<Func<TOutputDto, object>>[] membersToExpand)
        {
            CheckMapper();
            return _mapper.ProjectTo<TOutputDto>(source, membersToExpand);
        }

        /// <summary>
        /// 集合到集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>

        public static List<T> MapTo<T>(this IEnumerable obj)
        {
            CheckMapper();
            return _mapper.Map<List<T>>(obj);
        }

        /// <summary>
        /// 验证映射执行者是否为空
        /// </summary>
        private static void CheckMapper()
        {
            if (_mapper == null)
            {
                throw new NullReferenceException(Resources.Map_MapperIsNull);
            }
        }
    }
}
