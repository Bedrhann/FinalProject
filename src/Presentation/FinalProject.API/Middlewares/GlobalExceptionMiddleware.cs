using Serilog;
using System.Net;
using System.Text.Json;

namespace FinalProject.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {

        private static readonly Serilog.ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>();
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                string message = "[Request] HTTP " + httpContext.Request.Method + " " + httpContext.Request.Path;
                _logger.Error(message);

                await _next(httpContext);

                message = "[Request] HTTP " + httpContext.Request.Method + " " + " reponded " + httpContext.Response.StatusCode;
                _logger.Error(message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);

            }
        }


        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[ERROR] HTTP " + httpContext.Request.Method + " - " + httpContext.Response.StatusCode + " - " + " Error Messsage " + ex.Message;

            _logger.Error(message);

            var result = JsonSerializer.Serialize(new { error = ex.Message });
            return httpContext.Response.WriteAsync(result);

        }

    }
}
