using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace WebSockets.Controllers
{
    public class ExWsController : ControllerBase
    {
        private static ConcurrentDictionary<string, WebSocket> _sockets = new();

        [HttpGet("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using WebSocket webSocket = await 
                    HttpContext.WebSockets.AcceptWebSocketAsync();
                _sockets.TryAdd(Guid.NewGuid().ToString(), webSocket);
                await Echo(HttpContext, webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
        
        public async Task Echo(HttpContext context, WebSocket ws)
        {
            var buff = new byte[1024 * 4];
            WebSocketReceiveResult result = await ws.ReceiveAsync(new ArraySegment<byte>(buff), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                Broadcast(result, buff);
                //await ws.SendAsync(new ArraySegment<byte>(buff, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
                result = await ws.ReceiveAsync(new ArraySegment<byte>(buff), CancellationToken.None);
            }
            
            await ws.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private void Broadcast(WebSocketReceiveResult result, byte[] buffer)
        {
            List<Task> tasks = new List<Task>();
            foreach (var key in _sockets.Keys)
            {
                var socket = _sockets[key];
                Console.Out.WriteLine($"Sending {result} to {key}");
                tasks.Add(
                    socket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None)
                );
            }
            Task.WhenAll(tasks);
            Console.Out.WriteLine("Sended!");
        }

        private void Broadcast(string message2)
        {
            List<Task> tasks = new List<Task>();
            foreach (var key in _sockets.Keys)
            {
                var socket = _sockets[key];
                Console.Out.WriteLine($"Sending {message2} to {key}");
                ReadOnlyMemory<byte> message = new ArraySegment<byte>(Encoding.Default.GetBytes(message2));
                tasks.Add(
                    socket.SendAsync(message, WebSocketMessageType.Text, true, CancellationToken.None)
                        .AsTask()
                );
            }
            Task.WhenAll(tasks);
            Console.Out.WriteLine("Sended");
//                ws.SendAsync(new ArraySegment<byte>(buff, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
        }

    }
}