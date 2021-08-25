# dotnet-api (requires .NET 5.0)

Example of Todo API using:
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore.Filters

This example expects local Microsoft SQL Server to be available for CRUD operations.
Before starting this project run:
- dotnet tool install --global dotnet-ef
- dotnet restore
- dotnet ef database update
