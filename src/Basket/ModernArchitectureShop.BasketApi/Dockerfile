#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Basket/ModernArchitectureShop.BasketApi/ModernArchitectureShop.BasketApi.csproj", "src/Basket/ModernArchitectureShop.BasketApi/"]
COPY ["src/Basket/ModernArchitectureShop.Basket.Domain/ModernArchitectureShop.Basket.Domain.csproj", "src/Basket/ModernArchitectureShop.Basket.Domain/"]
RUN dotnet restore "src/Basket/ModernArchitectureShop.BasketApi/ModernArchitectureShop.BasketApi.csproj"
COPY . .
WORKDIR "/src/src/Basket/ModernArchitectureShop.BasketApi"
RUN dotnet build "ModernArchitectureShop.BasketApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModernArchitectureShop.BasketApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModernArchitectureShop.BasketApi.dll"]
