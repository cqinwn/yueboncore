using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;

namespace Yuebon.Commons.SeedInitData
{
    /// <summary>
    /// 种子数据生成业务服务类
    /// </summary>
    public class DBSeedService
    {
        /// <summary>
        /// 异步添加种子数据
        /// </summary>
        /// <param name="assembliesDlls">DLL文件名称</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static async Task SeedAsync(List<string> assembliesDlls,ConnectionConfig config=null)
        {
            string nowAssembliesDll=string.Empty;
            try
            {
                SqlSugarClient Db = GetCustomDB(config);
                //bool isDBReadWriteSeparate = Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool();
                Console.WriteLine("************ YuebonCore DataBase Set *****************");
                Console.WriteLine($"Is multi-DataBase: {Configs.GetConfigurationValue("AppSetting", "MutiDBEnabled")}");
                Console.WriteLine($"Is CQRS: {Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate")}");
                Console.WriteLine();
                Console.WriteLine($"Master DB ConId: {Db.CurrentConnectionConfig.ConfigId}");
                Console.WriteLine($"Master DB Type: {Db.CurrentConnectionConfig.DbType}");
                Console.WriteLine($"Master DB ConnectString: {Db.CurrentConnectionConfig.ConnectionString}");
                Console.WriteLine();

                // 创建数据库
                Console.WriteLine($"Create Database(The Db Id:{Db.CurrentConnectionConfig.ConfigId})...");
                if (Db.CurrentConnectionConfig.DbType != SqlSugar.DbType.Oracle)
                {
                    Db.DbMaintenance.CreateDatabase();
                    ConsoleHelper.WriteSuccessLine($"Database created successfully!");
                }
                else
                {
                    //Oracle 数据库不支持该操作
                    ConsoleHelper.WriteSuccessLine($"Oracle 数据库不支持该操作，可手动创建Oracle数据库!");
                }
                foreach (string itemDll in assembliesDlls)
                {
                    nowAssembliesDll = itemDll;
                    Console.WriteLine($"assemblies:{itemDll} start...");
                    var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                    var referencedAssemblies = System.IO.Directory.GetFiles(path, itemDll).Select(Assembly.LoadFrom).ToArray();
                    #region 初始化库表结构
                    // 创建数据库表，遍历指定命名空间下的class，
                    // 注意不要把其他命名空间下的也添加进来。
                    Console.WriteLine("Create Tables...");
                    var modelTypes = referencedAssemblies
                        .SelectMany(a => a.DefinedTypes)
                        .Select(type => type.AsType())
                        .Where(x => x.IsClass && x.IsDefined(typeof(SugarTable), false) && x.Namespace != null && x.Namespace.EndsWith(".Models")).ToList();
                    if (!modelTypes.Any()) continue;
                    modelTypes.ForEach(t =>
                    {
                        // 这里只支持添加表，不支持删除
                        // 如果想要删除，数据库直接右键删除；
                        if (!Db.DbMaintenance.IsAnyTable(t.Name))
                        {
                            Console.WriteLine(t.Name);
                            Db.CodeFirst.InitTables(t);
                        }
                    });
                    ConsoleHelper.WriteSuccessLine($"Tables created successfully!");
                    Console.WriteLine();
                    #endregion

                    #region 初始化种子数据
                    var seedDataTypes = referencedAssemblies
                    .SelectMany(a => a.DefinedTypes)
                    .Select(type => type.AsType())
                    .Where(x => x.IsClass && x.Namespace != null && x.Namespace.EndsWith(".SeedData") && typeof(SeedDataEntity).IsAssignableFrom(x)).ToList();
                    if (!seedDataTypes.Any()) continue;

                    Console.WriteLine($"Seeding database data (The Db Id:{Db.CurrentConnectionConfig.ConfigId})...");
                    foreach (var item in seedDataTypes)
                    {
                        var instance = Activator.CreateInstance(item);

                        var hasDataMethod = item.GetMethod("HasData");
                        var seedData = ((IList)hasDataMethod?.Invoke(instance, null))?.Cast<object>();
                        if (seedData == null)
                        {
                            Console.WriteLine($"Table:{item.Name} already exists...");
                        }
                        else
                        {
                            var seedDataTable = seedData.ToList().ToDataTable();
                            if (seedDataTable.Columns.Contains("Id"))
                            {
                                var storage = Db.Storageable(seedDataTable).WhereColumns("Id").ToStorage();
                                storage.AsInsertable.ExecuteCommand();
                                //storage.AsUpdateable.ExecuteCommand();
                            }
                            else //没有主键或者不是预定义的主键(没主键有重复的可能)
                            {
                                var storage = Db.Storageable(seedDataTable).ToStorage();
                                storage.AsInsertable.ExecuteCommand();
                            }
                            Console.WriteLine($"Table:{seedDataTable.TableName} Data created success!");
                        }
                    }

                    ConsoleHelper.WriteSuccessLine($"Done {itemDll} seeding database!");
                    #endregion

                    ConsoleHelper.WriteSuccessLine($"assemblies:{itemDll} end...");
                    Console.WriteLine();
                }
                ConsoleHelper.WriteSuccessLine($"Done all seeding database!");
                Db.Close();
                Db.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log4NetHelper.Error($"{nowAssembliesDll}初始化数据库异常",ex);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static SqlSugarClient GetCustomDB(ConnectionConfig config)
        {
            var configs = new List<ConnectionConfig>();
            if (config == null)
            {
                List<DbConnections> allDbs = DBServerProvider.GetAllDbConnections();
                allDbs.ForEach(m =>
                {
                    ConnectionConfig config = new ConnectionConfig()
                    {
                        ConfigId = m.ConnId.ToLower(),
                        ConnectionString = m.MasterDB.ConnectionString,
                        DbType = (DbType)m.MasterDB.DatabaseType,
                        IsAutoCloseConnection = true,
                        ConfigureExternalServices=new ConfigureExternalServices()
                        {
                            EntityService = (c, p) =>
                            {
                                // int?  decimal?这种 isnullable=true
                                if (c.PropertyType.IsGenericType && c.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    p.IsNullable = true;
                                }
                                else if (c.PropertyType == typeof(string) && c.GetCustomAttribute<RequiredAttribute>() == null)
                                { //string类型如果没有Required isnullable=true
                                    p.IsNullable = true;
                                }
                                if (p.DataType != null)
                                {
                                    if ((DbType)m.MasterDB.DatabaseType == SqlSugar.DbType.MySql && (p.DataType.ToLower() == "varchar(max)" || p.DataType.ToLower() == "nvarchar(max)"))
                                    {
                                        p.DataType = "longtext";
                                    }
                                }
                            }
                        }
                    };
                    configs.Add(config);
                });
            }
            else
            {
                config.ConfigureExternalServices = new ConfigureExternalServices()
                {
                    EntityService = (c, p) =>
                    {
                        // int?  decimal?这种 isnullable=true
                        if (c.PropertyType.IsGenericType &&
                        c.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            p.IsNullable = true;
                        }
                        else if (c.PropertyType == typeof(string) &&
                                 c.GetCustomAttribute<RequiredAttribute>() == null)
                        { //string类型如果没有Required isnullable=true
                            p.IsNullable = true;
                        }
                    }
                };
                configs.Add(config);
            }
            return new SqlSugarClient(configs);
        }
    }
}
