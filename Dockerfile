FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["DotnetApiDemo.csproj", "./"]
RUN dotnet restore "DotnetApiDemo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DotnetApiDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetApiDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetApiDemo.dll"]
