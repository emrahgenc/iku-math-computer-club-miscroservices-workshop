FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MicroservicesExp.Merchant/MicroservicesExp.Merchant.csproj", "MicroservicesExp.Merchant/"]
RUN dotnet restore "MicroservicesExp.Merchant/MicroservicesExp.Merchant.csproj"
COPY . .
WORKDIR "/src/MicroservicesExp.Merchant"
RUN dotnet build "MicroservicesExp.Merchant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesExp.Merchant.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesExp.Merchant.dll"]
