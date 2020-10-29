using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Zxw.Framework.NetCore.IoC;

namespace Yuebon.Commons.DbContextCore
{
    public class ShardDbContextFactory<T>:IDesignTimeDbContextFactory<T> where T:DbContext,new()
    {
        public T CreateDbContext(string[] args)
        {
            return ServiceLocator.Resolve<T>();
        }        
    }
}
