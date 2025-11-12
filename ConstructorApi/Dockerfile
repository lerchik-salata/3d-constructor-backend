# Use official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out ./

# Expose port
EXPOSE 8080

# Set environment variables for DB connection (default placeholders)
ENV ConnectionStrings__DefaultConnection="Host=postgres_db;Port=5432;Database=constructordb;Username=postgres;Password=postgres"

# Start the application
ENTRYPOINT ["dotnet", "ConstructorApi.dll"]
