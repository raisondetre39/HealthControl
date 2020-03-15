using ControlSystem.Middleware.Exceptions;
using ControlSystem.WebApi.Disease.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Controlystem.WebApi.Disease
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddOptions();
            services.AddServices();
            services.AddMappings();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder.WithOrigins("https://localhost:44365")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSwaggerDocumentation();
            app.UseMiddleware<GlobalExeptionHandler>();
            app.UseMvc();
        }
    }
}
