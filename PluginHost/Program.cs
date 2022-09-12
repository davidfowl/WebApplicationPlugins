using WebApplicationPlugins;

var builder = WebApplication.CreateBuilder(args);

builder.AddPlugins();

var app = builder.Build();

app.MapPlugins();

app.Run();