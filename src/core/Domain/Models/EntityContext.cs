using System;
using Domain.Models.ConstInterfaces;
using Domain.Models.ManagementModels;
using GeneralUtils;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class EntityContext : DbContext
    {
        private DbSet<JobPosition> JobPositions { get; set; }
        private DbSet<Level> Levels { get; set; }
        private DbSet<Technology> Technologies { get; set; }

        //For User Profiles Management
        private DbSet<UserProfile> UserProfiles { get; set; }

        private DbSet<Status> Status { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Seeding Db
            Seed(builder);
            
            //General Constraints
            Uniques(builder, "Name");
            Traceables(builder);
        }

        private void Uniques(ModelBuilder builder, string index)
        {;
            Type[] types = TypeUtils.GetTypesFromInterface(typeof(IUniqueName));
            foreach (var type in types)
            {
                Console.WriteLine("IUniques: " + type);
                builder.Unique(index, type);
            }
        }

        private void Traceables(ModelBuilder builder)
        {
            Type[] types = TypeUtils.GetTypesFromInterface(typeof(ITraceable));
            foreach (var type in types)
            {
                Console.WriteLine("ITraceables: " + type);
                builder.Traceable(type);
            }
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new {Id = 1, Name = "Active"},
                new {Id = 2, Name = "Disabled"},
                new {Id = 3, Name = "Pending"},
                new {Id = 4, Name = "Warning"}
                );
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Unique(this ModelBuilder builder, string index, Type type) 
        {
                builder.Entity(type).HasIndex(index).IsUnique();
        }

        public static void Traceable(this ModelBuilder builder, Type type)
        {
                builder.Entity(type).Property("CreatedDate").HasDefaultValueSql("getdate()");
                builder.Entity(type).Property("UpdatedDate").HasDefaultValueSql("getdate()");
        }
    } 
}