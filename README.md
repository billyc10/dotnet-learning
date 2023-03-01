# ASP.NET API Learning Project #
This is a project to learn about creating Web APIs in .NET
I will be building the API with as little boilerplates as possible, and document the journey along the way.

## What is ASP.NET
.NET is a unified platform (a runtime engine) that can be used to build almost any type of app. It is very similar to Java in many ways, and can be used to build:
- Desktop apps
- Web apps (ASP.NET)
- Workers

It is language agnostic and can be used with a vareiety of langauges including C#, VB, Python etc...

ASP.NET is a C# framework to build web applications. Other competitors include Python Flask, Node.js Express etc. It is often used in enterprise level applications.

## .NET Project SDKs ##
When creating a new .NET project (either in Visual Studio or using `dotnet new`), you select a _template_, e.g.
- Console Application
- ASP.NET Core Web App
- ASP.NET Core Web API
- Worker Service

Not only does the template create a basic directory with core classes, it also specifies the **.NET project SDK** that is used.
The _project_ SDK is responsible for compiling, packing and publishing code. The available SDKs are:
- `Microsoft.NET.Sdk`
- `Microsoft.NET.Sdk.Web`
- `Microsoft.NET.Sdk.BlazorWebAssembly`
- `Microsoft.NET.Sdk.Razor`
- `Microsoft.NET.Sdk.Worker`
- `Microsoft.NET.Sdk.WindowsDesktop`

All SDKs use the `Microsoft.NET.Sdk` as a base. Specify an SDK by adding `<Project Sdk="Microsoft.NET.Sdk.Web">` in the `.csproj` file. For example, if you use the `Microsoft.NET.Sdk.Web` SDK, the project will implicitly reference the ASP.NET Core shared framework, which is needed for example by Controller classes.

[Further reading](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview?view=aspnetcore-7.0)

## The Learning Project ##
For this learning project, the plan is to build a restaurant review API, which a client can query to retrieve reviews and ratings for restaurants, as well as submit new reviews. For this we will be setting up basic project using the ASP.NET Core Web API, which will be using the `Microsoft.NET.Sdk.Web` MSBuild project SDK.