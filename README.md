# New Repository Back end for GameStore project


# Reviewing initial folders/files

## Let's take a look in to the `Program.cs` file.

Well, the main porpuse of this default/initial file is to act like a entry
point for the ASP .NET Core Application.<br>
The initial code inside this file starts/boots the app. It creates an instance
of webApplication class, This web application is used to configure the HTTP
pipeline and the routes, it acts like a host for our web application because
it introduces a HTPP server implementation for the app so the app can start
listening for HTPP requests, it also can set a bunch of middleware components,
and many more configurations.<br>

### Let's check the next line of codes
```c#
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
```
Here the varible `builder` is essential for the initial configuration of the 
ASP.NET Core application and serves as a starting point for defining how the
application will behave at runtime.

The variable `app` is the representation of the ASP.NET Core web application
itself. The `builder.Build()` call is what actually builds and configures the
web application, returning this WebApplication instance.<br>

For the same reason that app is already an instance of webApplication, it can
be used for other configurations, i.e. configurations such as routing,
middleware configurations, etc.<br>
```c#
app.MapGet("/", () => "Hello World!");

app.Run();
```
Initially, in this lines, the basic behavior of the web application is being
configured, in this case when a get request is received to the root of the
application the request handling (`app.MapGet()` method) will be activated
and the string "Hello World!" will be returned as a response.
the `app.Run()` initiattes the application's request processing loop. it is
the primary entry point for handling incoming HTPP requests and sending
corresponding responses.

> **_SUMMARY:_** <br>- `builder` is an object that allow us to configure the web application.<br>- `app` it is he instance of the web application built and ready to be executed.<br>- `app.MapGet()`  defines a routing path for the GET request.<br>- `app.Run()` executes the web application/initializes a request processing loop to process requests based on configuration.

## The .csproj file

This file is the project file, it will define the type of project that we have.

`GameSttore.Api.csproj` 
```c#
<Project Sdk="Microsoft.NET.Sdk.Web">
</Project>
```
This line of code will tell us that this is a web project and
```c#
    <PropertyGroup>
    // targets the framework
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>
```
by default it will import a buch of libraries and dependancies for the project.

# The .json files

This files are configuratons where you can put everting that should not be
hardcoded in your project,represent a set of configurations that could change
across eviroments.

the `appsettings.Development.json` only works in the development enviroment,
for producction you may use the `appsettings.json` also allows more sets of
configurations.

## the `Properties/launchSettings.json`
The main porpuse of this file is to provide profiles, this profiles are a set
of configrations for local development, it impacts on how the web application
will run on our box/enviroment
> **_NOTE:_** Nothing on this file `launchSetting.json` is going to be available in Production.

