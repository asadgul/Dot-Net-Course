var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();
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
    endpoints.Map("map1", async (context) =>{
     await  context.Response.WriteAsync("response from map1");
        //map will work for all get put post delete
    });
    endpoints.Map("map2", async (context) => {
        await context.Response.WriteAsync("response from map2");
        //map will work for all get put post delete

    });
    endpoints.MapGet("mapGet", async (context) => {
        await context.Response.WriteAsync("response from Map Get");
        //map will work for all get put post delete

    }); endpoints.MapPost("mapPost", async (context) => {
        await context.Response.WriteAsync("response from map Post");
        //map will work for all get put post delete
    });
});
app.Run(async (context) =>
{
    context.Response.WriteAsync("response from EndPoint");
});
app.Run();
