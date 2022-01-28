using Application.Mappers;
using Application.Mappers.Impl;
using Application.Services;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceDiExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddServices(services);
            AddMappers(services);
        }
        
        public static void AddServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
        }

        public static void AddMappers(this IServiceCollection services)
        {
            //Mappers
            services.AddAutoMapper(typeof(Application)); //For Application Layer
            services.AddScoped<ILevelMapper, LevelMapper>();
            services.AddScoped<IPositionMapper, PositionMapper>();
            services.AddScoped<IProfileMapper, ProfileMapper>();
            services.AddScoped<ITechnologyMapper, TechnologyMapper>();
        }
    }
}
