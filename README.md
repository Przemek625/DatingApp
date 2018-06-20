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
