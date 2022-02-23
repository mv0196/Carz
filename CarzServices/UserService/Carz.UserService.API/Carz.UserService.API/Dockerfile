#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UserService/Carz.UserService.API/Carz.UserService.API/Carz.UserService.API.csproj", "UserService/Carz.UserService.API/Carz.UserService.API/"]
COPY ["UserService/Carz.UserService.Services.SQL/Carz.UserService.Services.SQL.csproj", "UserService/Carz.UserService.Services.SQL/"]
COPY ["UserService/Carz.UserService.Domain/Carz.UserService.Domain.csproj", "UserService/Carz.UserService.Domain/"]
COPY ["UserService/Carz.UserService.Infrastructure/Carz.UserService.Infrastructure.csproj", "UserService/Carz.UserService.Infrastructure/"]
COPY ["Shared/Carz.Common/Carz.Common/Carz.Common.csproj", "Shared/Carz.Common/Carz.Common/"]
RUN dotnet restore "UserService/Carz.UserService.API/Carz.UserService.API/Carz.UserService.API.csproj"
COPY . .
WORKDIR "/src/UserService/Carz.UserService.API/Carz.UserService.API"
RUN dotnet build "Carz.UserService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carz.UserService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carz.UserService.API.dll"]