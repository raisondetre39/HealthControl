using ControlSystem.WebApi.Disease.Infrastructure.Security;
using Swashbuckle.Swagger;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace ControlSystem.WebApi.Disease.Infrastructure.Swagger
{
    public class AddAuthTokenHeaderParameterOperationFilter : IOperationFilter
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var userAuthFilter = filterPipeline.FirstOrDefault(filterInfo => filterInfo.Instance is UserAuthorizationAttribute);

            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            var forceJwtAuth = apiDescription.ActionDescriptor.GetCustomAttributes<ForceJwtAuthAttribute>().Any();

            if (userAuthFilter != null && (!forceJwtAuth && !allowAnonymous))
            {
                operation.parameters.Add(new Parameter
                {
                    name = "AuthToken",
                    @in = "header",
                    description = "AuthToken",
                    required = false, //!((UserAuthorizationAttribute)userAuthFilter.Instance).IsOptionalAuthorization,
                    type = "string"
                });
            }
        }
    }
}
