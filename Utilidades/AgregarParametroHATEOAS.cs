using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace webapi.Utilidades
{
    public class AgregarParametroHATEOAS : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod != "GET") // con esto podemos decir que solo aparezca en GET y no en delete ni post.
            {
                return;
            }

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "incluirHATEOAS",   // ESTA ES LA CABEZERA QUE VAMOS A INCLUIR 
                In = ParameterLocation.Header,
                Required = false
            });
        }
    }
}
