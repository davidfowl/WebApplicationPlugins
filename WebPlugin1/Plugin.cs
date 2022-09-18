using WebApplicationPlugins;
using WebPlugin1;

[assembly: WebApplicationPlugin(typeof(Plugin))]

namespace WebPlugin1;

public sealed class Plugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings)
    {
        builder.Services.AddSignalR();
    }

    public override void ConfigureWebApplication(WebApplication app, PluginSettings settings)
    {
        app.MapHub<Chat>("/chat");
    }
}