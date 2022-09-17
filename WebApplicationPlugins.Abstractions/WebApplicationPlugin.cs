using Microsoft.AspNetCore.Builder;

namespace WebApplicationPlugins;

public abstract class WebApplicationPlugin
{
    public virtual void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginConfiguration pluginData) { }
    public virtual void ConfigureWebApplication(WebApplication app, PluginConfiguration pluginData) { }
}

public class PluginConfiguration
{
    public string ContentRootPath { get; init; } = default!;
}