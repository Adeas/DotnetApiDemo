# dotnet-api (requires: .NET 5.0 and MSSQL, optionally run dockerized version with docker-compose)

Example of Todo API using:
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore.Filters

This example API can be run with Docker, this requires no seperate MSSQL installation then.

To run both API and DB:
docker-compose -f "docker-compose.yml" up -d --build

NOTE! If dotnetapidemo container fails to start because of login issue, try to launch it again because there is deadlock issue in MSSQL that prevents login.

If you are not using docker, then this example expects local Microsoft SQL Server to be available for CRUD operations.
Before starting this project locally without docker run:
- dotnet tool install --global dotnet-ef
- dotnet restore
