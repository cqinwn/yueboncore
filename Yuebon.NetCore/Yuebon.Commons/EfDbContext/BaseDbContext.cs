using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Models;

namespace Yuebon.Commons.EfDbContext
{
    /// <summary>
    /// DbContext上下文的实现
    /// </summary>
    public sealed class BaseDbContext : DbContext
    {


        /// <summary>
        /// 数据库连接配置
        /// </summary>
        protected string defaultSqlConnectionString = "";

        /// <summary>
        /// 数据库配置名称
        /// </summary>
        protected string dbConfigName = "";

        /// <summary>
        /// 是否开启多租户
        /// </summary>
        protected bool isMultiTenant = false;

        /// <summary>
        /// 数据库配置名称，默认为空。
        /// 可在子类指定不同的配置名称，用于访问不同的数据库
        /// </summary>
        public string DbConfigName
        {
            get { return dbConfigName; }
            set { dbConfigName = value; }
        }

        /// <summary>
        /// 数据库访问对象的外键约束
        /// </summary>
        public bool IsMultiTenant
        {
            get
            {
                return isMultiTenant;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected BaseDbContext()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// 配置
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            this.isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }
            defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
            if (conStringEncrypt == "true")
            {
                defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
            }
            string dbType = dbConfigName.ToUpper();
            if (dbType.Contains("MSSQL"))
            {
                optionsBuilder.UseSqlServer(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MYSQL"))
            {
                optionsBuilder.UseMySQL(defaultSqlConnectionString);
            }
            else if (dbType.Contains("ORACLE"))
            {
                optionsBuilder.UseOracle(defaultSqlConnectionString);
            }
            else if (dbType.Contains("SQLITE"))
            {
                optionsBuilder.UseSqlite(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblies = GetCurrentPathAssembly();
            foreach (var assembly in assemblies)
            {
                var entityTypes = assembly.GetTypes()
                    .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                    .Where(type => type.IsClass)
                    .Where(type => type.BaseType != null)
                    .Where(type => typeof(Entity).IsAssignableFrom(type));

                foreach (var entityType in entityTypes)
                {
                    if (modelBuilder.Model.FindEntityType(entityType) != null||entityType.Name== "Entity"||entityType.Name== "BaseEntity`1")
                        continue;
                    var table=entityType.GetCustomAttributes<TableAttribute>().FirstOrDefault();
                    modelBuilder.Model.AddEntityType(entityType).SetTableName(table.Name);
                }
            }
            base.OnModelCreating(modelBuilder);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Assembly> GetCurrentPathAssembly()
        {
            var dlls = DependencyContext.Default.CompileLibraries
                .Where(x => !x.Name.StartsWith("Microsoft") && !x.Name.StartsWith("System")&& x.Name.StartsWith("Yuebon"))
                .ToList();
            var list = new List<Assembly>();
            if (dlls.Any())
            {
                foreach (var dll in dlls)
                {
                    if (dll.Type == "project")
                    {
                        list.Add(Assembly.Load(dll.Name));
                    }
                }
            }
            return list;
        }
    }
}
