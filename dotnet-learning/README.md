# .NET Fundamentals #
The default entrypoint of a .NET application is `Program.cs`. The Program class creates, configures and executes the .NET host. The host encapsulates all app resources, which include:
- HTTP server implemetation
- Middelware components
- Dependency injection
- Logging
- Configuration

## .NET 6 Preamble ##
`Program.cs` used to contain a `Main()` function which created the host. The new .NET 6 _minimal hosting model_ allows a simplification of this to in-line statements.

Previously in .NET 5 there was also a `Startup.cs` class that contained the methods:
- `ConfigureServices` (setting up DI) and
- `Configure` (middlewares/request-handling pipeline)

These were executed at runtime when the app starts. The Startup and Program classes are now unified into a single `Program.cs` file.
