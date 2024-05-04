using Google.Protobuf.WellKnownTypes;
using SqlSugar;
using StackExchange.Profiling;
using System.Linq.Expressions;
using Yuebon.Commons;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Enums;
using Yuebon.Core.DataManager;
using Yuebon.Core.Models;
using Yuebon.Extensions.Filters;
using Yuebon.Security.Models;

namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// SqlSugar 启动服务
/// </summary>
public static class SqlSugarSetup
{
    /// <summary>
    /// SqlSugar 上下文初始化
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddSqlSugarSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        List<DbConnections> allDbs = DBServerProvider.GetAllDbConnections();
        // 把多个连接对象注入服务，SqlSugarScope用AddSingleton单例
        services.AddSingleton<ISqlSugarClient>(o =>
        {
            // 连接字符串
            var connectionConfigs = new List<ConnectionConfig>();
            bool conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt").ToBool();
            allDbs.ForEach(m =>
            {
                ConnectionConfig config = new ConnectionConfig()
                {
                    ConfigId = m.ConnId.ToLower(),
                    ConnectionString =conStringEncrypt? DEncrypt.Decrypt(m.MasterDB.ConnectionString): m.MasterDB.ConnectionString,
                    DbType = (DbType)m.MasterDB.DatabaseType,
                    IsAutoCloseConnection = true,
                };
                if (m.ReadDB!=null)
                {
                    List<SlaveConnectionConfig> slaveConnectionConfigs= new List<SlaveConnectionConfig>();
                    m.ReadDB.ForEach(r =>
                    {
                        if (r.Enabled)
                        {
                            slaveConnectionConfigs.Add(new SlaveConnectionConfig()
                            {
                                HitRate = r.HitRate,
                                ConnectionString = conStringEncrypt ? DEncrypt.Decrypt(r.ConnectionString) : r.ConnectionString
                            });
                        }
                    });
                    config.SlaveConnectionConfigs = slaveConnectionConfigs;
                }
                connectionConfigs.Add(config);
            });
            return new SqlSugarScope(connectionConfigs, db =>
            {
                connectionConfigs.ForEach(config =>
                {
                    var dbProvider = db.GetConnectionScope((string)config.ConfigId);

                    dbProvider.Aop.OnError = (ex) =>
                    {
                        var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                        MiniProfiler.Current.CustomTiming("SqlSugar", $"{ex.Message}{Environment.NewLine}{ex.Sql}{pars}{Environment.NewLine}", "Error");
                    };
                    dbProvider.Aop.OnLogExecuted = (sql, p) =>
                    {
                        if (Appsettings.app(new string[] { "AppSetting", "SqlAOP", "Enabled" }).ObjToBool())
                        {
                            string logSql = $"{GetParas(p)}【SQL语句】:{GetWholeSql(p, sql)}【耗时】:{dbProvider.Ado.SqlExecutionTime.TotalMilliseconds}ms";
                            MiniProfiler.Current.CustomTiming("SQL:", logSql);
                        }
                    };
                    dbProvider.Aop.DataExecuting = (oldValue, entityInfo) =>
                    {
                        // 新增操作
                        if (entityInfo.OperationType == DataFilterType.InsertByObject)
                        {
                            if (entityInfo.PropertyName == "CreatorTime")
                                entityInfo.SetValue(DateTime.Now);
                            if (Appsettings.User != null)
                            {
                                if (entityInfo.PropertyName == "TenantId")
                                {
                                    var tenantId = ((dynamic)entityInfo.EntityValue).TenantId;
                                    if (tenantId == null || tenantId == 0)
                                        entityInfo.SetValue(Appsettings.User.TenantId);
                                }
                                if (entityInfo.PropertyName == "CreatorUserId")
                                {
                                    var createUserId = ((dynamic)entityInfo.EntityValue).CreatorUserId;
                                    if (createUserId == 0 || createUserId == null)
                                        entityInfo.SetValue(Appsettings.User?.UserId);
                                }
                                if (entityInfo.PropertyName == "CreateOrgId")
                                {
                                    var createOrgId = ((dynamic)entityInfo.EntityValue).CreateOrgId;
                                    if (createOrgId == 0 || createOrgId == null)
                                        entityInfo.SetValue(Appsettings.User?.CreateOrgId);
                                }
                            }
                        }
                        // 更新操作
                        if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                        {
                            if (entityInfo.PropertyName == "LastModifyTime")
                                entityInfo.SetValue(DateTime.Now);
                            if (entityInfo.PropertyName == "LastModifyUserId")
                                entityInfo.SetValue(Appsettings.User?.UserId);
                        }
                    };
                    // 超管排除其他过滤器
                    if (Appsettings.User?.UserType == UserTypeEnum.SuperAdmin) return;
                    // 配置假删除过滤器
                    db.QueryFilter.AddTableFilter<IDeleteAudited>(u => u.DeleteMark == false);
                    //配置租户过滤器
                    SetTenantEntityFilter(dbProvider);

                    // 配置用户机构（数据范围）过滤器
                    SqlSugarFilter.SetOrgEntityFilter(dbProvider);

                    // 配置自定义过滤器
                    SqlSugarFilter.SetCustomEntityFilter(dbProvider);

                });
            });
        });


        services.AddScoped(typeof(BaseRepository<>)); // 仓储注册
    }


    private static string GetWholeSql(SugarParameter[] paramArr, string sql)
    {
        foreach (var param in paramArr)
        {
            sql.Replace(param.ParameterName, param.Value.ToString());
        }

        return sql;
    }

    private static string GetParas(SugarParameter[] pars)
    {
        string key = string.Empty;
        if (pars.Length > 0)
        {
            key = "【SQL参数】：";
            foreach (var param in pars)
            {
                key += $"{param.ParameterName}：{param.Value}\n";
            }
        }
        return key;
    }

    /// <summary>
    /// 配置租户实体过滤器
    /// </summary>
    public static void SetTenantEntityFilter(SqlSugarScopeProvider db)
    {
        // 获取租户实体数据表集合
        var dataEntityTypes = Appsettings.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
            && u.BaseType == typeof(TenantEntity));
        if (!dataEntityTypes.Any()) return;

        var tenantId = Appsettings.User?.TenantId;
        if (tenantId == 0||tenantId==null) return;

        foreach (var dataEntityType in dataEntityTypes)
        {
            Expression<Func<TenantEntity, bool>> dynamicExpression = u => u.TenantId == tenantId;
            db.QueryFilter.Add(new TableFilterItem<object>(dataEntityType, dynamicExpression));
        }
    }


}