﻿using ControlSystem.Middleware.Auth;
using Microsoft.Extensions.DependencyInjection;
using ControlSystem.DAL.Device;
using ControlSystem.DAL.Device.Interfaces;
using ControlSystem.BL.Device.Interfaces;
using ControlSystem.BL.Device.Services;
using ControlSystem.DAL.Device.Repositories;

namespace ControlSystem.WebApi.Device.AWS.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IIndicatorRepository, IndicatorRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<IIndicatorsService, IndicatorService>();
            services.AddSingleton<IAuthenticationManager, AuthenticatinManager>();
            services.AddSingleton<IIndicatorValuesRepository, IndicatorValuesRepository>();
            services.AddSingleton<IIndicatorValuesService, IndicatorValueService>();
        }
    }
}