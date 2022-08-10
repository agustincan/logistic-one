#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/back/transport/LogisticOne.Api.Transport/LogisticOne.Api.Transport.csproj", "src/back/transport/LogisticOne.Api.Transport/"]
RUN dotnet restore "src/back/transport/LogisticOne.Api.Transport/LogisticOne.Api.Transport.csproj"
COPY . .
WORKDIR "/src/src/back/transport/LogisticOne.Api.Transport"
RUN dotnet build "LogisticOne.Api.Transport.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogisticOne.Api.Transport.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogisticOne.Api.Transport.dll"]