FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt update
RUN apt -y install net-tools
RUN apt -y install curl
USER $APP_UID
WORKDIR /app
# Exposing port 443 for HTTPS
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdentityServer/IdentityServer.csproj", "IdentityServer/"]
RUN dotnet restore "IdentityServer/IdentityServer.csproj"
COPY . .
WORKDIR "/src/IdentityServer"
RUN dotnet build "IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

## Copy your SSL certificate and key
COPY certs/snip.pfx /app/snip.pfx
#
## Set environment variables for Kestrel to use HTTPS
ENV ASPNETCORE_URLS=https://+:443
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/snip.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=123

ENTRYPOINT ["dotnet", "IdentityServer.dll"]