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
Services are registered in the Program class before middleware.

## Dependency Injection

When using dependency injection for inversion of control (IoC), the concrete types (services) are registered in the Program class. A service lifetime is specified which dictates the 'scope' of the class.

For example:
```cs
builder.services.AddScoped<IMyDependency, MyDependency>
```

### Service Lifetimes
- **Singleton**: Only one instance of the class is created and used for all requests for the lifetime of the app
- **Scoped**: One instance is created per request, but re-used for repeated calls within the same request. For example `AddDbContext` when using Entity Framework Core registers `DbContext` types with a scoped lifetime by default.
- **Transient**: An instance is spun of of the class each time it is called. This is best for lightweight, stateless services.

It is important to _NOT_ resolve a scoped service from within a singleton service, to avoid _captive dependencies_. This is when a service depends on a shorter-lived service.

## Grouped  Services
We can add groups of related services to our host builder using `Add{GROUP_NAME}`
```cs
builder.Services.AddControllers();
```
The code above will register services required for MVC controllers. Under the hood this is just registering 

If we have our own custom group of services, we can use an extension method to register them in the Program class in one go.

Using an extension method:
```cs
public static class ServicesRegistry
{
    public static void AddMyDependencyGroup(this IServiceCollection, services)
    {
        services.AddScoped<IMyDependency, MyDependency>();
        services.AddScoped<IMyDependency2, MyDependency2>();

        return services;
    }
}
```
Then in Program class:
```cs
builder.services.AddMyDependencyGroup();
```

## Service Disposal
Transient and scoped services are disposed of at the end of the request. Singleton services that are resolved from the container (i.e. registered with `AddSingleton<IX, X>`) are disposed of automatically by the container.

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

# TODO:
- Clean up Database implementation (run a local real database)
- Add a docker image that spins up a fake upstream API
- Add OpenAPI specification to the controller
- Make call to Upstream API (learn about `HttpClient`)
- Add Auth