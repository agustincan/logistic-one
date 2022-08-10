#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/back/identity/Identity.Api/Identity.Api.csproj", "src/back/identity/Identity.Api/"]
COPY ["src/back/identity/Identity.Services.EvenHandlers/Identity.Services.EvenHandlers.csproj", "src/back/identity/Identity.Services.EvenHandlers/"]
COPY ["src/back/identity/Identity.Persistence/Identity.Persistence.Database.csproj", "src/back/identity/Identity.Persistence/"]
COPY ["src/back/identity/Identity.Domain/Identity.Domain.csproj", "src/back/identity/Identity.Domain/"]
COPY ["src/common/Service.Common.Collection/Service.Common.Collection.csproj", "src/common/Service.Common.Collection/"]
RUN dotnet restore "src/back/identity/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/back/identity/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
