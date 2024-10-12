using Yuebon.Core.IServices;
using Yuebon.Core.Services;

namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// 自动注册接口
/// 筛选出对应条件的接口
/// IsAbstract：是否为抽象类
/// IsAssignableFrom：返回true的条件：是否直接或间接实现了IService或IRepository
/// AsImplementedInterfaces：以接口的形式注册
/// InstancePerDependency:实例依赖关系
/// PropertiesAutowired:属性自动连接(属性自动注入)
/// InstancePerLifetimeScope：同一个Lifetime生成的对象是同一个实例
/// </summary>
public class AutofacModuleRegister : Autofac.Module
{
    private static readonly ILog log = LogManager.GetLogger(typeof(AutofacModuleRegister));
    protected override void Load(ContainerBuilder builder)
    {

        #region 带有接口层的服务注入
        try
        {
            /* 1、注册
             * RegisterGeneric:注册非参数化泛型类型：RegisterGeneric(typeof(类)).As(typeof(接口))
             //* RegisterType:通过RegisterType<类>.As<接口>() 来注册不是泛型的类
             */
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();//注册仓储
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IService<,>)).InstancePerDependency();//注册仓储


            /* 2、获取接口类型
             * 通过IService、IRepository标记需要依赖注入的接口
             * 注册所有实现了IService、IRepository接口的类型
             */
            Type baseTypeIRepository = typeof(IRepository<>);
            Type baseTypeIService = typeof(IService<,>);
            /* 3、获取所有程序集
             * 当CLR COM服务器初始化时，它会创建一个AppDomain。 AppDomain是一组程序集的逻辑容器
             */
            List<Assembly> assemblyList = RuntimeHelper.GetAllYuebonAssemblies();

            foreach (var item in assemblyList)
            {
                var assembly = item as Assembly;

                // 获取 Service.dll 程序集服务，并注册
                var assemblysServices = assembly.GetTypes().Where(t => t.Name.Contains("Service"));

                if (assembly.GetName().Name.EndsWith(".Services"))
                {
                    builder.RegisterAssemblyTypes(assembly)
                              .AsImplementedInterfaces()
                              .InstancePerDependency()
                              .PropertiesAutowired();

                    ConsoleHelper.WriteInfoLine($"处理{assembly.GetName().Name}.dll 中业务服务Service的接口和实现注入", ConsoleColor.Blue);
                }
                else if (assembly.GetName().Name.EndsWith(".Repositories"))// 获取 Repository.dll 程序集服务，并注册
                {
                    builder.RegisterAssemblyTypes(assembly)
                           .AsImplementedInterfaces()
                           .PropertiesAutowired()
                           .InstancePerDependency();

                    ConsoleHelper.WriteInfoLine($"处理{assembly.GetName().Name}.dll 中业务服务仓储Repositories的接口和实现注入", ConsoleColor.Blue);
                }
                else if (assembly.GetName().Name.EndsWith(".Core") && assembly.GetName().Name != "Yuebon.Core")
                {
                    //筛选出对应条件的接口
                    //builder.RegisterAssemblyTypes(assembly).Where(type =>!type.IsAbstract && baseTypeIService.IsAssignableFrom(type)||baseTypeIRepository.IsAssignableFrom(type))
                    //     .AsImplementedInterfaces()
                    //     .InstancePerDependency()
                    //     .InstancePerLifetimeScope();

                    assembly.GetTypes().Where(t => t.IsClass && (t.Name.EndsWith("Repository") || t.Name.EndsWith("Service"))).ToList().ForEach(t =>
                    {
                        Type ty = t as Type;
                        if (t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
                        {
                            var serviceType = t.GetInterface($"I{t.Name}");

                            ConsoleHelper.WriteInfoLine($"{t.Name}的service接口:{serviceType}", ConsoleColor.Blue);
                            if (serviceType != null)
                            {
                                builder.RegisterAssemblyTypes(assembly)
                                .AsImplementedInterfaces()
                               .PropertiesAutowired()
                               .InstancePerDependency();

                                //builder.RegisterType<>().AsImplementedInterfaces();
                            }
                            else
                            {
                                ConsoleHelper.WriteInfoLine($"不处理{t.Name}的service接口为空", ConsoleColor.Blue);
                            }
                        }
                    });

                    ConsoleHelper.WriteInfoLine($"处理{assembly.GetName().Name}.dll ", ConsoleColor.Blue);
                }
                else
                {

                    ConsoleHelper.WriteInfoLine($"不出处理{assembly.GetName().Name}.dll 中业务服务Service、仓储Repositories的接口和实现注入", ConsoleColor.Blue);
                }
            }
        }
        catch (Exception ex)
        {
            ConsoleHelper.WriteInfoLine($"serviceType:{ex.Message}", ConsoleColor.Blue);
        }

        #endregion
    }
}
