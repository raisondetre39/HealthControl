using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace ControlSystem.WebApi.Disease.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Control System Disease",
                    Description = "ASP.NET Core Web API"
                });
                c.DescribeAllEnumsAsStrings();
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "ControllSystem.Disease.WebApi.xml");
                ////          c.IncludeXmlComments(filePath);
            });

            //GlobalConfiguration.Configuration
            //   .EnableSwagger("docs/{apiVersion}/help", c =>
            //   {
            //       c.OperationFilter<AddAuthTokenHeaderParameterOperationFilter>();
            //   });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Control System Disease API");
            });

            return app;
        }
    }
}
