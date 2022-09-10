#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WfwDiscovery/WfwDiscovery.csproj", "WfwDiscovery/"]
RUN dotnet restore "WfwDiscovery/WfwDiscovery.csproj"
COPY . .
WORKDIR "/src/WfwDiscovery"
RUN dotnet build "WfwDiscovery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WfwDiscovery.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WfwDiscovery.dll"]