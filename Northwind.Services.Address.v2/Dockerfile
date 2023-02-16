FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src
# COPY Northwind.sln ./
COPY Northwind.Services.Address.v2/Northwind.Services.Address.v2.csproj Northwind.Services.Address.v2/
COPY Northwind.Services.Shared/* Northwind.Services.Shared/
RUN dotnet restore Northwind.Services.Address.v2/Northwind.Services.Address.v2.csproj
COPY . .
WORKDIR /src/Northwind.Services.Address.v2/
RUN dotnet build Northwind.Services.Address.v2.csproj -c Release

# Build and publish a release
FROM build-env AS publish
RUN dotnet publish Northwind.Services.Address.v2.csproj -c Release -o /app

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Northwind.Services.Address.v2.dll"]