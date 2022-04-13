s# DateWithAngular

A dating app built for learning purposes. ASP.NET Core WebAPI and the Angular app using the DotNet CLI and the Angular CLI following best practices.

## Requirements

- Users should be able to login
- Users should be able to register
- Users should be able to view other users
- Users should be able to privatively message other users

## Features

- [x] use of ssl security
- [x] password hashing and salt
- [ ] hash and salt upgraded to ASP .NET identity
- [ ] drag and drop photo upload integrating into a cloud platform
- [ ] private messaging system
- [ ] filtering, sorting and paging of data
- [ ] Display notifications in Angular
- [x] Authentication using JWT Authentication tokens
- [ ] Real time notifications and presence using SignalR
- [ ] drag and drop photo upload integrating into a cloud platform
- [ ] private messaging system
- [ ] filtering, sorting and paging of data
- [ ] Display notifications in Angular
- [ ] Real time notifications and presence using SignalR

## Aims

- [x] Adding a Client side login and register function to our Angular application
- [ ] Adding routing to the Angular application and securing routes.
- [ ] Using Automapper in ASP.NET Core
- [ ] Building UI using Bootstrap
- [ ] Adding Photo Upload functionality as well as a gallery in Angular
- [ ] Angular Template forms and Reactive forms and validation
- [ ] Paging, Sorting and Filtering
- [ ] Adding a Private Messaging system to the app
- [ ] Using SignalR for real time presence and live messaging between users
- [ ] Handling errors in the API and the SPA
- [ ] Persist data using Entity Framework Core

## Technologies:

- Angular 12
- ASP .NET Core 5.0.13
- TypeScript
- C#
- Node 14
- Entity Framework
- AutoMapper
- Sqlite - for development
- System.Identity model tokens jwt
- Microsoft.Aspnetcore.Authentication.JWTBearer c 5.0.13

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
- `dotnet ef database drop` - if you want to clean the database

#### AngularJS

- `ng serve` - to start the client server
- `ng g c <name>` creates new component
- `ng g s <name>` optional part `--skip-tests` - creates the service

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
- created data transfer object `RegisterDTO` to hide or flatten objects
- refined `AccountController` to take request body, through dto use, check if username is new and return bad request if it exists.
- created `LoginDTO` to remap the User entity
- adds login method in `AccountController` with validation
- created JWT token service interface `ITokenCreator`
- created `TokenService` that implements the token interface
- added token service to the dependency injector box `Startup.cs` within the scope of Http request.
- implemented token service `TokenService`
- created `UserDTO` that is an object to be returned post login or registration
- implements JWT token in the `AcountController`, updates login and register methods to return user object with token
- added token string for development environment, that can be sent to the remote repo `appsettings.Development.json`
- installed microsoft api core jwt bearer, added protected routers to the `UserController`
- added middleware in the `Startup.cs` dependency injection `ConfigureServices()` to add the JwtBearerService with the required config and `Configure()` method `UseAuthentication` between corse and authorization and sequence is important.
- Created `Extensions`: `ApplicationServiceExtensions` and `IdentityServiceExtensions` to refactor `Startup.cs` token and data/db services. [see](#### Extension methods)

#### Client

- generated nav component with CLI
- added bootstrap in the `app.module.ts`
- added navigation component `nav` with login form that takes the input and outputs to console log using ngModel
- created account service `account.services.ts` that creates the post request to the `api/account/login`

## Some theory

### Observables

appeared since Angular 2. It is lazy collections of multiple values over time, used to handle async data e.g. for http requests and for components to be "watched" for change of values - only subscribers will receive the data updates. After subscribing definition what to do with the data is required on success and on error and when complete:

```
  .subscribe( x => {},
  error => {},
  () => {})
```

or to send to the promise `toPromise()` and handle it as a normal promise, or automatically subscribe/ unsubscribe from the Observables:

```
<li *ngFor='let member of service.getMembers() | async'>{{member.username}}</li>

```

| Promise                        | Observable                                           |
| ------------------------------ | ---------------------------------------------------- |
| Provides a single future value | Emits multiple values over the time                  |
| Not lazy                       | Lazy                                                 |
| Can not cancel                 | Able to cancel                                       |
|                                | Can use with map, filter, reduce and other operators |

#### RxJS

Reactive extensions for JS it works with Observables. RxJS enables the Obeservable data manipulation. `.pipe()` method allows to chain as many functions to transform or select parts of the data.

### Entity Framework

An Object Relation Mapper (ORM). I translates our code into SQL commands that update tables in the database. In sense it is an automation framework. Features:

- Quering
- Change Tracking
- Saving
- Concurrency
- Transactions
- Caching
- Built-in conventions
- Configuration - for conventions
- Migration - allows schema creation in DB

### JWT Structure

Anytime the user wants to access any part that requires the authentication, the JWT token should be used. The action flow is as follows:

1. Client: sends username + password
2. Server: validates credentials and returns JWT
3. Client: Send JWT with further requests
4. Server: verifies JWT and sends back response

#### Benefits:

- no need to manage sessions.
- Portable - a single token with multiple backends as long as backends share the same secret key
- No cookies required - mobile friendly
- Performance - no need to connect to DB to verify users authentication, once token is issued.

* Header - algorithm token and token type. Algorithm encrypts the token

```json
{
  "alg": "algorithm type",
  "typ": "JWT"
}
```

- Payload - contains information about the request claims and identifies the user. i.e. is user the entity that it claims to be

```json
{
  "sub": "1234567890",
  "name": "John Doe",
  "admin": true
}
```

- Signature - encrypted by the server, using the secure key that does not leave the server.

```json
    HMACSHA256(base64UrlEncode(header) + "." + base64UrlEncode(payload), secret)
}
```

### Dependency injection container | ConfigureServices

#### Service lifecycle

- .AddSingleton - does not stop untill aplication stops
- .AddScoped<interface, service> - whatver controller scope is, thats when it is used. e.g. apicontroller tied to the service - means that when request is finished service will be disposed. Best suited for http requests. TO use with JWT tokens add the token service: `services.AddScoped<ITokenCreator, TokenService>(); `
- .AddTransient - created and destroyed as soon as the method is finished but not suitable for Http Requests

#### Extension methods

is a good practice to keep a startup class as clean as possible. The method that is being extended should be preceded with keyword `this` anything else is passed as a standard parameter.

#### Angular

- Two way biding syntax `()` means from the template to component and `[]` from component to the template and `[()]` is a two way binding
- Angular service is injectable and a singleton - once injected to the component and initlised it will stay initialised until disposed e.g. browser is closed. Injection is made through a componentconstructor
