using Microsoft.Extensions.DependencyInjection;
using Yuebon.Commons.IDbContext;

namespace Yuebon.Commons.DbContextCore
{
    /// <summary>
    /// 上下文工厂类
    /// </summary>
    public class DbContextFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static DbContextFactory Instance => new DbContextFactory();
        /// <summary>
        /// 服务
        /// </summary>
        public IServiceCollection ServiceCollection { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public DbContextFactory()
        {
        }
        /// <summary>
        /// 注入上下文服务
        /// </summary>
        /// <typeparam name="TContext">上下文实现类</typeparam>
        public void AddDbContext<TContext>()
            where TContext : BaseDbContext, IDbContextCore
        {
            ServiceCollection.AddDbContext<IDbContextCore,TContext>();
        }
        /// <summary>
        /// 注入上下文服务
        /// </summary>
        /// <typeparam name="ITContext">上下文接口</typeparam>
        /// <typeparam name="TContext">上下文实现类</typeparam>
        public void AddDbContext<ITContext, TContext>()
            where ITContext : IDbContextCore
            where TContext : BaseDbContext, ITContext
        {
            ServiceCollection.AddDbContext<ITContext, TContext>();
        }
    }
}
