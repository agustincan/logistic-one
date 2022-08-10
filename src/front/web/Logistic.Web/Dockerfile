#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/front/web/Logistic.Web/Logistic.Web.csproj", "src/front/web/Logistic.Web/"]
RUN dotnet restore "src/front/web/Logistic.Web/Logistic.Web.csproj"
COPY . .
WORKDIR "/src/src/front/web/Logistic.Web"
RUN dotnet build "Logistic.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Logistic.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Logistic.Web.dll"]
