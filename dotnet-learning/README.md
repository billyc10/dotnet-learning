# .NET Fundamentals #
## .NET 6 Preamble ##
Previously in .NET 5 there was a `Startup.cs` class that contained the methods:
- `ConfigureServices` (setting up DI) and
- `Configure` (middlewares/request-handling pipeline)

These were executed at runtime when the app starts. The Startup and Program classes are now unified into a single `Program.cs` file.

Additionally, `Program.cs` used to contain a `Main()` function by default, which created the host. The new .NET 6 _minimal hosting model_ allows a simplification of this to in-line statements.

---
# Program Class
## .NET Host

The default entrypoint of a .NET application is `Program.cs`. The Program class creates, configures and executes the .NET _host_. The host encapsulates all app resources, which include:
- Middelware components
- Dependency injection
- Logging
- Configuration
- `IHostedService` implementations

The two main kinds of hosts are:
- `ASP.NET Core WebApplication` (also known as the _Minimal Host_)
- `.NET Generic Host`

Traditionally (.NET 5 and below), we would create a host builder, build the host, then run the host:

```cs
public static void Main(string[] args) {
    CreateHostBuilder(args).Build().Run();
}

public static IHostBuilder CreateHostBuilder(string[] args) {
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // Startup configures middleware and services
            webBuilder.UseStartup<Startup>();
        });
}     
```

The introduction of the minimal WebApplication host in .NET 6 allows us to streamline this process into:

```cs
var builder = WebApplication.CreateBuilder(args);
/* Configure services */
var app = builder.Build();
/* Configure middleware */
app.Run();
```

_**Note**: The Generic Host is still useful for non-web scenarios, such as background tasks with hosted services_

---
## Services
We can add groups of related services to our host builder using `Add{GROUP_NAME}`
```cs
builder.Services.AddControllers();
```
The code above will register services required for MVC controllers

---
## Middleware
Middleware is software that is assembled into an app pipeline to handle requests and responses. Each component can either choose to pass the request down the pipeline, or perform work on the request.

The request pipeline is built using _Request Delegates_. Each delegate can perform operations before and _after_ the next delegate. It is advised to place error-handling delegates early in the pipeline, so they can catch errors thrown by later delegates.

Request delegates are set up using `Run`, `Map`, and `Use` extension methods.
- `Use` adds a middleware delegate to the request pipeline
- `Map` branches the request pipeline based on the request path
- `Run` adds a _terminal_ middleware to the pipeline - It prevents further middleware from processing the request

In our basic app we use:
```cs
app.UseAuthorization();
```
to use HTTP authorization
```cs
app.MapControllers();
```
to add endpoints for controller actions (maps different request paths to different endpoint routes), and
```cs
app.Run();
```
to conclude the middleware pipeline and run our app.