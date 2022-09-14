using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Yuebon.AspNetCore.Mvc.Filter;

/// <summary>
/// 
/// </summary>
public class RemoveVersionFromParameter : IOperationFilter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters.Count > 0)
        {
            var versionParameter = operation.Parameters.FirstOrDefault(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }
}
