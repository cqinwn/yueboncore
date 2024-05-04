
using SqlSugar;
using System.Collections.Concurrent;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Const;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Enums;
using Yuebon.Core.Models;

namespace Yuebon.Core.Filters;


public static class SqlSugarFilter
{

    /// <summary>
    /// 配置用户机构集合过滤器
    /// </summary>
    public static void SetOrgEntityFilter(SqlSugarScopeProvider db)
    {
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        // 若仅本人数据，则直接返回
        if (SetDataScopeFilter(db) == (int)RoleDataScopeEnum.Self) return;

        var userId =  Appsettings.User?.UserId;
        if (userId == 0 || userId == null) return;

        // 配置用户机构集合缓存
        var cacheKey = $"{CacheConst.KeyUserOrg}{userId}";
        var orgFilter = yuebonCacheHelper.Get<ConcurrentDictionary<Type, LambdaExpression>>(cacheKey);
        if (orgFilter == null)
        {
            // 获取用户所属机构
            var orgIds = Appsettings.GetService<OrganizeService>().GetUserOrgIdList().GetAwaiter().GetResult();
            if (orgIds == null || orgIds.Count == 0) return;

            // 获取业务实体数据表
            var entityTypes = Appsettings.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.IsSubclassOf(typeof(i)));
            if (!entityTypes.Any()) return;

            orgFilter = new ConcurrentDictionary<Type, LambdaExpression>();
            foreach (var entityType in entityTypes)
            {
                // 排除非当前数据库实体
                var tAtt = entityType.GetCustomAttribute<TenantAttribute>();
                if ((tAtt != null && db.CurrentConnectionConfig.ConfigId.ToString() != tAtt.configId.ToString()))
                    continue;

                var lambda = DynamicExpressionParser.ParseLambda(new[] {
                    Expression.Parameter(entityType, "u") }, typeof(bool), $"@0.Contains(u.{nameof(BaseEntity.CreateOrgId)}??{default(long)})", orgIds);
                db.QueryFilter.AddTableFilter(entityType, lambda);
                orgFilter.TryAdd(entityType, lambda);
            }
            yuebonCacheHelper.Add(cacheKey, orgFilter);
        }
        else
        {
            foreach (var filter in orgFilter)
                db.QueryFilter.AddTableFilter(filter.Key, filter.Value);
        }
    }

    /// <summary>
    /// 配置用户仅本人数据过滤器
    /// </summary>
    private static int SetDataScopeFilter(SqlSugarScopeProvider db)
    {
        var maxDataScope = (int)RoleDataScopeEnum.All;

        var userId = Appsettings.User?.UserId;
        if (userId == 0 || userId == null) return maxDataScope;

        // 获取用户最大数据范围---仅本人数据
        maxDataScope = Appsettings.GetService<SysCacheService>().Get<int>(CacheConst.KeyRoleMaxDataScope + userId);
        if (maxDataScope != (int)RoleDataScopeEnum.Self) return maxDataScope;

        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        // 配置用户数据范围缓存
        var cacheKey = $"db:{db.CurrentConnectionConfig.ConfigId}:dataScope:{userId}";
        var dataScopeFilter = yuebonCacheHelper.Get<ConcurrentDictionary<Type, LambdaExpression>>(cacheKey);
        if (dataScopeFilter == null)
        {
            // 获取业务实体数据表
            var entityTypes = Appsettings.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.IsSubclassOf(typeof(IOrgIdFilter)));
            if (!entityTypes.Any()) return maxDataScope;

            dataScopeFilter = new ConcurrentDictionary<Type, LambdaExpression>();
            foreach (var entityType in entityTypes)
            {
                // 排除非当前数据库实体
                var tAtt = entityType.GetCustomAttribute<TenantAttribute>();
                if ((tAtt != null && db.CurrentConnectionConfig.ConfigId.ToString() != tAtt.configId.ToString()))
                    continue;

                var lambda = DynamicExpressionParser.ParseLambda(new[] {
                    Expression.Parameter(entityType, "u") }, typeof(bool), $"u.{nameof(EntityBaseData.CreateUserId)}=@0", userId);
                db.QueryFilter.AddTableFilter(entityType, lambda);
                dataScopeFilter.TryAdd(entityType, lambda);
            }
            yuebonCacheHelper.Add(cacheKey, dataScopeFilter);
        }
        else
        {
            foreach (var filter in dataScopeFilter)
                db.QueryFilter.AddTableFilter(filter.Key, filter.Value);
        }
        return maxDataScope;
    }

    /// <summary>
    /// 配置自定义过滤器
    /// </summary>
    public static void SetCustomEntityFilter(SqlSugarScopeProvider db)
    {
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        // 配置自定义缓存
        var cacheKey = $"db:{db.CurrentConnectionConfig.ConfigId}:custom";
        var tableFilterItemList = yuebonCacheHelper.Get<List<TableFilterItem<object>>>(cacheKey);
        if (tableFilterItemList == null)
        {
            // 获取自定义实体过滤器
            var entityFilterTypes = Appsettings.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
                && u.GetInterfaces().Any(i => i.HasImplementedRawGeneric(typeof(IEntityFilter))));
            if (!entityFilterTypes.Any()) return;

            var tableFilterItems = new List<TableFilterItem<object>>();
            foreach (var entityFilter in entityFilterTypes)
            {
                var instance = Activator.CreateInstance(entityFilter);
                var entityFilterMethod = entityFilter.GetMethod("AddEntityFilter");
                var entityFilters = ((IList)entityFilterMethod?.Invoke(instance, null))?.Cast<object>();
                if (entityFilters == null) continue;

                foreach (var u in entityFilters)
                {
                    var tableFilterItem = (TableFilterItem<object>)u;
                    var entityType = tableFilterItem.GetType().GetProperty("type", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(tableFilterItem, null) as Type;
                    // 排除非当前数据库实体
                    var tAtt = entityType.GetCustomAttribute<TenantAttribute>();
                    if ((tAtt != null && db.CurrentConnectionConfig.ConfigId.ToString() != tAtt.configId.ToString()) ||
                        (tAtt == null && db.CurrentConnectionConfig.ConfigId.ToString() != SqlSugarConst.MainConfigId))
                        return;

                    tableFilterItems.Add(tableFilterItem);
                    db.QueryFilter.Add(tableFilterItem);
                }
            }
            yuebonCacheHelper.Add(cacheKey, tableFilterItems);
        }
        else
        {
            tableFilterItemList.ForEach(u =>
            {
                db.QueryFilter.Add(u);
            });
        }
    }
}

/// <summary>
/// 自定义实体过滤器接口
/// </summary>
public interface IEntityFilter
{
    /// <summary>
    /// 实体过滤器
    /// </summary>
    /// <returns></returns>
    IEnumerable<TableFilterItem<object>> AddEntityFilter();
}
