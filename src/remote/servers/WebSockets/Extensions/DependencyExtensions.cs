using System;
using Microsoft.AspNetCore.Builder;

namespace WebSockets.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddWS(this IApplicationBuilder app)
        {
            var wsOpts = new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromMinutes(2)
            };
            app.UseWebSockets(wsOpts);
        }
    }
}