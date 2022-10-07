#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MatchMe.Opportunities.Api/MatchMe.Opportunities.Api.csproj", "MatchMe.Opportunities.Api/"]
RUN dotnet restore "MatchMe.Opportunities.Api/MatchMe.Opportunities.Api.csproj"
COPY . .
WORKDIR "/src/MatchMe.Opportunities.Api"
RUN dotnet build "MatchMe.Opportunities.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatchMe.Opportunities.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatchMe.Opportunities.Api.dll"]