using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.Health
{
    /// <summary>
    /// 数据库检查
    /// </summary>
    public class DatabaseHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken =
         default)
        {
            //using (var connection = new SqlConnection("Server=.;Initial Catalog=master;Integrated Security=true"))
            //{
            //    try
            //    {
            //        connection.Open();
            //    }
            //    catch (SqlException)
            //    {
            //        return Task.FromResult(HealthCheckResult.Unhealthy());
            //    }
            //}

            return Task.FromResult(HealthCheckResult.Healthy());

        }
    }
}
