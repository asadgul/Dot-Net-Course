
using System.Runtime.CompilerServices;

namespace DotNetCourse.CustomMiddlewares
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Second Middleware \n");
            await next(context);
        }
        
    }

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<MyCustomMiddleware>();
        }
    }

    
}
