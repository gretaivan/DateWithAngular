# DateWithAngular

A dating app built for learning purposes. ASP.NET Core WebAPI and the Angular app using the DotNet CLI and the Angular CLI following best practices.

## Aims

- [ ] Adding a Client side login and register function to our Angular application
- [ ] Adding 3rd party components to add some pizzazz to the app
- [ ] Adding routing to the Angular application and securing routes.
- [ ] Using Automapper in ASP.NET Core
- [ ] Building a great looking UI using Bootstrap
- [ ] Adding Photo Upload functionality as well as a cool looking gallery in Angular
- [ ] Angular Template forms and Reactive forms and validation
- [ ] Paging, Sorting and Filtering
- [ ] Adding a Private Messaging system to the app
- [ ] Publishing the application to Heroku free of charge
- [ ] Using SignalR for real time presence and live messaging between users
- [ ] Handling errors in the API and the SPA
- [ ] Persist data using Entity Framework Core
- [ ]
- [ ]
- [ ]
- [ ]

## Features

- [ ] drag and drop photo upload integrating into a cloud platform
- [ ] private messaging system
- [ ] filtering, sorting and paging of data
- [ ] Display notifications in Angular
- [ ] Authentication using JWT Authentication tokens
- [ ] Real time notifications and presence using SignalR

-[ ] drag and drop photo upload integrating into a cloud platform -[ ] private messaging system -[ ] filtering, sorting and paging of data -[ ] Display notifications in Angular -[ ] Authentication using JWT Authentication tokens -[ ] Real time notifications and presence using SignalR

## Technologies:

- Angular 12
- ASP .NET Core 6.0
- TypeScript
- C#
- Node 14
- Entity Framework
- AutoMapper
- Sqlight - for development

###### and of course

- Bootstrap
- HTML5
- CSS
- Postman

### VsCode extensions

- C#
- C# Extension
- NuGet Gallery

## Installation & Usage

### Installation

- `dotnet new sln` - create a solution file, helps to unify settings between IDEs
- `dotnet new webapi -o API` - create ASP .NET Core 6 WebAPI project, output is API folder
- if Swashbuckle.AspNetCore error appears try this command - `dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json`
- `dotnet sln add API` - to add solution into API
- `dotnet ef migrations add <name-migration> -o Data/Migrations` - to create/update/generate db schema

### Usage

- `dotnet run` or `dotnet watch run`- to start the application
- `dotnet dev-certs https --trust` - to make computer trust the certificate

## Development process


### Changelog

- change `appsettings.Development.json` "Microsoft": "Warning" to "Inforamation
- Adds AppUser entity class with Entity framework (add entity framework to dependencies too)
- Adds DataContext in Data, to connect AppUser entity to the DB 
```csharp
public void ConfigureServices(IServiceCollection services)
			{
				services.AddDbContext<DataContext>(options => {
					options.UseSqlite(this._config.GetConnectionString("DefaultConnection"));
				}); 
  ```
- Adds in the `Startup.cs` file the the connection DataContext stating to connect to the SQlight with the DefualtConnection string

- Adds `appsettings.Development.json` the connection string to the settings file for develpment, see `ConnectionString`, it will point to the db and defines the connection string

## Some theory

### Entity Framework

An Object Relation Mapper (ORM). I translates our code into SQL commands that update tables in the database. In sense it is an automation framework. Features:

- Quering
- Change Trancking
- Saving
- Concurrency
- Transactions
- Caching
- Built-in conventions
- Configuration - for conventions
- Migration - allows schema creation in DB
