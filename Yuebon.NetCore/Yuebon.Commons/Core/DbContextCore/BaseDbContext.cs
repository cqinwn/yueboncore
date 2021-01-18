using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyModel;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Yuebon.Commons.Attributes;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.DbContextCore
{
    /// <summary>
    /// DbContext上下文的实现
    /// </summary>
    public abstract class BaseDbContext : DbContext, IDbContextCore
    {
        #region 基础参数

        /// <summary>
        /// 数据库配置名称，可在子类指定不同的配置名称，用于访问不同的数据库
        /// </summary>
        protected string dbConfigName = "";

        /// <summary>
        /// 是否开启多租户
        /// </summary>
        protected bool isMultiTenant = false;

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
        /// <returns></returns>
        public DatabaseFacade GetDatabase() => Database;
        #endregion

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
        /// 配置，初始化数据库引擎
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            dbConfigName = DBServerProvider.GetConnectionString();
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            this.isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }
            string defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
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
                optionsBuilder.UseMySql(defaultSqlConnectionString, new MySqlServerVersion(new Version(8, 0, 21)), // use MariaDbServerVersion for MariaDB
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend));
            }
            else if (dbType.Contains("ORACLE"))
            {
                optionsBuilder.UseOracle(defaultSqlConnectionString);
            }
            else if (dbType.Contains("SQLITE"))
            {
                optionsBuilder.UseSqlite(defaultSqlConnectionString);
            }
            else if(dbType.Contains("NPGSQL"))
            {
                optionsBuilder.UseNpgsql(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
            //使用查询跟踪行为
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// 模型创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MappingEntityTypes(modelBuilder);
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


        private void MappingEntityTypes(ModelBuilder modelBuilder)
        {
            var assemblies = GetCurrentPathAssembly();
            foreach (var assembly in assemblies)
            {
                var entityTypes = assembly.GetTypes()
                    .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                    .Where(type => type.IsClass)
                    .Where(type => type.BaseType != null)
                    .Where(type => typeof(Entity).IsAssignableFrom(type) || type.IsSubclassOf(typeof(BaseViewModel)));

                foreach (var entityType in entityTypes)
                {
                    if (modelBuilder.Model.FindEntityType(entityType) != null || entityType.Name == "Entity" || entityType.Name == "BaseEntity`1")
                        continue;
                    var table = entityType.GetCustomAttributes<TableAttribute>().FirstOrDefault();
                    modelBuilder.Model.AddEntityType(entityType).SetTableName(table.Name);

                    var ientityTypes = modelBuilder.Model.FindEntityType(entityType);
                    var attr = entityType.GetCustomAttributes<ShardingTableAttribute>().FirstOrDefault();
                    if (attr != null && entityType != null)
                    {
                        modelBuilder.Model.FindEntityType(entityType).SetTableName($"{entityType.Name}{attr.Splitter}{DateTime.Now.ToString(attr.Suffix)}");
                    }

                    if (typeof(IDeleteAudited).IsAssignableFrom(typeof(Entity)))
                    {
                        modelBuilder.Entity<Entity>().HasQueryFilter(m => ((IDeleteAudited)m).DeleteMark == false);
                    }
                    if (IsMultiTenant)
                    {
                        if (typeof(IMustHaveTenant).IsAssignableFrom(typeof(Entity)))
                        {
                            modelBuilder.Entity<Entity>().HasQueryFilter(m => ((IMustHaveTenant)m).TenantId == "");
                        }
                    }
                }
            }
        }


        #region 接口实现


        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new virtual int Add<T>(T entity) where T : class
        {
            base.Add(entity);
            return SaveChanges();
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> AddAsync<T>(T entity) where T : class
        {
            await base.AddAsync(entity);
            return await SaveChangesAsync();
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int AddRange<T>(ICollection<T> entities) where T : class
        {
            base.AddRange(entities);
            return SaveChanges();
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task<int> AddRangeAsync<T>(ICollection<T> entities) where T : class
        {
            await base.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }
        /// <summary>
        /// 统计数量Count()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual int Count<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return where == null ? GetDbSet<T>().Count() : GetDbSet<T>().Count(@where);
        }
        /// <summary>
        /// 统计数量Count()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<int> CountAsync<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return await (where == null ? GetDbSet<T>().CountAsync() : GetDbSet<T>().CountAsync(@where));
        }
        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public virtual int Delete<T, TKey>(TKey key) where T : Entity
        {
            var entity = Find<T>(key);
            Remove(entity);
            return SaveChanges();
        }
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <returns></returns>
        public virtual bool EnsureCreated()
        {
            return Database.EnsureCreated();
        }
        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> EnsureCreatedAsync()
        {
            return await Database.EnsureCreatedAsync();
        }

        /// <summary>
        ///执行Sql，返回影响记录行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlWithNonQuery(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlRaw(sql, parameters);
        }
        /// <summary>
        /// 执行Sql，返回影响记录行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual async Task<int> ExecuteSqlWithNonQueryAsync(string sql, params object[] parameters)
        {
            return await Database.ExecuteSqlRawAsync(sql, parameters);
        }

        /// <summary>
        /// 编辑更新保存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Edit<T>(T entity) where T : class
        {
            base.Update(entity);
            base.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        /// <summary>
        /// 批量更新保存实体
        /// 以添加状态开始跟踪给定的实体和任何其他尚未被跟踪的可访问实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int EditRange<T>(ICollection<T> entities) where T : class
        {
            GetDbSet<T>().AttachRange(entities.ToArray());
            return SaveChanges();
        }
        /// <summary>
        /// 是否存在,存在返回true，不存在返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual bool Exist<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return @where == null ? GetDbSet<T>().Any() : GetDbSet<T>().Any(@where);
        }
        /// <summary>
        /// 是否存在,存在返回true，不存在返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<bool> ExistAsync<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return await Task.FromResult(Exist(where));
        }
        /// <summary>
        /// 根据条件进行查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="include"></param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IQueryable<T> FilterWithInclude<T>(Func<IQueryable<T>, IQueryable<T>> include, Expression<Func<T, bool>> @where) where T : class
        {
            var result = GetDbSet<T>().AsQueryable();
            if (where != null)
                result = GetDbSet<T>().Where(where);
            if (include != null)
                result = include(result);
            return result;
        }

        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Find<T>(object key) where T : class
        {
            return base.Find<T>(key);
        }
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Find<T>(string key) where T : class
        {
            return base.Find<T>(key);
        }
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Find<T, TKey>(TKey key) where T : Entity
        {
            return base.Find<T>(key);
        }
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync<T>(object key) where T : class
        {
            return await base.FindAsync<T>(key);
        }
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync<T, TKey>(TKey key) where T : Entity
        {
            return await base.FindAsync<T>(key);
        }
        /// <summary>
        /// 根据条件查询实体，返回实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="asNoTracking">是否启用模型跟踪，默认为false不跟踪</param>
        /// <returns></returns>
        public virtual IQueryable<T> Get<T>(Expression<Func<T, bool>> @where = null, bool asNoTracking = false) where T : class
        {
            var query = GetDbSet<T>().AsQueryable();
            if (where != null)
                query = query.Where(where);
            if (asNoTracking)
                query = query.AsNoTracking();
            return query;
        }
        /// <summary>
        /// 获取所有实体类型
        /// </summary>
        /// <returns></returns>
        public virtual List<IEntityType> GetAllEntityTypes()
        {
            return Model.GetEntityTypes().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual DbSet<T> GetDbSet<T>() where T : class
        {
            if (Model.FindEntityType(typeof(T)) != null)
                return Set<T>();
            throw new Exception($"类型{typeof(T).Name}未在数据库上下文中注册，请先在DbContextOption设置ModelAssemblyName以将所有实体类型注册到数据库上下文中。");
        }
        /// <summary>
        /// 根据条件查询一个实体，
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual T GetSingleOrDefault<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return where == null ? GetDbSet<T>().SingleOrDefault() : GetDbSet<T>().SingleOrDefault(where);
        }

        /// <summary>
        /// 根据条件查询一个实体，
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<T> GetSingleOrDefaultAsync<T>(Expression<Func<T, bool>> @where = null) where T : class
        {
            return await (where == null ? GetDbSet<T>().SingleOrDefaultAsync() : GetDbSet<T>().SingleOrDefaultAsync(where));
        }

        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">数据实体</param>
        /// <param name="updateColumns">指定字段</param>
        /// <returns></returns>
        public virtual int Update<T>(T model, params string[] updateColumns) where T : class
        {
            if (updateColumns != null && updateColumns.Length > 0)
            {
                if (Entry(model).State == EntityState.Added ||
                    Entry(model).State == EntityState.Detached) GetDbSet<T>().Attach(model);
                foreach (var propertyName in updateColumns)
                {
                    Entry(model).Property(propertyName).IsModified = true;
                }
            }
            else
            {
                Entry(model).State = EntityState.Modified;
            }
            return SaveChanges();
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">数据实体集合</param>
        /// <param name="destinationTableName">数据库表名称</param>
        public virtual void BulkInsert<T>(IList<T> entities, string destinationTableName = null) where T : class
        {
            if (!Database.IsSqlServer() && !Database.IsMySql())
                throw new NotSupportedException("This method only supports for SQL Server or MySql.");
        }
        /// <summary>
        /// Sql查询，并返回实体
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public virtual List<TView> SqlQuery<T, TView>(string sql, params object[] parameters)
            where T : class
        {
            return GetDbSet<T>().FromSqlRaw(sql, parameters).Cast<TView>().ToList();
        }

        /// <summary>
        /// Sql查询，并返回实体
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public virtual async Task<List<TView>> SqlQueryAsync<T, TView>(string sql, params object[] parameters)
            where T : class
            where TView : class
        {
            return await GetDbSet<T>().FromSqlRaw(sql, parameters).Cast<TView>().ToListAsync();
        }
        /// <summary>
        /// 分页查询，SQL语句查询，返回指定输出对象集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="orderBys">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="eachAction"></param>
        /// <returns></returns>
        public virtual PageResult<T> SqlQueryByPagination<T, TView>(string sql, string[] orderBys, int pageIndex, int pageSize,
            Action<TView> eachAction = null) where T : class where TView : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 分页查询，SQL语句查询，返回数据实体集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="orderBys">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="parameters">查询SQL参数</param>
        /// <returns></returns>
        public virtual PageResult<T> SqlQueryByPagination<T>(string sql, string[] orderBys, int pageIndex, int pageSize,
            params DbParameter[] parameters) where T : class, new()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据sql语句返回DataTable数据，具体在实现在特定数据库上上下文中实现
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="cmdTimeout">执行超时时间，默认30毫秒</param>
        /// <param name="parameters">Sql语句参数</param>
        /// <returns></returns>
        public abstract DataTable GetDataTable(string sql, int cmdTimeout = 30, params DbParameter[] parameters);
        /// <summary>
        /// 根据sql语句返回List数据，具体在实现在特定数据库上上下文中实现
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="cmdTimeout">执行超时时间，默认30毫秒</param>
        /// <param name="parameters">Sql语句参数</param>
        /// <returns></returns>
        public abstract List<DataTable> GetDataTables(string sql, int cmdTimeout = 30, params DbParameter[] parameters);

        #region 显式编译的查询,提高查询性能
        /// <summary>
        /// 根据主键查询返回一个实体，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public T GetByCompileQuery<T, TKey>(TKey id) where T : Entity
        {
            return EF.CompileQuery((DbContext context, TKey id) => context.Set<T>().Find(id))(this, id);
        }
        /// <summary>
        /// 根据主键查询返回一个实体，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        public Task<T> GetByCompileQueryAsync<T, TKey>(TKey id) where T : Entity
        {
            return EF.CompileAsyncQuery((DbContext context, TKey id) => context.Set<T>().Find(id))(this, id);
        }
        /// <summary>
        /// 根据条件查询返回实体集合，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public IList<T> GetByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().AsNoTracking().Where(filter).ToList())(this);
        }
        /// <summary>
        /// 根据条件查询返回实体集合，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public Task<List<T>> GetByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().AsNoTracking().Where(filter).ToList())(this);
        }

        /// <summary>
        /// 根据条件查询一个实体，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public T FirstOrDefaultByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().AsNoTracking().FirstOrDefault(filter))(this);
        }
        /// <summary>
        /// 根据条件查询一个实体，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public Task<T> FirstOrDefaultByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().AsNoTracking().FirstOrDefault(filter))(this);
        }
        /// <summary>
        /// 根据条件查询一个实体，启用模型跟踪，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public T FirstOrDefaultWithTrackingByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().FirstOrDefault(filter))(this);
        }
        /// <summary>
        /// 根据条件查询一个实体，启用模型跟踪，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public Task<T> FirstOrDefaultWithTrackingByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().FirstOrDefault(filter))(this);
        }
        /// <summary>
        /// 统计数量Count()，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public int CountByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileQuery((DbContext context) => context.Set<T>().Count(filter))(this);
        }
        /// <summary>
        /// 统计数量Count()，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public Task<int> CountByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            if (filter == null) filter = m => true;
            return EF.CompileAsyncQuery((DbContext context) => context.Set<T>().Count(filter))(this);
        }
        #endregion
        #endregion

    }
}
