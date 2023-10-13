# Game Store API

## Starting SQL Server
``` Shell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm  --name mssql mcr.microsoft.com/azure-sql-edge
```

## Setting the connection string to secret manager
``` Shell
$sa_password="[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=SA; Password=$sa_password; TrustServerCertificate=true"
```