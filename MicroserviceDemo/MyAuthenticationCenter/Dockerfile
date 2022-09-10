#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyAuthenticationCenter/MyAuthenticationCenter.csproj", "MyAuthenticationCenter/"]
RUN dotnet restore "MyAuthenticationCenter/MyAuthenticationCenter.csproj"
COPY . .
WORKDIR "/src/MyAuthenticationCenter"
RUN dotnet build "MyAuthenticationCenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAuthenticationCenter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAuthenticationCenter.dll"]