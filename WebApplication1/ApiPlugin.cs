using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(ApiPlugin))]

public sealed class ApiPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginConfiguration pluginConfiguration)
    {
        builder.Services.AddControllers().AddApplicationPart(typeof(ApiPlugin).Assembly);
    }

    public override void ConfigureWebApplication(WebApplication app, PluginConfiguration pluginConfiguration)
    {
        app.MapGet("/api", () => "Hello World!");

        app.MapControllers();
    }
}