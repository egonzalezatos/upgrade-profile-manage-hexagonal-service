using System.IO;
using gRPC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace gRPC.Extensions
{
    public static class DependencyExtension
    {
        public static void AddgRPC(this IServiceCollection services)
        {
            services.AddGrpc();
            services.AddAutoMapper(typeof(gRPC.Extensions.DependencyExtension));
        }
        
        public static void AddGrpcEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<GreeterService>();
            endpoints.MapGrpcService<GrpcProfileManagementService>();

            // endpoints.MapGet("/", async context =>
            // {
            //     await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            // });
            endpoints.MapGet("/proto/profile-management.proto", async context =>
            {
                await context.Response.WriteAsync(File.ReadAllText("Remote/Grpc/Protos/profile-management.proto"));
            });
        }
        
        public static void UseGrpcEndpoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<GrpcProfileManagementService>();

                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                // });
                endpoints.MapGet("/proto/profile-management.proto",
                    async context =>
                    {
                        await context.Response.WriteAsync(
                            File.ReadAllText("Remote/Grpc/Protos/profile-management.proto"));
                    });
            });
        }
    }
}