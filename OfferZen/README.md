# OfferZen .NET Application

OfferZen is a modular .NET 8 web application implementing clean architecture principles. It provides product and category management capabilities, featuring MediatR for CQRS pattern, Entity Framework Core for ORM, and a layered solution structure.

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Projects Structure](#projects-structure)
- [Installation](#installation)
- [Database Migration Setup](#database-migration-setup)
- [Dependencies and Packages](#dependencies-and-packages)
- [Running the Application](#running-the-application)
- [Contributing](#contributing)

### Features

- Product and Category CRUD operations
- Product search engine integration
- MediatR used for mediator pattern (CQRS separation)
- EF Core 8 Code-First migrations
- Modular and maintainable layered architecture

### Tech Stack

- .NET 8 (C#)
- ASP.NET Core Web API
- Entity Framework Core 8
- MediatR
- Microsoft Dependency Injection

### Projects Structure

- `OfferZen.Api`: Presentation Layer (API controllers, DI, app settings)
- `OfferZen.Application`: Application Layer (Commands, Queries, Events, MediatR handlers)
- `OfferZen.Core`: Domain Layer (Domain models and interfaces)
- `OfferZen.Infrastructure`: Infrastructure Layer (Repositories, EF Core, Migrations)

### Installation

1. Clone the repository:
    ```
    git clone https://github.com/EngineerBen10/OfferZen-Assessment.git
    ```
2. Open in Visual Studio 2022+ or VS Code.

3. Restore NuGet packages:
    ```
    dotnet restore
    ```

### Database Migration Setup

1. Install necessary EF Core packages (already added):

    - `Microsoft.EntityFrameworkCore`
    - `Microsoft.EntityFrameworkCore.Tools`

2. Run the following commands in the Package Manager Console or terminal:

    - To create your  migration  replace `{{name}}`:
      ```
       dotnet ef migrations add {{name}} --project OfferZen.Infrastructure --startup-project OfferZen.Api --output-dir Migrations
      ```
    - To update the database:
      ```
      dotnet ef database update --project OfferZen.Infrastructure --startup-project OfferZen.Api
      ```

    Migrations are contained within the `/Infrastructure/Migrations` folder.

### Dependencies and Packages

- [MediatR](https://www.nuget.org/packages/MediatR/) - Request/response, command/query pattern
- [MediatR.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/MediatR.Extensions.Microsoft.AspNetCore/)
- Microsoft.EntityFrameworkCore & Tools - ORM and migrations
- Others as defined in `OfferZen.Infrastructure` and `Api` projects.

### Running the Application

1. Start the OfferZen.API project:
