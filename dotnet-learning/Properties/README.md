# Launch Settings
`launchSettings.json` is used to store the _development_ configuration of the app while using Visual Studio. It is ignored when the app is published.

```cs
"profiles": {
    "dotnet_learning": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "restaurantreview",
      "applicationUrl": "http://localhost:5194",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
```

`launchUrl` is the page we visit when starting our app in development. Make sure this is named according to your controller's `[Route("[controller]")]` naming.