using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.Mvc.Filter
{
    /// <summary>
    /// Swagger 上传文件过滤器
    /// </summary>
    public class SwaggerFileUploadFilter : IOperationFilter
    {
        /// <summary>
        /// 应用过滤器
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            {
                #region 文件上传处理
                if (!context.ApiDescription.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase) &&
                    !context.ApiDescription.HttpMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                
                var fileParameters = context.ApiDescription.ActionDescriptor.Parameters.Where(n => n.ParameterType == typeof(IFormFile)).ToList();
                if (fileParameters.Count < 0)
                {
                    return;
                }

                foreach (var fileParameter in fileParameters)
                {
                    var parameter = operation.Parameters.Single(n => n.Name == fileParameter.Name);
                    operation.Parameters.Remove(parameter);
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = parameter.Name,
                        In = ParameterLocation.Header,//"formData",
                        Description = parameter.Description,
                        Required = parameter.Required,
                        Content = parameter.Content
                    });
                }
                #endregion
            }
        }
    }
}
