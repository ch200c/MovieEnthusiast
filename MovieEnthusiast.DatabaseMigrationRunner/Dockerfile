#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MovieEnthusiast.DatabaseMigrationRunner/MovieEnthusiast.DatabaseMigrationRunner.csproj", "MovieEnthusiast.DatabaseMigrationRunner/"]
COPY ["MovieEnthusiast.Infrastructure/MovieEnthusiast.Infrastructure.csproj", "MovieEnthusiast.Infrastructure/"]
COPY ["MovieEnthusiast.Application/MovieEnthusiast.Application.csproj", "MovieEnthusiast.Application/"]
COPY ["MovieEnthusiast.Domain/MovieEnthusiast.Domain.csproj", "MovieEnthusiast.Domain/"]
RUN dotnet restore "MovieEnthusiast.DatabaseMigrationRunner/MovieEnthusiast.DatabaseMigrationRunner.csproj"
COPY . .
WORKDIR "/src/MovieEnthusiast.DatabaseMigrationRunner"
RUN dotnet build "MovieEnthusiast.DatabaseMigrationRunner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieEnthusiast.DatabaseMigrationRunner.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieEnthusiast.DatabaseMigrationRunner.dll"]