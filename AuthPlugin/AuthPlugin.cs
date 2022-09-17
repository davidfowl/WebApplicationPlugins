using Microsoft.AspNetCore.Authorization;
using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(AuthPlugin))]

sealed class AuthPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplicationBuilder(WebApplicationBuilder builder, PluginConfiguration pluginConfiguration)
    {
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("admin", pb => pb.RequireRole("admin"));
    }
}
