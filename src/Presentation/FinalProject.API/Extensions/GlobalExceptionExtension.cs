using FinalProject.API.Middlewares;

namespace FinalProject.API.Extensions
{
    public static class GlobalExceptionExtension
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
