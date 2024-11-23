using DotNetCourse.CustomMiddlewares;
using DotNetCourse.CustomMiddlwareConvention;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("First Middleware \n");
    await next(context);
});
//app.UseMiddleware<MyCustomMiddleware>();
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello Second");
//    await next(context);
//});
app.UseMiddlewareExtension();
app.UseMiddlewareCustomConvention();
app.UseWhen(context => context.Request.Query.ContainsKey("userName"),
   // Use when is a middleware when condition true then all internal middleware will execute you can add bunch of middleware
   app =>
   {
       app.Use(async (HttpContext context, RequestDelegate req) =>
    {
        await context.Response.WriteAsync("Request From Use When \n");
    });
   });
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Third Middleware");
});
app.Run();