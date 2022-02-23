#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IdentityService/Carz.IdentityService.API/Carz.IdentityService.API.csproj", "IdentityService/Carz.IdentityService.API/"]
COPY ["Shared/Carz.Common/Carz.Common/Carz.Common.csproj", "Shared/Carz.Common/Carz.Common/"]
COPY ["IdentityService/Carz.IdentityServiceServices.SQL/Carz.IdentityServiceServices.SQL/Carz.IdentityService.Services.SQL.csproj", "IdentityService/Carz.IdentityServiceServices.SQL/Carz.IdentityServiceServices.SQL/"]
COPY ["IdentityService/Carz.IdentityService.Domain/Carz.IdentityService.Domain.csproj", "IdentityService/Carz.IdentityService.Domain/"]
COPY ["IdentityService/Carz.IdentityService.Infrastructure/Carz.IdentityService.Infrastructure.csproj", "IdentityService/Carz.IdentityService.Infrastructure/"]
COPY ["IdentityService/Carz.IdentityService.Services.Mongo/Carz.IdentityService.Services.Mongo.csproj", "IdentityService/Carz.IdentityService.Services.Mongo/"]
COPY ["UserService/Carz.UserService.Domain/Carz.UserService.Domain.csproj", "UserService/Carz.UserService.Domain/"]
RUN dotnet restore "IdentityService/Carz.IdentityService.API/Carz.IdentityService.API.csproj"
COPY . .
WORKDIR "/src/IdentityService/Carz.IdentityService.API"
RUN dotnet build "Carz.IdentityService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carz.IdentityService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carz.IdentityService.API.dll"]