using Newtonsoft.Json;
using SqlSugar;
using System.Reflection;
using System.Text;
using Yuebon.Commons;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Security.Models;

namespace CodeGenerator.Seed
{
    /// <summary>
    /// 种子数据生成
    /// </summary>
    public class DBSeed
    {
        private static string SeedDataFolder = "Data.json/{0}.jsv";


        /// <summary>
        /// 异步添加种子数据
        /// </summary>
        /// <param name="myContext"></param>
        /// <param name="WebRootPath"></param>
        /// <returns></returns>
        public static async Task SeedAsync(MyContext myContext, string WebRootPath)
        {
            try
            {
                SqlSugarScope Db=MyContext.GetCustomDB(MyContext.GetConnectionConfig());
                if (string.IsNullOrEmpty(WebRootPath))
                {
                    throw new Exception("获取wwwroot路径时，异常！");
                }
                SeedDataFolder = Path.Combine(WebRootPath, SeedDataFolder);
                //bool isDBReadWriteSeparate = Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool();
                Console.WriteLine("************ YuebonCore DataBase Set *****************");
                Console.WriteLine($"Is multi-DataBase: {Configs.GetConfigurationValue("AppSetting", "MutiDBEnabled")}");
                Console.WriteLine($"Is CQRS: {Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate")}");
                Console.WriteLine();
                Console.WriteLine($"Master DB ConId: {MyContext.ConnId}");
                Console.WriteLine($"Master DB Type: {MyContext.DbType}");
                Console.WriteLine($"Master DB ConnectString: {MyContext.ConnectionString}");
                Console.WriteLine();
                if (Configs.GetConfigurationValue("AppSetting", "MutiDBEnabled").ToBool())
                {
                    var masterDBIndex = 0;
                    DBServerProvider.GetAllDbConnections().ForEach(m =>
                    {

                        masterDBIndex++;
                        Console.WriteLine($"MasterDB {masterDBIndex} DB ID: {m.ConnId}");
                        Console.WriteLine($"MasterDB {masterDBIndex} DB Type: {m.MasterDB.DatabaseType}");
                        Console.WriteLine($"MasterDB {masterDBIndex} DB ConnectString: {m.MasterDB.ConnectionString}");
                        Console.WriteLine($"--------------------------------------");
                        if (Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool()&&m.ReadDB.Count>0)
                        {
                            var slaveIndex = 0;
                            m.ReadDB.ForEach(rd =>
                            {
                                slaveIndex++;
                                Console.WriteLine($"Slave{slaveIndex} DB ID: {rd.ConnId}");
                                Console.WriteLine($"Slave{slaveIndex} DB Type: {rd.DatabaseType}");
                                Console.WriteLine($"Slave{slaveIndex} DB ConnectString: {rd.ConnectionString}");
                                Console.WriteLine($"--------------------------------------");
                            });
                        }
                    });
                }
                Console.WriteLine();
                // 创建数据库
                Console.WriteLine($"Create Database(The Db Id:{MyContext.ConnId})...");
                if (MyContext.DbType != SqlSugar.DbType.Oracle)
                {
                    myContext.Db.DbMaintenance.CreateDatabase();
                    ConsoleHelper.WriteSuccessLine($"Database created successfully!");
                }
                else
                {
                    //Oracle 数据库不支持该操作
                    ConsoleHelper.WriteSuccessLine($"Oracle 数据库不支持该操作，可手动创建Oracle数据库!");
                }

                // 创建数据库表，遍历指定命名空间下的class，
                // 注意不要把其他命名空间下的也添加进来。
                Console.WriteLine("Create Tables...");

                #region 权限系统
                var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                var referencedAssemblies = System.IO.Directory.GetFiles(path, "Yuebon.Security.Core.dll").Select(Assembly.LoadFrom).ToArray();
                var modelTypes = referencedAssemblies
                    .SelectMany(a => a.DefinedTypes)
                    .Select(type => type.AsType())
                    .Where(x => x.IsClass && x.Namespace != null && x.Namespace.Equals("Yuebon.Security.Models")).ToList(); 
                modelTypes.ForEach(t =>
                {
                    // 这里只支持添加表，不支持删除
                    // 如果想要删除，数据库直接右键删除，或者联系SqlSugar作者；
                    if (!myContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        Db.CodeFirst.InitTables(t);
                    }
                });
                #endregion

                #region 文章
                referencedAssemblies = System.IO.Directory.GetFiles(path, "Yuebon.CMS.Core.dll").Select(Assembly.LoadFrom).ToArray();
                modelTypes = referencedAssemblies
                    .SelectMany(a => a.DefinedTypes)
                    .Select(type => type.AsType())
                    .Where(x => x.IsClass && x.Namespace != null && x.Namespace.Equals("Yuebon.CMS.Models")).ToList();
                modelTypes.ForEach(t =>
                {
                    // 这里只支持添加表，不支持删除
                    // 如果想要删除，数据库直接右键删除，或者联系SqlSugar作者；
                    if (!myContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        Db.CodeFirst.InitTables(t);
                    }
                });
                #endregion

                #region 定时任务
                referencedAssemblies = System.IO.Directory.GetFiles(path, "Yuebon.Quartz.Jobs.dll").Select(Assembly.LoadFrom).ToArray();
                modelTypes = referencedAssemblies
                    .SelectMany(a => a.DefinedTypes)
                    .Select(type => type.AsType())
                    .Where(x => x.IsClass && x.Namespace != null && x.Namespace.Equals("Yuebon.Quartz.Models")).ToList();
                modelTypes.ForEach(t =>
                {
                    // 这里只支持添加表，不支持删除
                    // 如果想要删除，数据库直接右键删除，或者联系SqlSugar作者；
                    if (!myContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        Db.CodeFirst.InitTables(t);
                    }
                });
                #endregion

                #region 租户信息
                referencedAssemblies = System.IO.Directory.GetFiles(path, "Yuebon.Tenants.Core.dll").Select(Assembly.LoadFrom).ToArray();
                modelTypes = referencedAssemblies
                    .SelectMany(a => a.DefinedTypes)
                    .Select(type => type.AsType())
                    .Where(x => x.IsClass && x.Namespace != null && x.Namespace.Equals("Yuebon.Tenants.Models")).ToList();
                modelTypes.ForEach(t =>
                {
                    // 这里只支持添加表，不支持删除
                    // 如果想要删除，数据库直接右键删除，或者联系SqlSugar作者；
                    if (!myContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        Db.CodeFirst.InitTables(t);
                    }
                });
                #endregion

                ConsoleHelper.WriteSuccessLine($"Tables created successfully!");
                Console.WriteLine();



                if (Appsettings.app(new string[] { "AppSetting", "SeedDBDataEnabled" }).ObjToBool())
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        //日期类型默认格式化处理
                        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                        //空值处理
                        setting.NullValueHandling = NullValueHandling.Ignore;

                        //高级用法九中的Bool类型转换 设置
                        //setting.Converters.Add(new BoolConvert("是,否"));

                        return setting;
                    });

                    Console.WriteLine($"Seeding database data (The Db Id:{MyContext.ConnId})...");

                    #region SystemType
                    if (!await myContext.Db.Queryable<SystemType>().AnyAsync())
                    {
                        myContext.GetEntityDB<SystemType>().InsertRange(JsonHelper.ToObject<List<SystemType>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "SystemType"), Encoding.UTF8)));
                        Console.WriteLine("Table:SystemType created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:SystemType already exists...");
                    }
                    #endregion


                    #region App
                    if (!await myContext.Db.Queryable<APP>().AnyAsync())
                    {
                        myContext.GetEntityDB<APP>().InsertRange(JsonHelper.ToObject<List<APP>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "APP"), Encoding.UTF8)));
                        Console.WriteLine("Table:APP created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:APP already exists...");
                    }
                    #endregion


                    #region Role
                    if (!await myContext.Db.Queryable<Role>().AnyAsync())
                    {
                        myContext.GetEntityDB<Role>().InsertRange(JsonHelper.ToObject<List<Role>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "Role"), Encoding.UTF8)));
                        Console.WriteLine("Table:Role created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:Role already exists...");
                    }
                    #endregion

                    #region User
                    if (!await myContext.Db.Queryable<User>().AnyAsync())
                    {
                        myContext.GetEntityDB<User>().InsertRange(JsonHelper.ToObject<List<User>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "User"), Encoding.UTF8)));
                        Console.WriteLine("Table:User created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:User already exists...");
                    }
                    #endregion

                    #region Organize
                    if (!await myContext.Db.Queryable<Organize>().AnyAsync())
                    {
                        myContext.GetEntityDB<Organize>().InsertRange(JsonHelper.ToObject<List<Organize>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "Organize"), Encoding.UTF8)));
                        Console.WriteLine("Table:Organize created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:Organize already exists...");
                    }
                    #endregion

                    #region UserLogOn
                    if (!await myContext.Db.Queryable<UserLogOn>().AnyAsync())
                    {
                        myContext.GetEntityDB<UserLogOn>().InsertRange(JsonHelper.ToObject<List<UserLogOn>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "UserLogOn"), Encoding.UTF8)));
                        Console.WriteLine("Table:UserLogOn created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:UserLogOn already exists...");
                    }
                    #endregion
                    #region Menu
                    if (!await myContext.Db.Queryable<Menu>().AnyAsync())
                    {
                        myContext.GetEntityDB<Menu>().InsertRange(JsonHelper.ToObject<List<Menu>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "Menu"), Encoding.UTF8)));
                        Console.WriteLine("Table:Menu created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:Menu already exists...");
                    }
                    #endregion


                    #region Items
                    if (!await myContext.Db.Queryable<Items>().AnyAsync())
                    {
                        myContext.GetEntityDB<Items>().InsertRange(JsonHelper.ToObject<List<Items>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "Items"), Encoding.UTF8)));
                        Console.WriteLine("Table:Items created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:Items already exists...");
                    }
                    #endregion

                    #region ItemsDetail
                    if (!await myContext.Db.Queryable<ItemsDetail>().AnyAsync())
                    {
                        myContext.GetEntityDB<ItemsDetail>().InsertRange(JsonHelper.ToObject<List<ItemsDetail>>(FileHelper.ReadFile(string.Format(SeedDataFolder, "ItemsDetail"), Encoding.UTF8)));
                        Console.WriteLine("Table:ItemsDetail created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:ItemsDetail already exists...");
                    }
                    #endregion
                    ConsoleHelper.WriteSuccessLine($"Done seeding database!");
                }

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                throw new Exception($"错误：" + ex.Message);
            }
        }
    }
}