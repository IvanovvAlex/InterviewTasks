using Microsoft.AspNetCore.Http;

namespace OnlineStore.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the request
            _logger.LogInformation($"Request from {context.Connection.RemoteIpAddress} " +
                $"at {DateTime.Now}: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
