using Microsoft.AspNetCore.Builder;

namespace WebApplicationPlugins;

public abstract class WebApplicationPlugin
{
    public virtual void ConfigureWebApplicationBuilder(WebApplicationBuilder builder) { }
    public virtual void ConfigureWebApplication(WebApplication app) { }
}
