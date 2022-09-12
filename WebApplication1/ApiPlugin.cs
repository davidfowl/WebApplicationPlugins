using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(ApiPlugin))]

public sealed class ApiPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddApplicationPart(typeof(ApiPlugin).Assembly);
    }

    public override void ConfigureWebApplication(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        app.MapControllers();
    }
}