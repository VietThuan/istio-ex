FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src
# COPY Northwind.sln ./
COPY Northwind.Services.Address/Northwind.Services.Address.csproj Northwind.Services.Address/
COPY Northwind.Services.Shared/* Northwind.Services.Shared/
RUN dotnet restore Northwind.Services.Address/Northwind.Services.Address.csproj
COPY . .
WORKDIR /src/Northwind.Services.Address/
RUN dotnet build Northwind.Services.Address.csproj -c Release

# Build and publish a release
FROM build-env AS publish
RUN dotnet publish Northwind.Services.Address.csproj -c Release -o /app

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Northwind.Services.Address.dll"]