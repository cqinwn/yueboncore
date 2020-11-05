using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Options;

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
        /// 构造函数
        /// </summary>
        public DbContextFactory()
        {
        }
        public void AddDbContext<TContext>(DbContextOption option)
            where TContext : BaseDbContext, IDbContextCore
        {
            ServiceCollection.AddDbContext<IDbContextCore, TContext>(option);
        }

        public void AddDbContext<ITContext, TContext>(DbContextOption option)
            where ITContext : IDbContextCore
            where TContext : BaseDbContext, ITContext
        {
            ServiceCollection.AddDbContext<ITContext, TContext>(option);
        }
    }
}
