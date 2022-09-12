# WebApplicationPlugins

A sample plugin model for ASP.NET Core applications. Write an ASP.NET Core application and derive from WebApplicationPlugin and add the assembly attribute:

```C#
using WebApplicationPlugins;

[assembly: WebApplicationPlugin(typeof(HelloPlugin))]

public sealed class HelloPlugin : WebApplicationPlugin
{
    public override void ConfigureWebApplication(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}
```

Then in the main application (or plugin host), add the boilerplate to discover and register plugins:

```C#
using WebApplicationPlugins;

var builder = WebApplication.CreateBuilder(args);

builder.AddPlugins();

var app = builder.Build();

app.MapPlugins();

app.Run();
```

The last step is to add the plugin configuration (these are dynamically loaded):

```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Plugins": {
    "HelloPlugin": {
      "ContentRootPath": "..\\HelloPlugin",
      "AssemblyPath": "..\\HelloPlugin\\HelloPlugin.dll"
    }
  }
}
```

`AddPlugins` will look at the "Plugins" configuration section (this is configurable) for the above schema. Configuration will be loaded and merged from the content root
and the plugin and its dependencies will be loaded from the assembly path. 

**NOTE:** Plugin projects with NuGet dependencies should set `<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>` so that nuget dependencies
get copied to the output folder alongside the plugin.