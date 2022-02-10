using System;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration
{
    public class EnvLoader : IDisposable
    {
        private bool _disposed;

        private readonly IConfiguration _configuration;
        public EnvLoader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //"mongodb://admin:admin@localhost:27017"
        public string GetDbConnection()
        {
            try
            {
                string connectionString = new StringBuilder()
                                .Append($"Server={_configuration["DB_SERVER"]},{_configuration["DB_PORT"]};")
                                .Append($"User Id={_configuration["DB_USERNAME"]};")
                                .Append($"Password={_configuration["DB_PASSWORD"]};")
                                .Append($"Database={_configuration["DB_DATABASE"]};")
                                .ToString();
                Console.Out.WriteLine(connectionString);
                return connectionString;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string GetGrpcServer()
        {
            try
            {
                var connectionString = new StringBuilder()
                    .Append($"http://+:{_configuration["GRPC_PORT"]}")
                    .ToString();
                    Console.Out.WriteLine(connectionString);
                return connectionString;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
        }
    }
}