# OfferZen Solution (.NET 8) Overview

## Architecture

OfferZen is structured with separation-of-concerns in mind:

| Project                | Purpose                                               |
|------------------------|------------------------------------------------------|
| OfferZen.Api           | Web API, controller endpoints, DI setup              |
| OfferZen.Application   | Command/query handlers Events (CQRS, MediatR)               |
| OfferZen.Core          | Domain models/interfaces, Dtos,Entities                           |
| OfferZen.Infrastructure| Database/repositories, EF Core 8, migrations         |

## .NET 8 Specifics

- Full .NET 8 SDK support (released Nov 2023)
- EF Core 8 - latest migration and ORM capabilities
- MediatR 13.x or later - fully compatible with .NET 8

## Migration and Package Configuration

- Migrations are handled via EF Core 8 CLI commands (see README)
- MediatR is registered via dependency injection and supports pipeline behaviors under .NET 8
- Dependency injection configured in individual `DependencyInjection.cs` classes

## Development Setup

- IDE: Visual Studio 2022+ or VS Code
- Recommended: .NET 8 SDK, SQL Server LocalDB (or configure via `appsettings.Development.json`)
- All migrations in `OfferZen.Infrastructure/Migrations`

## Getting Started

- Review `Program.cs` in `OfferZen.Api` for startup logic
- Use controller endpoints to interact with categories and products

---

This setup leverages the latest .NET 8 features, including improved performance and developer experience, while adhering to maintainable software engineering practices