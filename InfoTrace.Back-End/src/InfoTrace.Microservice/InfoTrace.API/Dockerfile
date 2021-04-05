#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/InfoTrace.Microservice/InfoTrace.API/InfoTrace.API.csproj", "src/InfoTrace.Microservice/InfoTrace.API/"]
COPY ["src/InfoTrace.Microservice/InfoTrace.Infrastructure/InfoTrace.Infrastructure.csproj", "src/InfoTrace.Microservice/InfoTrace.Infrastructure/"]
RUN dotnet restore "src/InfoTrace.Microservice/InfoTrace.API/InfoTrace.API.csproj"
COPY . .
WORKDIR "/src/src/InfoTrace.Microservice/InfoTrace.API"
RUN dotnet build "InfoTrace.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfoTrace.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfoTrace.API.dll"]
