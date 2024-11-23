using DotNetCourse.CustomMiddlewares;
using System.Xml.Linq;

namespace DotNetCourse.CustomMiddlwareConvention
{
    public class MiddlewareCustomConvention
    {
        public  readonly RequestDelegate requestDelegate;
        public MiddlewareCustomConvention(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public  async Task Invoke(HttpContext httpContext) {
            if (httpContext.Request.Query.ContainsKey("firstName") && httpContext.Request.Query.ContainsKey("lastName"))
            {
                var name = httpContext.Request.Query["firstName"];
                var last = httpContext.Request.Query["lastName"];
                await httpContext.Response.WriteAsync(name + last+"\n");

            }
            await requestDelegate(httpContext);
        }
    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareCustomConvention(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<MiddlewareCustomConvention>();
        }
    }
}
