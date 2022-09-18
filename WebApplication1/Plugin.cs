using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(Plugin))]

public sealed class Plugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings)
    {
        builder.Services.AddControllers().AddApplicationPart(typeof(Plugin).Assembly);
    }

    public override void ConfigureWebApplication(WebApplication app, PluginSettings settings)
    {
        app.MapGet("/api", () => "Hello World!");

        app.MapControllers();
    }
}