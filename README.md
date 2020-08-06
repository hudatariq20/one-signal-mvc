
# One Signal App Manager

## Description
This is a .NET CORE 2.1 Web Application following MVC, using MVC Identity for Authentication & Authorization with code first approach. The application is a wrapper for One signal Application management.  


## Setup Requirements

- Requires Visual studio.
- .NET Core 2.1 SDK.
- One Signal account.
- Auth Key for one signal.
- Docker (Optional for SqlServer)

## Setup Instructions

1. Checkout the repository and open the .sln project file with visual studio.
2. Make sure that all the dependencies are installed and start the web application, verify that the application starts and login page is loading.
3. The application has two connection strings in /appsettings.json `DefaultConnection`; this may work if your VS supports local mssql db. `SqlServerConnection`; for this you need to either have mssql server host and credentials or msql server running either standalone or by docker.
4. The connection string can be changed as per need in startup.cs at line no. 38.
5. Once the connection string is decided, move to `Tools > Nuget Package Manager > Package Manager Console` and Run `update database`, this will apply the MVC Identity migrations to create Identity Schema.
6. Run the web application and login from the credentials present in appsettings.json > Users.

## Setting up MsSql through Docker

1. Install Docker.
2. Run `docker ps` to verify installation.
3. Run `docker run -d --name sql_server -e ACCEPT_EULA=Y -e SA_PASSWORD=Admin@123 -p 1433:1433 microsoft/mssql-server-linux`
4. Run `docker ps` to verify that sql_server container is running.
