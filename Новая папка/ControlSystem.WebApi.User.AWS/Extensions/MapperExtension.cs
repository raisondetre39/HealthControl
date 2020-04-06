using AutoMapper;
using ControlSystem.Contracts.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControlSystem.WebApi.User.AWS.Extensions
{
    public static class MapperExtension
    {
        public static void AddMappings(this IServiceCollection services)
        {
            services.AddSingleton(CreateMapper());
        }
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contracts.Entities.User, CreateUserRequest>().ReverseMap();
                cfg.CreateMap<Contracts.Entities.User, UpdateUserRequest>().ReverseMap();
            });
            return mapperConfig.CreateMapper();
        }

        private static void Register<TSource, TTarget>(IServiceCollection services)
        {
            services.AddSingleton<Func<TSource, TTarget>>(
                            serviceProvider =>
                            sourceInstance =>
                            serviceProvider.GetService<IMapper>().Map<TTarget>(sourceInstance));
        }
    }
}
