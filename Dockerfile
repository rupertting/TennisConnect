FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
COPY TennisConnect.Data/*.csproj ./TennisConnect.Data/
COPY TennisConnect.Services/*.csproj ./TennisConnect.Services/
COPY TennisConnect.Web/*.csproj ./TennisConnect.Web/
COPY TennisConnect.Test/*csproj TennisConnect.Test/

RUN dotnet restore

# Copy everything else and build
COPY TennisConnect.Data/. ./TennisConnect.Data/
COPY TennisConnect.Services . ./TennisConnect.Services/
COPY TennisConnect.Web/. ./TennisConnect.Web/

WORKDIR /app/TennisConnect.Web
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build-env /app/TennisConnect.Web/out .
ENTRYPOINT ["dotnet", "TennisConnect.Web.dll"]
