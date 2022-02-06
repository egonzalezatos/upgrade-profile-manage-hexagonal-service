using System;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDomain(this IServiceCollection services, string connectionString, string assemblyName)
        {
            AddContext(services, connectionString, assemblyName);
            AddRepositories(services);
        }

        public static void AddContext(this IServiceCollection services, string connectionString, string assemblyName)
        {
            //DB Config
            Console.WriteLine(connectionString);
            services.AddDbContext<EntityContext>(options =>
                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly(assemblyName);
                    b.EnableRetryOnFailure();
                }));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IJobProfileRepository, JobProfileRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}