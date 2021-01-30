using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.DataManager;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Options;

namespace Yuebon.Commons.DbContextCore
{
    /// <summary>
    /// 上下文工厂类
    /// </summary>
    public class DbContextFactory:IDbContextFactory
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

        /// <summary>
        /// 向服务注入上下文
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="option"></param>
        public void AddDbContext<TContext>(DbContextOption option)
            where TContext : BaseDbContext, IDbContextCore
        {
            ServiceCollection.AddDbContext<IDbContextCore, TContext>(option);
        }
        /// <summary>
        /// 向服务注入上下文
        /// </summary>
        /// <typeparam name="ITContext">上下文接口</typeparam>
        /// <typeparam name="TContext">上下文实现类</typeparam>
        /// <param name="option"></param>
        public void AddDbContext<ITContext, TContext>(DbContextOption option)
            where ITContext : IDbContextCore
            where TContext : BaseDbContext, ITContext
        {
            ServiceCollection.AddDbContext<ITContext, TContext>(option);
        }

        /// <summary>
        /// 创建数据库读写上下文
        /// </summary>
        /// <param name="writeAndRead">指定读、写操作</param>
        /// <returns></returns>
        public BaseDbContext CreateContext(WriteAndReadEnum writeAndRead)
        {
            DbConnectionOptions dbConnectionOptions =new DbConnectionOptions();
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Write:
                    dbConnectionOptions = DBServerProvider.GeDbConnectionOptions(true);
                    break;
                case WriteAndReadEnum.Read:
                    dbConnectionOptions = DBServerProvider.GeDbConnectionOptions(false);
                    break;
                default:
                    break;
            }
            return new BaseDbContext(dbConnectionOptions);
        }


        /// <summary>
        /// 创建数据库读写上下文
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="writeAndRead">指定读、写操作</param>
        /// <returns></returns>
        public BaseDbContext CreateContext<TEntity>(WriteAndReadEnum writeAndRead)
        {
            DbConnectionOptions dbConnectionOptions = new DbConnectionOptions();
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Write:
                    dbConnectionOptions = DBServerProvider.GeDbConnectionOptions<TEntity>(true);
                    break;
                case WriteAndReadEnum.Read:
                    dbConnectionOptions = DBServerProvider.GeDbConnectionOptions<TEntity>(false);
                    break;
                default:
                    break;
            }
            return new BaseDbContext(dbConnectionOptions);
        }
    }
}
