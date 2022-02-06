using System.Text;
using Api.Extensions;
using Application.Extensions;
using Domain.Extensions;
using Domain.Models;
using gRPC.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebSockets.Extensions;

namespace Infrastructure
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable Core (App/Domain)
            string connectionString = new StringBuilder()
                .Append($"Server={Configuration["DB_SERVER"]},{Configuration["DB_PORT"]};")
                .Append($"User Id={Configuration["DB_USERNAME"]};")
                .Append($"Password={Configuration["DB_PASSWORD"]};")
                .Append($"Database={Configuration["DB_Database"]};")
                .ToString();
            services.AddDomain(
                connectionString, 
                typeof(Program).Assembly.GetName().Name); //Assembly: Infrastructure
            
            services.AddApplication();           
 
            //Enable API Restful
            services.AddApi();
            
            //Enable GRPC
            Configuration["Kestrel:Endpoints:Grpc:Url"] = $"http://+:{Configuration["GRPC_PORT"]}";
            services.AddgRPC();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Run migrations
            using (var scope = app.ApplicationServices.CreateScope())
            {
                scope.ServiceProvider.GetService<EntityContext>().MigrateDb();
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Enable WS
            app.AddWS();
            
            app.UseGrpcEndpoints();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.AddGrpcEndpoints();
            });
        }
    }
}
