using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControlSystem.WebApi.Disease.AWS.Extensions
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
            //    cfg.CreateMap<CreateDiseaseRequest, Contracts.Entities.Disease>();
              //  cfg.CreateMap<UpdateDiseaseRequest, Contracts.Entities.Disease>();
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
