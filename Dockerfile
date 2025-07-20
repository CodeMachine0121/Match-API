FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet test ./UnitTests/UnitTests.csproj
WORKDIR /src/ESportsMatchTracker.API
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS final

# Set the working directory
WORKDIR /src/ESportsMatchTracker.API
COPY --from=build /src/ESportsMatchTracker.API /src/ESportsMatchTracker.API

# Copy the published output to the final image
WORKDIR /app
COPY --from=build /app/publish .

# Install EF Core tools for database migrations
RUN dotnet tool install --global dotnet-ef

ENV PATH="$PATH:/root/.dotnet/tools"
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80


# Set the entry point for the application
WORKDIR /app
CMD ["dotnet", "ESportsMatchTracker.API.dll"]
