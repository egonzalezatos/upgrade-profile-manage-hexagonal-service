using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Extensions
{
    public static class MigrateExtension
    {
        public static void MigrateDb(this EntityContext context)
        {
            if (context.Database.IsRelational())
                context.Database.Migrate();
            else 
                context.Database.EnsureCreated();
        }
    }
}