This solution has 3 parts:

FileStorage.API is the ASP.NET Core Web API

FileStorage.Web is the Blazor UI

FileStorage.UnitTest contains the MS tests

Steps to setup up project:

1.) Download project.<br/>
2.) Open project in Visual Studio 2022.<br/>
3.) Browse to Tools | Nuget Package Manager | Package Manager Console<br/>
4.) Type: Update-Database<br/>
5.) This will create the database.<br/>
6.) Right-click on the solution and select Configure Startup Projects...<br/>
7.) Make sure the Muliple startup projects radion button is selected.<br/>
8.) Make sure the FileStorage.API and FileStorage.Web are both set to Start.<br/>

That's it, enjoy! 
