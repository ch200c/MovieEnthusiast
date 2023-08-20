Adding database migrations locally can be done using EF Core tools. From project's root direcotry:

`dotnet ef migrations add YourMigrationName --startup-project MovieEnthusiast.Api/MovieEnthusiast.Api.csproj --project MovieEnthusiast.Infrastructure/MovieEnthusiast.Infrastructure.csproj -o Persistence/Migrations`