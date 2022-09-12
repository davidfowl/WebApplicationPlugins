using WebApplicationPlugins;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebApplicationPlugins();

var app = builder.Build();

app.MapPlugins();

app.Run();