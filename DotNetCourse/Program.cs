var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
//    if (endpoint != null)
//    {
//        context.Response.WriteAsync(endpoint.DisplayName);
//    }
//    await next(context);

//});
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.UseEndpoints(endpoints =>
{
    
    endpoints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync("response from map1");
        //map will work for all get put post delete
    });
    endpoints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync("response from map2");
        //map will work for all get put post delete

    });
    endpoints.MapGet("mapGet", async (context) =>
    {
        await context.Response.WriteAsync("response from Map Get");
        //map will work for all get put post delete

    }); endpoints.MapPost("mapPost", async (context) =>
    {
        await context.Response.WriteAsync("response from map Post");
        //map will work for all get put post delete
    });
    endpoints.Map("files/{fileName}.{extension}", async (context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["fileName"]);
        string? fileextension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"Current File is -fileName -{filename} extension is -{fileextension}");
    });
    endpoints.Map("Emp/name/{empname}", async (context) =>
    {
        string? empname = Convert.ToString(context.Request.RouteValues["empname"]);

        await context.Response.WriteAsync($"Current Employee is  -{empname} ");
    });
});
app.Run(async (context) =>
{
  await  context.Response.WriteAsync($"Request Received at {context.Request.Path}/n");
});
app.Run();
