This solution has 3 parts:

FileStorage.API is the ASP.NET Core Web API

FileStorage.Web is the Blazor UI

FileStorage.UnitTest contains the MS tests

Steps to setup up project:

Download project.
Open project in Visual Studio 2022. 
Browse to Tools | Nuget Package Manager | Package Manager Console
Type: Update-Database
This will create the database.
Right-click on the solution and select Configure Startup Projects...
Make sure the Muliple startup projects radion button is selected.
Make sure the FileStorage.API and FileStorage.Web are both set to Start.
That's it, enjoy! 
