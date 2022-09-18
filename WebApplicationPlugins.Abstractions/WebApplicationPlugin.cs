using Microsoft.AspNetCore.Builder;

namespace WebApplicationPlugins;

public abstract class WebApplicationPlugin
{
    public virtual void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings) { }
    public virtual void ConfigureWebApplication(WebApplication app, PluginSettings settings) { }
}

public class PluginSettings
{
    public string ContentRootPath { get; init; } = default!;
}