using ControlSystem.BL.Auth.Interfaces;
using ControlSystem.BL.Auth.Services;
using ControlSystem.DAL;
using ControlSystem.DAL.Interfaces;
using ControlSystem.DAL.Repositories;
using ControlSystem.Middleware.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace ControlSystem.WebApi.Auth.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IAuthenticationManager, AuthenticatinManager>();
        }
    }
}
