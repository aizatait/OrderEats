FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderEats.API/OrderEats.API.csproj", "OrderEats.API/"]
COPY ["OrderEats.Infrastructure/OrderEats.Infrastructure.csproj", "OrderEats.Infrastructure/"]
COPY ["OrderEats.Core/OrderEats.Core.csproj", "OrderEats.Core/"]
COPY ["OrderEats.SharedKernel/OrderEats.SharedKernel.csproj", "OrderEats.SharedKernel/"]
RUN dotnet restore "OrderEats.API/OrderEats.API.csproj"
COPY . .
WORKDIR "/src/OrderEats.API"
RUN dotnet build "OrderEats.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderEats.API.csproj" -c Release -o /app/publish  

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderEats.API.dll"]