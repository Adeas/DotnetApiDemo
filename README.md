# DotnetApiDemo

## What is this example for?

This project mostly shows how to implement ASP.NET Core Web API using packages listed below and how to use Entity Framework, JWT token authorization, and Swagger:
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore.Filters

## This example API can be run in Docker Desktop with docker-compose

To run both API and DB:
```
docker-compose -f "docker-compose.yml" up -d --build
```
You know if the app container works if you can see that it is listening on port 80. If it fails to start because of a login issue, try to launch it again because there is still a deadlock bug in the code and the login function of MSSQL sometimes fails.

### Optionally run it without docker
If you are not using docker, then this example expects .NET 5.0 SDK to be installed and Microsoft SQL Server to be available for CRUD operations.

You can install free Microsoft SQL Express from [Microsoft MS SQL Downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

Optionally install [SSMS] (https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15) SQL Server Management Studio.

Before starting this project locally without docker run:
```
- dotnet tool install --global dotnet-ef
- dotnet restore
```

After requirements are met and packages installed you can run the example project with:
```
dotnet watch run
```
## How to access DotnetApiDemo Swagger
After both API and DB containers are running, you can access Swagger using http://localhost:8001/swagger where you need to first register a user account using Register under Auth endpoints, use that account then in Login and copy the JWT token returned inside "data" field to the "Authorize" with prefix "Bearer " like instructed. After authorization, you can see locks next to "Todo" endpoints switch to the locked position, and only then Todo endpoints can be called without receiving "Error: Unauthorized."

## Docker-Compose

Compose is a tool for defining and running multi-container Docker applications. With Compose, you use a YAML file to configure your application’s services. Then, with a single command, you create and start all the services from your configuration. To learn more about all the features of Compose, see the [list of features](https://docs.docker.com/compose/overview/#features).

By using the following command you can start up your application:

```
docker-compose -f <docker-compose-file> up
```

You can also run docker-compose in detached mode using the -d flag, then you can stop it whenever needed by the following command:

```
docker-compose stop
```

You can bring everything down, removing the containers entirely, with the down command. Pass `--volumes` to also remove the data volume.

## Docker Installation

### Linux

Quick and easy install script provided by Docker:

```
curl -sSL https://get.docker.com/ | sh
```

If you're not willing to run a random shell script, please see the [installation](https://docs.docker.com/engine/installation/linux/) instructions for your distribution.

If you are a complete Docker newbie, you should follow the [series of tutorials](https://docs.docker.com/engine/getstarted/) now.

### macOS

Download and install [Docker Community Edition](https://www.docker.com/community-edition). if you have Homebrew-Cask, just type `brew cask install docker`. Or Download and install [Docker Toolbox](https://docs.docker.com/toolbox/overview/).  [Docker For Mac](https://docs.docker.com/docker-for-mac/) is nice, but it's not quite as finished as the VirtualBox install.  [See the comparison](https://docs.docker.com/docker-for-mac/docker-toolbox/).

> **NOTE** Docker Toolbox is legacy. You should use Docker Community Edition, See [Docker Toolbox](https://docs.docker.com/toolbox/overview/).

Once you've installed Docker Community Edition, click the docker icon in Launchpad.

If you are a complete Docker newbie, you should probably follow the [series of tutorials](https://docs.docker.com/engine/getstarted/) now.

### Windows 10

Instructions to install Docker Desktop for Windows can be found [here](https://hub.docker.com/editions/community/docker-ce-desktop-windows)

Once installed, open Windows PowerShell as administrator

```PowerShell
#Display the version of docker installed:
docker version
```

Additionally, if you have WSL or WSL2 installed on your desktop, you might want to install the Linux Kernel for Windows. Instructions can be found [here](https://techcommunity.microsoft.com/t5/windows-dev-appconsult/using-wsl2-in-a-docker-linux-container-on-windows-to-run-a/ba-p/1482133). This requires the Windows Subsystem for Linux feature. This will allow for containers to be accessed by WSL operating systems, as well as the efficiency gain from running WSL operating systems in docker. It is also preferred to use [Windows terminal](https://docs.microsoft.com/en-us/windows/terminal/get-started) for this.

### Windows Server 2016 / 2019

Follow Microsoft's instructions that can be found [here](https://docs.microsoft.com/en-us/virtualization/windowscontainers/deploy-containers/deploy-containers-on-server#install-docker)

If using the latest edge version of 2019, be prepared to only work in PowerShell, as it is only a server core image (no desktop interface). When starting this machine, it will log in and go straight to a PowerShell window. It is recommended to install text editors and other tools using [Chocolatey](https://chocolatey.org/install).

After installing, these commands will work:
```PowerShell
#Display the version of docker installed:
docker version
```

Windows Server 2016 is not able to run Linux images. 

Windows Server Build 2004 is capable of running both Linux and Windows containers simultaneously through Hyper-V isolation. When running containers, use the ```--isolation=hyperv``` command, which will isolate the container using a separate kernel instance. 
