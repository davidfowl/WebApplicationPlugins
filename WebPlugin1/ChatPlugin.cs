using WebApplicationPlugins;
using WebPlugin1;

[assembly: WebApplicationPlugin(typeof(ChatPlugin))]

namespace WebPlugin1;

public sealed class ChatPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginConfiguration pluginConfiguration)
    {
        builder.Services.AddSignalR();
    }

    public override void ConfigureWebApplication(WebApplication app, PluginConfiguration pluginConfiguration)
    {
        app.MapHub<Chat>("/chat");
    }
}