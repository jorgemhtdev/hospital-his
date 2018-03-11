# Hospital
 
### Introduction
Small example using Xamarin Forms 2.5, MVC5 and web api. 

Login in Xamarin Forms 2.5 with our API. Get, create, delete and update ([CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete)) records from Xamarin Forms from our API. All queries from Xamarin Forms are made with token.

![](https://img.shields.io/teamcity/codebetter/bt428.svg) [![License:MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

# Usage
### Update your connectionStrings
Configure a connection string for SQL Server in the Web.config
```
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data 
    Source=YOURTDATABASE; 
    Initial Catalog=YOURNAMEDB; Persist Security     
    Info=True;User ID=YOURUSER;Password=YOURPASSWORD”"
    providerName="System.Data.SqlClient" />
  </connectionStrings>-->
```
[Connection String Syntax](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax)
[Learn more about connection strings](https://www.connectionstrings.com)

### Configure validation logic for passwords
By default, if you don't customise anything, Identity configures a default set of validation rules for new passwords. If you want to change these values, you can change the file called App_Start/IdentityConfig.cs

```
    manager.PasswordValidator = new PasswordValidator
    {
        RequiredLength = 6, // Passwords must be at least 6 characters
        RequireNonLetterOrDigit = false, // Passwords must have at least one digit ('0'-'9')
        RequireDigit = false, // Passwords must have at least one non alphanumeric character
        RequireLowercase = false, // // Passwords must have at least one lowercase ('a'-'z')
        RequireUppercase = false, // Passwords must have at least one uppercase ('A'-'Z')
    };
```
[PasswordValidator Class](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.identity.passwordvalidator(v=vs.108).aspx)

### Set the color in the project 
In our PCL, the file App.xaml you can change the color
```
    <Color x:Key="MainColor">#273646</Color>
    <Color x:Key="FontColor">#2d8dd6</Color>
    <Color x:Key="AccentColor1">#2371aa</Color>
    <Color x:Key="AccentColor2">#e44235</Color>
    <Color x:Key="BackgroundColor">#e9eeef</Color>
```
[Resource Dictionaries](https://developer.xamarin.com/guides/xamarin-forms/xaml/resource-dictionaries/)

### Set your API
In our PCL, the file Services/HttpService.cs you must put the url of your api and prefix
```
    private string urlBase = "YourURLApi/";
    private string servicePrefix = "YourPrefix/";
```
[Rest api tutorial - Microsoft](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)
[Rest api tutorial - hackernoon](https://hackernoon.com/restful-api-designing-guidelines-the-best-practices-60e1d954e7c9)
[Rest api tutorial - code-maze](https://code-maze.com/top-rest-api-best-practices/)
[Rest api tutorial - solidgeargroup](https://solidgeargroup.com/best-practices-rest-api)

# Security
OAuth 2.0 protocol and Microsoft Owin Library will help us. Owin is basically creating own pipeline between iis and application to manage requests.

In the file Startup.Auth.cs an OWIN Authorization server is configured to accept login (token) HTTP requests at /Token endpoint and external login requests at /api/Account/ExternalLogin

[OAuthAuthorizationServerOptions Class](https://msdn.microsoft.com/en-us/library/microsoft.owin.security.oauth.oauthauthorizationserveroptions(v=vs.113).aspx)
[Oauth](https://oauth.net/)

# Plugins
### Web API and MVC5 
| Plugin | Project |
| ------ | ------ |
| EntityFramework | Model |
| Newtonsoft | Model |

### Xamarin 
| Plugin | Author |
| ------ | ------ |
| Mvvm-helpers | [james montemagno][PlDb] |
| Settings | [james montemagno][PlMe] |
| MvvmLightLibsStd10 | [galasoft][PlGh] |
| Connectivity | [james montemagno][PlGd] |
| Newtonsoft | [james Newton-King][NtSt] |
| Image Circle | [james montemagno][PlOd] |

# Tools
The following tools are essential:
* [Genymotion] - The Best Android Emulator
* [Postman] - Application which is used to fire requests to an API. It is possible to make different kinds of HTTP requests – GET, POST, PUT, PATCH and DELETE.
* [Quicktype] - Generate c# classes from json.
* [Color Adobe] - To create color schemes for my designs. For this project I have choosen https://color.adobe.com/Flat-UI-color-theme-2469224/

# Recommended links
[Getting Started with ASP.NET MVC 5](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started)

License
----

The MIT License (MIT) see [License file](https://github.com/jorgemht/Hospital-HIS/blob/master/LICENSE)

   [Genymotion]: <https://www.genymotion.com>
   [Postman]: <https://www.getpostman.com>
   [Quicktype]: <https://app.quicktype.io/#l=cs&r=json2csharp>
   [Color Adobe]: https://color.adobe.com

   [PlDb]: <https://github.com/jamesmontemagno/mvvm-helpers>
   [PlMe]: <https://github.com/jamesmontemagno/SettingsPlugin>
   [PlGh]: <https://www.nuget.org/packages/MvvmLightLibsStd10/5.4.0.1-alpha>
   [PlGd]: <https://github.com/jamesmontemagno/ConnectivityPluginx>
   [PlOd]: <https://github.com/jamesmontemagno/ImageCirclePlugin>
   [NtSt]: <https://www.newtonsoft.com/json>

