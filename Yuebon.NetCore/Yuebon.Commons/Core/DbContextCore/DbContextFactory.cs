using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
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
    public class DbContextFactory//:IDbContextFactory
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
        private IConfiguration Configuration { get; }
        private string[] ReadConnectionStrings;
        public DbContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
            ReadConnectionStrings = Configuration.GetConnectionString("EFCoreTestToRead").Split(",");
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
        ///// <summary>
        ///// 创建数据库读写上下文
        ///// </summary>
        ///// <param name="writeAndRead">指定读、写操作</param>
        ///// <returns></returns>
        //public BaseDbContext CreateContext(WriteAndReadEnum writeAndRead)
        //{
        //    string dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
        //    string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
        //    string defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
        //    if (conStringEncrypt == "true")
        //    {
        //        defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
        //    }
        //    DbContextOption option=new DbContextOption();
        //    switch (writeAndRead)
        //    {
        //        case WriteAndReadEnum.Write:
        //            option.dbConfigName = dbConfigName;
        //            break;
        //        case WriteAndReadEnum.Read:
        //            option.dbConfigName = GetReadConnectionString();
        //            break;
        //        default:
        //            option.dbConfigName = dbConfigName;
        //            break;
        //    }
        //    return new BaseDbContext(option);
        //}
        //private string GetReadConnectionString()
        //{
        //    /*
        //     * 随机策略
        //     * 权重策略
        //     * 轮询策略
        //     */

        //    //随机策略
        //    string connectionString = ReadConnectionStrings[new Random().Next(0, ReadConnectionStrings.Length)];

        //    return connectionString;
        //}
    }
}
