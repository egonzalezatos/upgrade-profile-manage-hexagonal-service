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
        public static void AddDomain(this IServiceCollection services, string connectionString)
        {
            AddContext(services, connectionString);
            AddRepositories(services);
        }

        public static void AddContext(this IServiceCollection services, string connectionString)
        {
            //DB Config
            Console.WriteLine(connectionString);
            services.AddDbContext<EntityContext>(options =>
                options.UseSqlServer(connectionString));
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