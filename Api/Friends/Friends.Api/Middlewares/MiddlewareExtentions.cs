using Microsoft.AspNetCore.Builder;

namespace Friends.Api.Middlewares
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
