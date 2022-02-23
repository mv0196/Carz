#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AdvertisementService/Carz.AdvertisementService.API/Carz.AdvertisementService.API/Carz.AdvertisementService.API.csproj", "AdvertisementService/Carz.AdvertisementService.API/Carz.AdvertisementService.API/"]
COPY ["AdvertisementService/Carz.AdvertisementService.Services.Mongo/Carz.AdvertisementService.Services.Mongo/Carz.AdvertisementService.Services.Mongo.csproj", "AdvertisementService/Carz.AdvertisementService.Services.Mongo/Carz.AdvertisementService.Services.Mongo/"]
COPY ["AdvertisementService/Carz.AdvertisementService.Domain/Carz.AdvertisementService.Domain/Carz.AdvertisementService.Domain.csproj", "AdvertisementService/Carz.AdvertisementService.Domain/Carz.AdvertisementService.Domain/"]
COPY ["Shared/Carz.Common/Carz.Common/Carz.Common.csproj", "Shared/Carz.Common/Carz.Common/"]
COPY ["AdvertisementService/Carz.AdvertisementService.Infrastructure/Carz.AdvertisementService.Infrastructure/Carz.AdvertisementService.Infrastructure.csproj", "AdvertisementService/Carz.AdvertisementService.Infrastructure/Carz.AdvertisementService.Infrastructure/"]
RUN dotnet restore "AdvertisementService/Carz.AdvertisementService.API/Carz.AdvertisementService.API/Carz.AdvertisementService.API.csproj"
COPY . .
WORKDIR "/src/AdvertisementService/Carz.AdvertisementService.API/Carz.AdvertisementService.API"
RUN dotnet build "Carz.AdvertisementService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carz.AdvertisementService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carz.AdvertisementService.API.dll"]