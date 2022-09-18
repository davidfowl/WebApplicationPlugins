using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(ApiPlugin))]

public sealed class ApiPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings)
    {
        builder.Services.AddControllers().AddApplicationPart(typeof(ApiPlugin).Assembly);
    }

    public override void ConfigureWebApplication(WebApplication app, PluginSettings settings)
    {
        app.MapGet("/api", () => "Hello World!");

        app.MapControllers();
    }
}