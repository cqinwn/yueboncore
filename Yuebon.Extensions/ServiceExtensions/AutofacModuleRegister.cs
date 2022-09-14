namespace Yuebon.Extensions.ServiceExtensions;

public class AutofacModuleRegister : Autofac.Module
{
    private static readonly ILog log = LogManager.GetLogger(typeof(AutofacModuleRegister));
    protected override void Load(ContainerBuilder builder)
    {
        
        #region 带有接口层的服务注入

        builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();//注册仓储

        List<Assembly> assemblyList = RuntimeHelper.GetAllYuebonAssemblies();

        foreach (var item in assemblyList)
        {
            var assembly = item as Assembly;
            ConsoleHelper.WriteInfoLine($"dll：{assembly.FullName} \n{assembly.GetName().Name}", ConsoleColor.Blue);

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = assembly.GetTypes().Where(t => t.Name.Contains("Service"));
            if (assembly.GetName().Name.EndsWith(".Services"))
            {
                builder.RegisterAssemblyTypes(assembly)
                          .AsImplementedInterfaces()
                          .InstancePerDependency()
                          .PropertiesAutowired();
            }

            // 获取 Repository.dll 程序集服务，并注册
            if (assembly.GetName().Name.EndsWith(".Repositories"))
            {
                builder.RegisterAssemblyTypes(assembly)
                       .AsImplementedInterfaces()
                       .PropertiesAutowired()
                       .InstancePerDependency();
            }



            #endregion
        }
    }
}
