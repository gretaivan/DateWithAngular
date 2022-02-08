# DateWithAngular

A dating app built for learning purposes. ASP.NET Core WebAPI and the Angular app using the DotNet CLI and the Angular CLI following best practices.

## Requirements

- Users should be able to login
- Users should be able to register
- Users should be able to view other users
- Users should be able to privatively message other users

## Features

- [ ] use of ssl security
- [ ] password hashing and salt upgraded to ASP .NET identity
- [ ] drag and drop photo upload integrating into a cloud platform
- [ ] private messaging system
- [ ] filtering, sorting and paging of data
- [ ] Display notifications in Angular
- [ ] Authentication using JWT Authentication tokens
- [ ] Real time notifications and presence using SignalR

- [ ] drag and drop photo upload integrating into a cloud platform
- [ ] private messaging system
- [ ] filtering, sorting and paging of data
- [ ] Display notifications in Angular
- [ ] Authentication using JWT Authentication tokens
- [ ] Real time notifications and presence using SignalR

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

## Technologies:

- Angular 12
- ASP .NET Core 6.0
- TypeScript
- C#
- Node 14
- Entity Framework
- AutoMapper
- Sqlite - for development

###### and of course

- Bootstrap
- HTML5
- CSS
- Postman
- Fonts Awesome

### VsCode extensions

- C#
- C# Extension
- NuGet Gallery
- Sqlite
- Angular Language extensions

## Installation & Usage

### Installation

#### ASP .NET

- `dotnet new sln` - create a solution file, helps to unify settings between IDEs
- `dotnet new webapi -o API` - create ASP .NET Core 6 WebAPI project, output is API folder
- if Swashbuckle.AspNetCore error appears try this command - `dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json`
- `dotnet new gitignore`
- `dotnet sln add API` - to add solution into API
- `dotnet ef migrations add <name-migration> -o Data/Migrations` - to create/update/generate db schema
- `dotnet ef database update` - builds application, reads migrations and executes it in the DB

#### AngularJS

- `ng new client --strict false` - to create a new client folder with angular
- `ng add ngx-bootstrap`
- `npm install font-awesome`

### Usage

#### ASP .NET

- `dotnet run` or `dotnet watch run`- to start the application
- `dotnet dev-certs https --trust` - to make computer trust the certificate

#### AngularJS

- `ng serve` - to start the client server

## Development process

### Changelog

- change `appsettings.Development.json` "Microsoft": "Warning" to "Inforamation
- Adds AppUser entity class with Entity framework (add entity framework to dependencies too)
- Adds DataContext in Data, to connect AppUser entity to the DB

```csharp
public void ConfigureServices(IServiceCollection services){
    services.AddDbContext<DataContext>(options => {
    options.UseSqlite(this._config.GetConnectionString("DefaultConnection"));
});
```

- Adds in the `Startup.cs` file the the connection DataContext stating to connect to the SQlight with the DefualtConnection string

- Adds `appsettings.Development.json` the connection string to the settings file for develpment, see `ConnectionString`, it will point to the db and defines the connection string

- dotnet migrate and then update the database. In the dev DB adds some initial data to work with
- creates user controller and route with get methods
- hides the connection and and other files that are for gitignore for dotnet

- _Client_ - seeting up the main component to fetch the user api
- _API_ implement CORS

#### API 
- added BaseController class to reuse ApiController decorators 
- extened the AppUser class to have PasswordHash and Salt
- created new controller `AccountContoller.cs` with registration route, to work with query passing and password hashing and salting
- creates data transfer object `RegisterDTO`  to hide or flatten objects

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
