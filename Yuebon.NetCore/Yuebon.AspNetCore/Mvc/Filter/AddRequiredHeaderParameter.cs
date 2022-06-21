using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
namespace Yuebon.AspNetCore.Mvc.Filter
{
    /// <summary>
    /// 向swagger添加header参数
    /// </summary>
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "sign",
                In = ParameterLocation.Header,
                Description = "是否启用签名",
                Required = true,
                AllowEmptyValue = false
            });
        }
    }
}
