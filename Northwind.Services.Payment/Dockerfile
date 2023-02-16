FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src
# COPY Northwind.sln ./
COPY Northwind.Services.Payment/Northwind.Services.Payment.csproj Northwind.Services.Payment/
COPY Northwind.Services.Shared/* Northwind.Services.Shared/
RUN dotnet restore Northwind.Services.Payment/Northwind.Services.Payment.csproj
COPY . .
WORKDIR /src/Northwind.Services.Payment/
RUN dotnet build Northwind.Services.Payment.csproj -c Release

# Build and publish a release
FROM build-env AS publish
RUN dotnet publish Northwind.Services.Payment.csproj -c Release -o /app

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Northwind.Services.Payment.dll"]