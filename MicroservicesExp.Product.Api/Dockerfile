FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MicroservicesExp.Product.Api/MicroservicesExp.Product.Api.csproj", "MicroservicesExp.Product.Api/"]
RUN dotnet restore "MicroservicesExp.Product.Api/MicroservicesExp.Product.Api.csproj"
COPY . .
WORKDIR "/src/MicroservicesExp.Product.Api"
RUN dotnet build "MicroservicesExp.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesExp.Product.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesExp.Product.Api.dll"]
