using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControlSystem.WebApi.Auth.AWS.Extensions
{
    public static class MappingExtensions
    {
        public static void AddMappings(this IServiceCollection services)
        {
            services.AddSingleton(CreateMapper());
        }
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<User, CreateUserRequest>().ReverseMap();
                //cfg.CreateMap<User, RegistrationRequest>().ReverseMap();
                //cfg.CreateMap<User, UpdateUserRequest>().ReverseMap();
                //cfg.CreateMap<Administrator, CreateAdminRequest>().ReverseMap();
                //cfg.CreateMap<RegistrationRequest, Administrator>()
                //   .ForMember("Name", opt => opt.MapFrom(c => c.Email)).ReverseMap();
                //cfg.CreateMap<Vote, CreateVoteRequest>().ReverseMap();
                //cfg.CreateMap<Friend, CreateFriendRequest>().ReverseMap();
                //cfg.CreateMap<CreateImageRequest, Image>().ForMember("Content", opt => opt.Ignore());
                //cfg.CreateMap<Country, CreateCountryRequest>().ReverseMap();
                //cfg.CreateMap<Messages, CreateMessageRequest>().ReverseMap();
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
