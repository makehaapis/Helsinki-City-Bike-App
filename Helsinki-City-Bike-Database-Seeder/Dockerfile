FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Helsinki-City-Bike-Database-Seeder.csproj", "."]
RUN dotnet restore "./Helsinki-City-Bike-Database-Seeder.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Helsinki-City-Bike-Database-Seeder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Helsinki-City-Bike-Database-Seeder.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helsinki-City-Bike-Database-Seeder.dll"]