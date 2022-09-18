using Microsoft.Extensions.FileProviders;
using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(PagesPlugin))]

public sealed class PagesPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings)
    {
        builder.Services.AddRazorPages().AddApplicationPart(typeof(PagesPlugin).Assembly);

        // The module file provider is a composite of the root and this file provider
        var moduleFileProvider = new CompositeFileProvider(
            builder.Environment.WebRootFileProvider,
            new PhysicalFileProvider(Path.Combine(settings.ContentRootPath, "wwwroot"))
        );

        // Look at static files in this content root as well
        builder.Services.AddOptions<StaticFileOptions>()
            .PostConfigure(o =>
            {
                o.FileProvider = o.FileProvider is not null ?
                    new CompositeFileProvider(o.FileProvider, moduleFileProvider) :
                    moduleFileProvider;
            });
    }

    public override void ConfigureWebApplication(WebApplication app, PluginSettings settings)
    {
        app.MapRazorPages();
    }
}
