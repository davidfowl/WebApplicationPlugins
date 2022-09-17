using Microsoft.Extensions.FileProviders;
using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(PagesPlugin))]

public sealed class PagesPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginConfiguration pluginData)
    {
        builder.Services.AddRazorPages().AddApplicationPart(typeof(PagesPlugin).Assembly);

        builder.Services.AddOptions<StaticFileOptions>()
            .PostConfigure(o =>
            {
                o.FileProvider = new CompositeFileProvider(builder.Environment.WebRootFileProvider, new PhysicalFileProvider(Path.Combine(pluginData.ContentRootPath, "wwwroot")));
            });
    }

    public override void ConfigureWebApplication(WebApplication app, PluginConfiguration pluginData)
    {
        app.MapRazorPages();
    }
}
