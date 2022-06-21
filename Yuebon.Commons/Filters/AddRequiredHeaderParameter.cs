using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Yuebon.Commons.Filters
{
    /// <summary>
    /// 向swagger添加header参数
    /// </summary>
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        /// <summary>
        /// 向swagger添加header参数
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

            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    Name = "api-version",
            //    In = ParameterLocation.Header,
            //    Description = "版本号",
            //    Required = false,
            //    AllowEmptyValue = true
            //});
        }
    }
}
