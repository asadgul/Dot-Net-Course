using DotNetCourse.CustomMiddlewares;

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
    await context.Response.WriteAsync("First Middleware");
    await next(context);
});
//app.UseMiddleware<MyCustomMiddleware>();
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello Second");
//    await next(context);
//});
app.UseMiddlewareExtension();
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Third Middleware");
});
app.Run();