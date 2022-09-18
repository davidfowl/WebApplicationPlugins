using GrpcService1.Services;
using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(GrpcPlugin))]

public sealed class GrpcPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings)
    {
        builder.Services.AddGrpc();
    }

    public override void ConfigureWebApplication(WebApplication app, PluginSettings settings)
    {
        app.MapGrpcService<GreeterService>();
    }
}