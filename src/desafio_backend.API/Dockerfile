#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/desafio_backend.API/desafio_backend.API.csproj", "src/desafio_backend.API/"]
COPY ["src/desafio_backend.Application/desafio_backend.Application.csproj", "src/desafio_backend.Application/"]
COPY ["src/desafio_backend.Communication/desafio_backend.Communication.csproj", "src/desafio_backend.Communication/"]
COPY ["src/desafio_backend.Domain/desafio_backend.Domain.csproj", "src/desafio_backend.Domain/"]
COPY ["src/desafio_backend.Exception/desafio_backend.Exception.csproj", "src/desafio_backend.Exception/"]
COPY ["src/desafio_backend.Infrastructure/desafio_backend.Infrastructure.csproj", "src/desafio_backend.Infrastructure/"]
RUN dotnet restore "./src/desafio_backend.API/desafio_backend.API.csproj"
COPY . .
WORKDIR "/src/src/desafio_backend.API"
RUN dotnet build "./desafio_backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./desafio_backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "desafio_backend.API.dll"]