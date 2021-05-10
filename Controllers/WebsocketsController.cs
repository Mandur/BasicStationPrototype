using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebSocketsTutorial.Models;

namespace WebSocketsTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketsController : ControllerBase
    {
        private readonly ILogger<WebSocketsController> _logger;

        public WebSocketsController(ILogger<WebSocketsController> logger)
        {
            _logger = logger;
        }


        [HttpGet("/router-config")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                await AnswerRouterConfig(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        [HttpGet("/router-info")]
        public async Task Info()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                await AnswerRouterInfo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private async Task AnswerRouterInfo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.Log(LogLevel.Information, "Received a router info from client");

            while (!result.CloseStatus.HasValue)
            {
                var input = Encoding.UTF8.GetString(buffer).Replace("\0", "");
                _logger.Log(LogLevel.Information, $"Received message: {input}");
                var reply = JsonSerializer.Deserialize<UriReply>(input);

                reply.router = "1";
                reply.uri = $"ws://{Request.Host.Value}/router-config";
                reply.muxs = "00-00-00-00-00-00-00-00";
                _logger.Log(LogLevel.Information, JsonSerializer.Serialize(reply));
                var message = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(reply));

                await webSocket.SendAsync(new ArraySegment<byte>(message, 0, message.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                _logger.Log(LogLevel.Information, "Message sent to Client");

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                _logger.Log(LogLevel.Information, "Message received from Client");
                buffer = null;

            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            _logger.Log(LogLevel.Information, "WebSocket connection closed");
        }

        private async Task AnswerRouterConfig(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.Log(LogLevel.Information, "Received a router info from client");

            while (!result.CloseStatus.HasValue)
            {
                var input = Encoding.UTF8.GetString(buffer).Replace("\0", "");
                _logger.Log(LogLevel.Information, $"Received message: {input}");

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                _logger.Log(LogLevel.Information, "Message received from Client");
                buffer = null;

            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            _logger.Log(LogLevel.Information, "WebSocket connection closed");
        }
    }
}
