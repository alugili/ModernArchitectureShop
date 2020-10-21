##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /src
#COPY ["src/Store/ModernArchitectureShop.StoreApi/ModernArchitectureShop.StoreApi.csproj", "src/Store/ModernArchitectureShop.StoreApi/"]
#COPY ["src/Store/ModernArchitectureShop.Store.Domain/ModernArchitectureShop.Store.Domain.csproj", "src/Store/ModernArchitectureShop.Store.Domain/"]
#COPY ["src/UI/ModernArchitectureShop.BlazorUI.csproj", "src/UI/"]
#RUN dotnet restore "src/Store/ModernArchitectureShop.StoreApi/ModernArchitectureShop.StoreApi.csproj"
#COPY . .
#WORKDIR "/src/src/Store/ModernArchitectureShop.StoreApi"
#RUN dotnet build "ModernArchitectureShop.StoreApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ModernArchitectureShop.StoreApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ModernArchitectureShop.StoreApi.dll"]
#
