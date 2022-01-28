using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class DependencyExtension
    {
        public static void AddApi(this IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}