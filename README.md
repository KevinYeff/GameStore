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
web application, returning this WebApplication instance.

> **_SUMMARY:_** <br>- `builder` is an object that allow us to configure the web application<br>- `app` it is he instance of the web application built and ready to be executed.
