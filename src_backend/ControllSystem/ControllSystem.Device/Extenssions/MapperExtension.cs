using AutoMapper;
using ControlSystem.Contracts.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControlSystem.WebApi.Device.Extensions
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
                //cfg.CreateMap<CreateDeviceRequest, Contracts.Entities.Device>()
                //    .ForMember(d => d.Indicators, dev => dev.MapFrom(device => device.IndicatorIds.Foreach()));
                cfg.CreateMap<UpdateDeviceRequest, Contracts.Entities.Device>();
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
