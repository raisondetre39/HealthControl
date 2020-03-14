using ControlSystem.WebApi.Auth.Extensions;
using ControlSystem.Middleware.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseCors(builder => builder.WithOrigins("https://localhost:44367")
            //                              .AllowAnyHeader()
            //                              .AllowAnyMethod());
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSwaggerDocumentation();
            //loggerFactory.AddNLog();
            //app.AddNLogWeb();
            //env.ConfigureNLog("NLog.config");
            app.UseMiddleware<GlobalExeptionHandler>();
            app.UseMvc();
        }
    }
}
