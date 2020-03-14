using ControlSystem.Middleware.Auth;
using Microsoft.Extensions.DependencyInjection;
using ControlSystem.DAL.Disease;
using ControlSystem.DAL.Disease.Interfaces;
using ControlSystem.DAL.Disease.ControlSystemContext;
using ControlSystem.BL.Disease.Interfaces;
using ControlSystem.BL.Disease.Services;
using ControlSystem.DAL.Disease.Repositories;

namespace ControlSystem.WebApi.Disease.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDiseaseRepository, DiseaseRepository>();
            services.AddSingleton<IDiseaseService, DiseaseService>();
            services.AddSingleton<IAuthenticationManager, AuthenticatinManager>();
        }
    }
}