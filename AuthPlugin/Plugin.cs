using Microsoft.AspNetCore.Authorization;
using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(Plugin))]

sealed class Plugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginSettings settings)
    {
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("admin", pb => pb.RequireRole("admin"));
    }
}
