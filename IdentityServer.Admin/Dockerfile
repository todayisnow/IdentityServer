#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IdentityServer.Admin/IdentityServer.Admin.csproj", "IdentityServer.Admin/"]
COPY ["IdentityServer.Admin.EntityFramework/IdentityServer.Admin.EntityFramework.csproj", "IdentityServer.Admin.EntityFramework/"]
COPY ["IdentityServer.Shared/IdentityServer.Shared.csproj", "IdentityServer.Shared/"]
RUN dotnet restore "IdentityServer.Admin/IdentityServer.Admin.csproj"
COPY . .
WORKDIR "/src/IdentityServer.Admin"
RUN dotnet build "IdentityServer.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.Admin.dll"]
