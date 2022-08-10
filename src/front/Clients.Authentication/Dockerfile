#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/front/Clients.Authentication/Clients.Authentication.csproj", "src/front/Clients.Authentication/"]
RUN dotnet restore "src/front/Clients.Authentication/Clients.Authentication.csproj"
COPY . .
WORKDIR "/src/src/front/Clients.Authentication"
RUN dotnet build "Clients.Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clients.Authentication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clients.Authentication.dll"]