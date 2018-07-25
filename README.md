## Start App
`dotner -h`
`dotnet new webapi -h`
`dotnet new webapi -o Datingapp.API -b Datingapp.API`
`code`
`dotnet ef`
`dotner ef migration add InitialCreate`

https://www.a2hosting.com/kb/developer-corner/sqlite/connect-to-sqlite-from-the-command-line

## Insert values into db
sqlite3 Datingapp.db
insert into "values" values(1, "Przemek1");
insert into "values" values(2, "Przemek2");
insert into "values" values(3, "Przemek3");

### Make migrations and migrate

1.dotnet ef migrations add AddUserModel
2.dotnet ef database update


### Terms in course
Repository Pattern


### Useful links
https://docs.microsoft.com/pl-pl/dotnet/#pivot=docs&panel=getstarted
https://www.newtonsoft.com/json
https://stackoverflow.com/questions/38138100/what-is-the-difference-between-services-addtransient-service-addscope-and-servi
https://docs.microsoft.com/pl-pl/dotnet/csharp/programming-guide/concepts/async/
https://docs.microsoft.com/pl-pl/dotnet/core/tools/dotnet-add-package
https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/
https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core/40275196
https://lostechies.com/jimmybogard/2016/07/20/integrating-automapper-with-asp-net-core-di/
https://dotnetcoretutorials.com/2017/09/23/using-automapper-asp-net-core/
https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection

https://pl.wikipedia.org/wiki/W%C5%82a%C5%9Bciwo%C5%9B%C4%87_(informatyka)

### vsc shourcuts
`prop`
`ctor`

### About dependency injection in dotnet core
Transient objects are always different; a new instance is provided to every controller and every service.
Scoped objects are the same within a request, but different across different requests
Singleton objects are the same for every object and every request (regardless of whether an instance is provided in ConfigureServices)

### Extending model
dotnet ef migrations add ExtendedUserClass

### List migrations
dotnet ef migrations list

### Remove migrations
 dotnet ef migrations remove

### Reverse to previous migrations
dotnet ef migrations add ExtendUserClass
dotnet ef database update
dotnet ef database update AddUserModel

or drop database and generate new migrations

dotnet ef database drop
dotnet ef database remove
dotnet ef databse update

### Add package 
dotner add package packageName

### Instal required libraries
http://docs.automapper.org/en/stable/
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Cloudinary --version 0.0.5

### ASP Dot Net Core docs
https://docs.microsoft.com/pl-pl/aspnet/index?view=aspnetcore-2.1#pivot=core&panel=core_overview
