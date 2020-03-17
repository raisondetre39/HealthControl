using ControlSystem.Middleware.Auth;
using Microsoft.Extensions.DependencyInjection;
using ControlSystem.DAL;
using ControlSystem.DAL.User.Interfaces;
using ControlSystem.BL.User.Interfaces;
using ControlSystem.DAL.User.Repositories;
using ControlSystem.BL.User.Services;

namespace ControlSystem.WebApi.User.AWS.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDiseaseRepository, DiseaseRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthenticationManager, AuthenticatinManager>();
          //  GlobalConfiguration.Configuration.Services.Replace(typeof(IFilterProvider), new UnityActionFilterProvider(services));
        }
    }
}
